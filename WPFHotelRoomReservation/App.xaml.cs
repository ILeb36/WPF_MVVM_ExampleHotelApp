using System.Windows;
using Microsoft.EntityFrameworkCore;
using WPFHotelRoomReservation.DatabaseRelated;
using WPFHotelRoomReservation.Models;
using WPFHotelRoomReservation.Services;
using WPFHotelRoomReservation.Stores;
using WPFHotelRoomReservation.ViewModels;

namespace WPFHotelRoomReservation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string DB_CONNECTION_STRING = "Data Source=Reservations.db";
        private readonly Hotel hotel;
        private readonly NavigationStore navigationStore;
        private readonly DatabaseContextFactory contextFactory;

        public App()
        {
            contextFactory = new DatabaseContextFactory(DB_CONNECTION_STRING);
            IReservationsProvider provider = new DatabaseReservationsProvider(contextFactory);
            IReservationsCreator creator = new DatabaseReservationsCreator(contextFactory);
            IReservationsValidator validator = new DatabaseReservationsValidator(contextFactory);

            ReservationBook reservationBook = new ReservationBook(provider, creator, validator);
            hotel = new Hotel("MVVM WPF Hotel", reservationBook);
            navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            navigationStore.CurrentViewModel = CreateListOfReservationsViewModel();

            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private ReserveRoomViewModel CreateReserveRoomViewModel()
        {
            return new ReserveRoomViewModel(hotel, new NavigationService(navigationStore, CreateListOfReservationsViewModel));
        }

        private ListOfReservationsViewModel CreateListOfReservationsViewModel()
        {
            return new ListOfReservationsViewModel(hotel, new NavigationService(navigationStore, CreateReserveRoomViewModel));
        }
    }
}

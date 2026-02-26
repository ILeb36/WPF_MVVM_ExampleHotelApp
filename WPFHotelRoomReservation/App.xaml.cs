using System.Windows;
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
        private readonly Hotel hotel;
        private readonly NavigationStore navigationStore;

        public App()
        {
            hotel = new Hotel("MVVM WPF Hotel");
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

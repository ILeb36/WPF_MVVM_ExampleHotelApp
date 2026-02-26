using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFHotelRoomReservation.Commands;
using WPFHotelRoomReservation.Models;
using WPFHotelRoomReservation.Services;

namespace WPFHotelRoomReservation.ViewModels
{
    public class ListOfReservationsViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ReservationViewModel> observableReservations;
        private readonly Hotel hotel;

        public ICommand ReserveRoomViewNavigationCommand { get; }
        public IEnumerable<ReservationViewModel> Reservations => observableReservations;

        public ListOfReservationsViewModel(Hotel hotel, NavigationService reserveRoomViewNavigationService)
        {
            observableReservations = new ObservableCollection<ReservationViewModel>();
            ReserveRoomViewNavigationCommand = new NavigationCommand(reserveRoomViewNavigationService);
            this.hotel = hotel;

            UpdateReservations();
        }

        private async Task UpdateReservations()
        {
            observableReservations.Clear();
            var reservations = await hotel.GetAllReservations();
            foreach (Reservation reservation in reservations)
            {
                observableReservations.Add(new ReservationViewModel(reservation));
            }
        }
    }
}

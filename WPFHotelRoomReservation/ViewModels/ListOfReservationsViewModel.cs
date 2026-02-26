using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFHotelRoomReservation.Commands;
using WPFHotelRoomReservation.Models;
using WPFHotelRoomReservation.Services;

namespace WPFHotelRoomReservation.ViewModels
{
    public class ListOfReservationsViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ReservationViewModel> reservations;
        private readonly Hotel hotel;

        public ICommand ReserveRoomViewNavigationCommand { get; }
        public IEnumerable<ReservationViewModel> Reservations => reservations;

        public ListOfReservationsViewModel(Hotel hotel, NavigationService reserveRoomViewNavigationService)
        {
            reservations = new ObservableCollection<ReservationViewModel>();
            ReserveRoomViewNavigationCommand = new NavigationCommand(reserveRoomViewNavigationService);
            this.hotel = hotel;

            UpdateReservations();
        }

        private void UpdateReservations()
        {
            reservations.Clear();
            foreach (Reservation reservation in hotel.GetAllReservations())
            {
                reservations.Add(new ReservationViewModel(reservation));
            }
        }
    }
}

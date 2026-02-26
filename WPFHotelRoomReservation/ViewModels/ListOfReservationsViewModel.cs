using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFHotelRoomReservation.Models;

namespace WPFHotelRoomReservation.ViewModels
{
    public class ListOfReservationsViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ReservationViewModel> reservations;

        public ICommand CreateReservationComman { get; }
        public IEnumerable<ReservationViewModel> Reservations => reservations;

        public ListOfReservationsViewModel()
        {
            reservations = new ObservableCollection<ReservationViewModel>();

            reservations.Add(new ReservationViewModel(new Reservation(new Room(2, 3), "Me", DateTime.Today, DateTime.Now)));
            reservations.Add(new ReservationViewModel(new Reservation(new Room(3, 4), "Something Long", DateTime.Today, DateTime.Now)));
            reservations.Add(new ReservationViewModel(new Reservation(new Room(4, 3), "123", DateTime.Today, DateTime.Now)));
        }

    }
}

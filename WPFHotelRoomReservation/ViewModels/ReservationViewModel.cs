using WPFHotelRoomReservation.Models;

namespace WPFHotelRoomReservation.ViewModels
{
    //Avoiding all business logic from model that isn't required in view
    //Base model also doesn't implement INotifyChanged interface to react on changes
    //It may lead to memory leaks
    public class ReservationViewModel : BaseViewModel
    {
        private readonly Reservation reservation;

        //changing to string, same as in View
        public string Room => reservation.Room?.ToString();
        public string StartTime => reservation.StartTime.ToString("f");
        public string EndTime => reservation.EndTime.ToString("f");
        public string Resident => reservation.Resident;

        public ReservationViewModel(Reservation reservation)
        {
            this.reservation = reservation;
        }
    }
}

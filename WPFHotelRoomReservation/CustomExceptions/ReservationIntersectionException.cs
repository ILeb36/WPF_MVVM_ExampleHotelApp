using WPFHotelRoomReservation.Models;

namespace WPFHotelRoomReservation.CustomExceptions
{
    internal class ReservationIntersectionException : Exception
    {
        public Reservation ActiveReservation { get; }
        public Reservation NewReservation { get; }

        public ReservationIntersectionException(Reservation activeReservation, Reservation newReservation)
        {
            ActiveReservation = activeReservation;
            NewReservation = newReservation;
        }

        public ReservationIntersectionException(string? message, Reservation activeReservation, Reservation newReservation) : base(message)
        {
            ActiveReservation = activeReservation;
            NewReservation = newReservation;
        }

        public ReservationIntersectionException(string? message, Exception? innerException, Reservation activeReservation, Reservation newReservation) : base(message, innerException)
        {
            ActiveReservation = activeReservation;
            NewReservation = newReservation;
        }
    }
}

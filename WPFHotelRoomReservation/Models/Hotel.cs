using WPFHotelRoomReservation.CustomExceptions;

namespace WPFHotelRoomReservation.Models
{
    public class Hotel
    {
        private readonly ReservationBook reservationBook;

        public string Name { get; }

        public Hotel(string name)
        {
            Name = name;
            reservationBook = new ReservationBook();
        }

        /// <summary>
        /// Get all reservations made by resident
        /// </summary>
        /// <param name="resident">Current resident</param>
        /// <returns>All reservations made by resident</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Reservation> GetReservationsByResident(Resident resident)
        {
            return reservationBook.GetReservationsByResident(resident);
        }

        /// <summary>
        /// Make a new room reservation
        /// </summary>
        /// <param name="reservation">New reservation</param>
        /// <exception cref="ReservationIntersectionException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public void ReserveRoom(Reservation reservation)
        {
            reservationBook.AddReservation(reservation);
        }
    }
}

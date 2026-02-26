using WPFHotelRoomReservation.CustomExceptions;

namespace WPFHotelRoomReservation.Models
{
    public class Hotel
    {
        private readonly ReservationBook reservationBook;

        public string Name { get; }

        /// <summary>
        /// Main class, holder of reservations list
        /// </summary>
        /// <param name="name">Name of the hotel</param>
        public Hotel(string name, ReservationBook reservationBook)
        {
            Name = name;
            this.reservationBook = reservationBook;
        }

        /// <summary>
        /// Get all active reservations
        /// </summary>
        /// <returns>List of all reservations</returns>
        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
             return await reservationBook.GetAllReservations();
        }

        /// <summary>
        /// Make a new room reservation
        /// </summary>
        /// <param name="reservation">New reservation</param>
        /// <exception cref="ReservationIntersectionException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task ReserveRoom(Reservation reservation)
        {
            await reservationBook.AddReservation(reservation);
        }
    }
}

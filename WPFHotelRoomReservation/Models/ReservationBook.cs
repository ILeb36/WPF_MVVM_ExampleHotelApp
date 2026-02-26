using WPFHotelRoomReservation.CustomExceptions;

namespace WPFHotelRoomReservation.Models
{
    public class ReservationBook
    {
        private readonly List<Reservation> listOfReservations;

        public ReservationBook()
        {
            listOfReservations = new List<Reservation>();
        }

        /// <summary>
        /// Get reservations made by resident
        /// </summary>
        /// <param name="resident">Current resident</param>
        /// <returns>List of reservations made by resident</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<Reservation> GetReservationsByResident(string resident)
        {
            ArgumentNullException.ThrowIfNull(resident);
            return listOfReservations.Where(reservation => reservation.Resident.Equals(resident));
        }

        /// <summary>
        /// Get all active reservations
        /// </summary>
        /// <returns>List of all reservations</returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return listOfReservations;
        }

        /// <summary>
        /// Trying to add new reservation to the list
        /// </summary>
        /// <param name="reservation">New reservation</param>
        /// <exception cref="ReservationIntersectionException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddReservation(Reservation reservation)
        {
            ArgumentNullException.ThrowIfNull(reservation);
            foreach (Reservation activeReservation in listOfReservations)
            {
                if (activeReservation.IsIntersectWith(reservation))
                {
                    throw new ReservationIntersectionException(activeReservation, reservation);
                }
            }

            listOfReservations.Add(reservation);
        }
    }
}

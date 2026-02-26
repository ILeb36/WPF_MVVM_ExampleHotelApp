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

        public IEnumerable<Reservation> GetReservationsByResident(Resident resident)
        {
            ArgumentNullException.ThrowIfNull(resident);
            return listOfReservations.Where(reservation => reservation.Resident.Equals(resident));
        }

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

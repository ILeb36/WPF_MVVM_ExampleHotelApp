using WPFHotelRoomReservation.CustomExceptions;
using WPFHotelRoomReservation.Services;

namespace WPFHotelRoomReservation.Models
{
    public class ReservationBook
    {
        private readonly IReservationsProvider reservationsProvider;
        private readonly IReservationsCreator reservationsCreator;
        private readonly IReservationsValidator reservationsValidator;

        /// <summary>
        /// List of all reservations
        /// </summary>
        public ReservationBook(IReservationsProvider reservationsProvider, IReservationsCreator reservationsCreator, IReservationsValidator reservationsValidator)
        {
            this.reservationsProvider = reservationsProvider;
            this.reservationsCreator = reservationsCreator;
            this.reservationsValidator = reservationsValidator;
        }

        /// <summary>
        /// Get all active reservations
        /// </summary>
        /// <returns>List of all reservations</returns>
        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await reservationsProvider.GetAllReservations();
        }

        /// <summary>
        /// Trying to add new reservation to the list
        /// </summary>
        /// <param name="reservation">New reservation</param>
        /// <exception cref="ReservationIntersectionException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task AddReservation(Reservation reservation)
        {
            ArgumentNullException.ThrowIfNull(reservation);

            Reservation conflictedReservation = await reservationsValidator.SearchForIntersections(reservation);
            if (conflictedReservation is not null)
            {
                throw new ReservationIntersectionException(conflictedReservation, reservation);
            }

            await reservationsCreator.CreateReservation(reservation);
        }
    }
}

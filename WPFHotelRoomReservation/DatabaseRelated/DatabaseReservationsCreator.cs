using WPFHotelRoomReservation.DatabaseRelated.DataTransferObjects;
using WPFHotelRoomReservation.Models;
using WPFHotelRoomReservation.Services;

namespace WPFHotelRoomReservation.DatabaseRelated
{
    public class DatabaseReservationsCreator : IReservationsCreator
    {
        private readonly DatabaseContextFactory contextFactory;

        public DatabaseReservationsCreator(DatabaseContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task CreateReservation(Reservation reservation)
        {
            using (DatabaseContext context = contextFactory.CreateContext())
            {
                ReservationDTO reservationDTO = reservation.ToReservationDTO();
                context.Reservations.Add(reservationDTO);
                await context.SaveChangesAsync();
            }
        }

        
    }
}

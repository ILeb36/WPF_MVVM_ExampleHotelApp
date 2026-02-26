using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WPFHotelRoomReservation.DatabaseRelated.DataTransferObjects;
using WPFHotelRoomReservation.Models;
using WPFHotelRoomReservation.Services;

namespace WPFHotelRoomReservation.DatabaseRelated
{
    public class DatabaseReservationsProvider : IReservationsProvider
    {
        private readonly DatabaseContextFactory contextFactory;

        public DatabaseReservationsProvider(DatabaseContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            using (DatabaseContext context = contextFactory.CreateContext())
            {
                IEnumerable<ReservationDTO> reservationsDTO = await context.Reservations.ToListAsync();
                return reservationsDTO.Select(r => r.ToReservation());
            }
        }
    }
}

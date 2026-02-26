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
    public class DatabaseReservationsValidator : IReservationsValidator
    {
        private readonly DatabaseContextFactory contextFactory;

        public DatabaseReservationsValidator(DatabaseContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }


        public async Task<Reservation> SearchForIntersections(Reservation reservation)
        {
            using (DatabaseContext context = contextFactory.CreateContext())
            {
                return await context.Reservations.Select(r => r.ToReservation()).FirstOrDefaultAsync(r => r.IsIntersectWith(reservation));
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using WPFHotelRoomReservation.DatabaseRelated.DataTransferObjects;

namespace WPFHotelRoomReservation.DatabaseRelated
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ReservationDTO> Reservations { get; set; } = null!;

        public DatabaseContext(DbContextOptions options) : base(options)
        { 
            Database.EnsureCreated();
        }
    }
}

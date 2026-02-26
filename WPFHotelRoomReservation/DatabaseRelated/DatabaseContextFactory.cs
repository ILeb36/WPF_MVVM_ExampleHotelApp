using Microsoft.EntityFrameworkCore;

namespace WPFHotelRoomReservation.DatabaseRelated
{
    public class DatabaseContextFactory
    {
        private readonly string connectionString;

        public DatabaseContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DatabaseContext CreateContext()
        {
            var options = new DbContextOptionsBuilder().UseSqlite(connectionString).Options;
            return new DatabaseContext(options);
        }
    }
}

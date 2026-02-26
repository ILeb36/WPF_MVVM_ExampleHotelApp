using System.Configuration;
using System.Data;
using System.Windows;
using WPFHotelRoomReservation.CustomExceptions;
using WPFHotelRoomReservation.Models;

namespace WPFHotelRoomReservation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("WPF MVVM hotel");
            string resident = "Me";

            try
            {
                hotel.ReserveRoom(new Reservation(
                new Room(2, 5),
                resident,
                new DateTime(2026, 3, 2),
                new DateTime(2026, 3, 12)));

            hotel.ReserveRoom(new Reservation(
                new Room(2, 5),
                resident,
                new DateTime(2026, 3, 2),
                new DateTime(2026, 3, 3)));

            }
            catch(ReservationIntersectionException)
            {

            }

            var reservations = hotel.GetReservationsByResident(resident);

            base.OnStartup(e);
        }
    }

}

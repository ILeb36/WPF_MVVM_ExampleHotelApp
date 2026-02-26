using WPFHotelRoomReservation.Models;

namespace WPFHotelRoomReservation.Services
{
    public interface IReservationsCreator
    {
        Task CreateReservation(Reservation reservation);
    }
}

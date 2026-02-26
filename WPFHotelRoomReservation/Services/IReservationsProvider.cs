using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFHotelRoomReservation.Models;

namespace WPFHotelRoomReservation.Services
{
    public interface IReservationsProvider
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFHotelRoomReservation.Models;

namespace WPFHotelRoomReservation.Services
{
    public interface IReservationsValidator
    {
        Task<Reservation> SearchForIntersections(Reservation reservation);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFHotelRoomReservation.Models;

namespace WPFHotelRoomReservation.DatabaseRelated.DataTransferObjects
{
    public static class ReservationsTransformer
    {
        public static Reservation ToReservation(this ReservationDTO dto)
        {
            return new Reservation(new Room(dto.RoomNumber, dto.FloorNumber), dto.Resident, dto.StartTime, dto.EndTime);
        }

        public static ReservationDTO ToReservationDTO(this Reservation reservation)
        {
            return new ReservationDTO()
            {
                RoomNumber = reservation.Room?.RoomNumber ?? 0,
                FloorNumber = reservation.Room?.FloorNumber ?? 0,
                Resident = reservation.Resident,
                StartTime = reservation.StartTime,
                EndTime = reservation.EndTime
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFHotelRoomReservation.Models;

namespace WPFHotelRoomReservation.DatabaseRelated.DataTransferObjects
{
    public class ReservationDTO
    {
        [Key]
        public Guid Id { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public string Resident { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

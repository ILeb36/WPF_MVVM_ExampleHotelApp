namespace WPFHotelRoomReservation.Models
{
    public class Reservation
    {

        public Room Room { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public string Resident { get; }
        public TimeSpan Duration => EndTime - StartTime;

        public Reservation(Room room, string resident, DateTime startTime, DateTime endTime)
        {
            ArgumentNullException.ThrowIfNull(room);
            ArgumentNullException.ThrowIfNull(resident);
            //if (string.IsNullOrEmpty(CheckDates ()))

            Room = room;
            Resident = resident;
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        /// Check is current reservation dates intersects with target reservation dates
        /// </summary>
        /// <param name="targetReservation">Target reservation</param>
        /// <returns>true, if dates for the same room intersects</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool IsIntersectWith(Reservation targetReservation)
        {
            ArgumentNullException.ThrowIfNull(targetReservation);
            if (Room != targetReservation.Room) return false;

            if (targetReservation.StartTime < EndTime || targetReservation.EndTime > StartTime) return true;

            return false;
        }


        //private string? CheckDates(DateTime startTime, DateTime endTime)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    if (startTime <= DateTime.Now)
        //    {
        //        sb.AppendLine("Start date should not be in the past");
        //    }

        //    if (endTime <= DateTime.Now)
        //    {
        //        sb.AppendLine("End date should not be in the past");
        //    }

        //    if (startTime >= endTime)
        //    {
        //        sb.AppendLine("Start date should not be higher or equal to End date");
        //    }

        //    return sb.ToString();
        //}
    }
}

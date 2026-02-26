namespace WPFHotelRoomReservation.Models
{
    public class Room
    {
        public int RoomNumber { get; }
        public int FloorNumber { get; }

        /// <summary>
        /// Room instance
        /// </summary>
        /// <param name="roomNumber"></param>
        /// <param name="floorNumber"></param>
        public Room(int roomNumber, int floorNumber)
        {
            RoomNumber = roomNumber;
            FloorNumber = floorNumber;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Room room)
            {
                if (FloorNumber == room.FloorNumber && RoomNumber == room.RoomNumber)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RoomNumber, FloorNumber);
        }

        public override string ToString()
        {
            return $"Room {RoomNumber} at floor {FloorNumber}";
        }

        public static bool operator ==(Room left, Room right)
        {
            if (left is null || right is null)
                return false;

            return left is not null && left.Equals(right);
        }

        public static bool operator !=(Room left, Room right)
        {
            return !(left == right);
        }
    }
}

namespace WPFHotelRoomReservation.Models
{
    public class Resident
    {
        public int Id { get; }
        public string Name { get; }

        public Resident(int id, string name)
        {
            ArgumentNullException.ThrowIfNull(name);

            Id = id;
            Name = name;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Resident resident)
            {
                if (Id == resident.Id && Name == resident.Name)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Id);
        }

        public override string ToString()
        {
            return $"Resident {Name} with Id {Id}";
        }
    }
}

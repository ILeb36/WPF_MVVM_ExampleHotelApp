using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFHotelRoomReservation.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            // If String.Empty sent as parameter, Binding mechanism will have to update every property in instance
            // So every property would be validated
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

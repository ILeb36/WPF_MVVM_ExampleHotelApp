using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFHotelRoomReservation.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        //private bool isChanged;

        //public bool IsChanged
        //{
        //    get => isChanged;
        //    set
        //    {
        //        if (value == isChanged) return;
        //        isChanged = value;
        //        OnPropertyChanged();
        //    }
        //}

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            //if (propertyName != nameof(IsChanged))
            //{
            //    IsChanged = true;
            //}

            // При отправке пустой строки механизм привязки будет вынужден обновить каждое свойство в экземпляре
            // Т.е. валидация будет проведена для каждого из свойств
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

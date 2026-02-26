using System.Windows.Input;

namespace WPFHotelRoomReservation.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected void OnCanExecuteChanged()
        {
            //informing interface that CanExecute property value changed and element can be locked/unlocked
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}

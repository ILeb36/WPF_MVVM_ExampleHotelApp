using WPFHotelRoomReservation.Stores;

namespace WPFHotelRoomReservation.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly NavigationStore navigationStore;

        public BaseViewModel CurrentViewModel => navigationStore.CurrentViewModel;

        public MainWindowViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            //Notifing MainVindow that property has changed
            //ContentControl (XAML) get item type from Content Binding = CurrentViewModel property here
            //According to type comparison from DataTemplate (XAML), one of the View will be selected as Grid inner content
            this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}

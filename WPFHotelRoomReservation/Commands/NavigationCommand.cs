using WPFHotelRoomReservation.Services;

namespace WPFHotelRoomReservation.Commands
{
    public class NavigationCommand : BaseCommand
    {
        private readonly NavigationService navigationService;

        public NavigationCommand(NavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            navigationService.Navigate();
        }
    }
}

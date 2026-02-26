using System.Windows.Input;
using WPFHotelRoomReservation.Commands;
using WPFHotelRoomReservation.Models;
using WPFHotelRoomReservation.Services;
using WPFHotelRoomReservation.Stores;

namespace WPFHotelRoomReservation.ViewModels
{
    public class ReserveRoomViewModel : BaseViewModel
    {
        private string resident;
        private int roomNumber;
        private int floorNumber;
        private DateTime startingDate = DateTime.Now;
        private DateTime endingDate = DateTime.Now.AddDays(7);

        public DateTime StartingDate
        {
            get => startingDate;
            set
            {
                startingDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndingDate
        {
            get => endingDate;
            set
            {
                endingDate = value;
                OnPropertyChanged();
            }
        }

        public string Resident
        {
            get => resident;
            set
            {
                resident = value;
                OnPropertyChanged();
            }
        }

        public int RoomNumber
        {
            get => roomNumber;
            set
            {
                roomNumber = value;
                OnPropertyChanged();
            }
        }

        public int FloorNumber
        {
            get => floorNumber;
            set
            {
                floorNumber = value;
                OnPropertyChanged();
            }
        }

        public ICommand ReserveCommand { get; }
        public ICommand NavigationCommand { get; }

        public ReserveRoomViewModel(Hotel hotel, NavigationService listOfReservationsViewNavigationService)
        {
            ReserveCommand = new ReserveCommand(this, hotel, listOfReservationsViewNavigationService);
            NavigationCommand = new NavigationCommand(listOfReservationsViewNavigationService);
        }
    }
}

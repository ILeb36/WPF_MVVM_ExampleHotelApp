using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFHotelRoomReservation.ViewModels
{
    public class ReserveRoomViewModel : BaseViewModel
    {
        private string resident;
        private int roomNumber;
        private int floorNumber;
        private DateTime startingDate;
        private DateTime endingDate;

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
        public ICommand CancelCommand { get; }

        public ReserveRoomViewModel()
        {
            
        }
    }
}

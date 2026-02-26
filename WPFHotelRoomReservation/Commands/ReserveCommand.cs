using System.Windows;
using WPFHotelRoomReservation.CustomExceptions;
using WPFHotelRoomReservation.Models;
using WPFHotelRoomReservation.Services;
using WPFHotelRoomReservation.ViewModels;

namespace WPFHotelRoomReservation.Commands
{
    public class ReserveCommand : BaseCommandAsync
    {
        private readonly ReserveRoomViewModel reserveRoomViewModel;
        private readonly Hotel hotel;
        private readonly NavigationService listOfReservationsViewNavigationService;

        public ReserveCommand(ReserveRoomViewModel reserveRoomViewModel, Hotel hotel, NavigationService listOfReservationsViewNavigationService)
        {
            this.reserveRoomViewModel = reserveRoomViewModel;
            this.hotel = hotel;
            this.listOfReservationsViewNavigationService = listOfReservationsViewNavigationService;
            reserveRoomViewModel.PropertyChanged += (sender, args) =>
            {
                //adding all properties I want to validate
                if (args.PropertyName == nameof(ReserveRoomViewModel.Resident) ||
                    args.PropertyName == nameof(ReserveRoomViewModel.FloorNumber) ||
                    args.PropertyName == nameof(ReserveRoomViewModel.RoomNumber))
                {
                    base.OnCanExecuteChanged();
                }
            };
        }

        public override bool CanExecute(object? parameter)
        {
            //properties validation
            return !string.IsNullOrEmpty(reserveRoomViewModel.Resident) &&
                reserveRoomViewModel.FloorNumber > 0 &&
                reserveRoomViewModel.RoomNumber > 0;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            Reservation reservation = new Reservation(
                new Room(reserveRoomViewModel.RoomNumber, reserveRoomViewModel.FloorNumber),
                reserveRoomViewModel.Resident,
                reserveRoomViewModel.StartingDate,
                reserveRoomViewModel.EndingDate);

            try
            {
                await hotel.ReserveRoom(reservation);
                MessageBox.Show("Reservations completed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                listOfReservationsViewNavigationService.Navigate();
            }
            catch (ReservationIntersectionException)
            {
                MessageBox.Show("Reservations for the selected time period are not permitted.", "Reservation error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to save reservation", "Reservation error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

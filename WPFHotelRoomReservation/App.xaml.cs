using System.Windows;
using WPFHotelRoomReservation.ViewModels;

namespace WPFHotelRoomReservation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel()
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}

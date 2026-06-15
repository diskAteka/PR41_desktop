using System.Windows;
using System.Windows.Controls;

namespace PR41.View
{
    public partial class Timer : Page
    {
        public Timer()
        {
            InitializeComponent();
            DataContext = new ViewModel.TimerViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.MainFrame.Navigate(new Stopwatch());
        }
    }
}

using System.Windows;
using System.Windows.Controls;

namespace PR41.View
{
    public partial class Stopwatch : Page
    {
        public Stopwatch()
        {
            InitializeComponent();
            DataContext = new ViewModel.StopwatchViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.MainFrame.Navigate(new Timer());    
        }
    }
}

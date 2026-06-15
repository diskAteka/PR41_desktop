using System.Windows;

namespace PR41
{
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            MainFrame.Navigate(new View.Stopwatch());
        }
    }
}
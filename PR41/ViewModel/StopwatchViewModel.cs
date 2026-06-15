using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace PR41.ViewModel
{
    public partial class StopwatchViewModel : ObservableObject
    {
        private readonly System.Diagnostics.Stopwatch stopwatch = new();
        private readonly DispatcherTimer _dispatcherTimer;

        #region Свойства для разметки

        [ObservableProperty]
        private TimeSpan _elapsedTime;

        [ObservableProperty]
        private bool _isRunning;

        [ObservableProperty]
        private ObservableCollection<string> _intervals = new();

        #endregion

        #region Команды

        [RelayCommand]
        private void StartStop()
        {
            if (IsRunning)
            {
                stopwatch.Stop();
                _dispatcherTimer.Stop();
                ElapsedTime = stopwatch.Elapsed;
                IsRunning = false;
            }
            else
            {
                stopwatch.Start();
                _dispatcherTimer.Start();
                IsRunning = true;
            }
        }

        [RelayCommand]
        private void Reset()
        {
            stopwatch.Reset();
            ElapsedTime = TimeSpan.Zero;
            _dispatcherTimer.Stop();
            IsRunning = false;
            Intervals.Clear();
        }


        [RelayCommand]
        private void CommitInterval() => Intervals.Add( ElapsedTime.ToString());

        #endregion

        #region Конструктор

        public StopwatchViewModel()
        {
            _dispatcherTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(10) };
            _dispatcherTimer.Tick += OnUiTimerTick;
        }

        #endregion


        #region Вспомогательные методы

        private void OnUiTimerTick(object? sender, EventArgs e) => ElapsedTime = stopwatch.Elapsed;

        #endregion
    }
}

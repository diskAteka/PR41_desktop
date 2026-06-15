using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PR41.ViewModel
{
    public partial class TimerViewModel : ObservableObject
    {
        private CancellationTokenSource _cts;
        private TimeSpan _remaningTime;

        #region

        [ObservableProperty]
        private TimeSpan _timerDuration;

        [ObservableProperty]
        private bool _isRunning;

        #endregion

        #region Команды

        [RelayCommand]
        private void StartStopTimer()
        {
            if (IsRunning)
            {
                _cts?.Cancel();
                IsRunning = false;             
            }
            else
            {
                IsRunning = true;
                _cts = new CancellationTokenSource();   
                _ = RunTimerAsync(_cts.Token);
            }
        }


        [RelayCommand]
        private void ResetTimer()
        {
            _cts?.Cancel();
            _remaningTime = TimeSpan.Zero;
            TimerDuration = TimeSpan.Zero;
            IsRunning = false;
        }

        #endregion

        #region Вспомогательные методы
        private async Task RunTimerAsync(CancellationToken token)
        {
            try
            {
                if (_remaningTime == TimeSpan.Zero)
                    _remaningTime = TimerDuration;

                for (TimeSpan i = _remaningTime; i > TimeSpan.Zero; i -= TimeSpan.FromMilliseconds(100))
                {
                    _remaningTime = i;
                    TimerDuration = i;
                    await Task.Delay(100, token);
                }

                _remaningTime = TimeSpan.Zero;
                TimerDuration = TimeSpan.Zero;
                IsRunning = false;
            }
            catch (TaskCanceledException) { }
        }

        #endregion
    }
}

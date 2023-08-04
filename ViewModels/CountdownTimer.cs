using System;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ShoppingListMobileApp1
{
    public class CountdownTimer
    {
        private readonly int durationSeconds;
        private Timer timer;
        private int remainingSeconds;

        public event EventHandler<int> CountdownTick;
        public event EventHandler CountdownCompleted;

        public int RemainingSeconds => remainingSeconds;

        public CountdownTimer(int durationSeconds)
        {
            this.durationSeconds = durationSeconds;
        }

        public async Task StartAsync()
        {
            remainingSeconds = durationSeconds;
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            await Task.Delay(durationSeconds * 1000);

            timer.Stop();
            CountdownCompleted?.Invoke(this, EventArgs.Empty);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            remainingSeconds--;
            CountdownTick?.Invoke(this, remainingSeconds);

            if (remainingSeconds == 0)
            {
                timer.Stop();
                CountdownCompleted?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}

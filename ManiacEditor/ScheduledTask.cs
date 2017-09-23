using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiacEditor
{
    class ScheduledTask
    {
        internal readonly Action Action;
        internal System.Timers.Timer Timer;
        internal EventHandler TaskComplete;

        public ScheduledTask(Action action, int timeoutMs)
        {
            Action = action;
            Timer = new System.Timers.Timer() { Interval = timeoutMs };
            Timer.Elapsed += TimerElapsed;
            Timer.Start();
        }

        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Timer.Stop();
            Timer.Elapsed -= TimerElapsed;
            Timer = null;

            Action();
            TaskComplete(this, EventArgs.Empty);
        }
    }

}

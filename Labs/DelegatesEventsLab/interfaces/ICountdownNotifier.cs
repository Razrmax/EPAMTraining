using DelegatesEventsLab.model;

namespace DelegatesEventsLab.interfaces
{
    interface ICountdownNotifier
    {
        public void Init(object sender, TimerEventArgs e);
        public void Run(object sender, TimerEventArgs e);
        public void End(object sender, TimerEventArgs e);
    }
}

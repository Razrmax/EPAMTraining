using DelegatesEventsLab.model;

namespace DelegatesEventsLab.interfaces
{
    interface ICountdownNotifier
    {
        public void Init();
        public void Run();
        public void End();
    }
}

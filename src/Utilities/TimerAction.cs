namespace ProjectGotham.Utilities
{
    public class TimerAction
    {
        public Action Action { get; }
        public double Interval { get; }
        public DateTime LastExecution { get; private set; } = DateTime.MinValue;

        public TimerAction(Action action, double intervalInSeconds)
        {
            Action = action;
            Interval = intervalInSeconds;
        }

        public void TryExecute(DateTime currentTime)
        {
            if ((currentTime - LastExecution).TotalSeconds >= Interval)
            {
                Action.Invoke();
                LastExecution = currentTime;
            }
        }
    }
}

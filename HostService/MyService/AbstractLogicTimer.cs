namespace MyService
{
    public abstract class LogicTimer
    {
        protected int Increment = 1;
        public int LocalTime { get; protected set; }

        public LogicTimer()
        {
            LocalTime = 0;
        }

        public void ChangeMaxTime(int time)
        {
            if (time >= LocalTime)
            {
                LocalTime = time;
                IncrementLocalTime();
            }

        }

        public void IncrementLocalTime()
        {
            LocalTime += Increment;
        }
        public abstract void GetRequest(int time, int id);
        public abstract void Reply(int id, int idFrom);
    }
}

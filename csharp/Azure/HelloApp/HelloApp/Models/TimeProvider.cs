namespace HelloApp.Models
{
    public class TimeProvider : ITimeProvider
    {
        private readonly ITime _time;

        public TimeProvider(ITime time)
        {
            _time = time;
        }

        public string GetTime(string format)
        {
            return _time.GetTime(format);
        }
    }
}
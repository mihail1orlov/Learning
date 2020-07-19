using System;

namespace HelloApp
{
    class TimeProvider : ITimeProvider
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("T");
        }
    }
}
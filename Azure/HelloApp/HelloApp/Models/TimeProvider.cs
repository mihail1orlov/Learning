using System;

namespace HelloApp.Models
{
    class TimeProvider : ITimeProvider
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("T");
        }
    }
}
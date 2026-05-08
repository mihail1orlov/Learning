using System;

namespace HelloApp.Models
{
    public class Time : ITime
    {
        public string GetTime(string format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}
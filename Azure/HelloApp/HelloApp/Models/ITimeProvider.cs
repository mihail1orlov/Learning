﻿namespace HelloApp.Models
{
    public interface ITimeProvider
    {
        string GetTime(string format);
    }
}
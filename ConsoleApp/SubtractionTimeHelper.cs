using System;

namespace ConsoleApp
{
    public class SubtractionTimeHelper
    {
        public static TimeSpan SubtractTimeInterval(TimeSpan input, TimeSpan interval)
        {
            TimeSpan result = input.Subtract(interval);

            int days;
            int hours = result.Hours;
            int minutes = result.Minutes;
            int seconds = result.Seconds;

            if (hours <= 0)
            {
                hours = result.Hours + Constants.HOURS_DAY;
            }

            if (result.Minutes <= 0)
            {
                minutes = result.Minutes + Constants.MINUTES_HOUR;
                hours--;
            }

            if (result.Seconds <= 0)
            {
                seconds = result.Seconds + Constants.SECONDS_MINUTE;
                minutes--;
            }

            result = new TimeSpan(hours, minutes, seconds);
            days = result.Add(interval).Days;

            return new TimeSpan(days, hours, minutes, seconds);
        }
    }
}

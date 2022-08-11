using System;
using System.Globalization;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StartSubtractTimeInterval();
        }


        public static void StartSubtractTimeInterval()
        {
            Console.WriteLine("Don't forget separate by colon :)");
            Console.WriteLine("*** Input ***");
            Console.WriteLine("24 Hour Time of Day ->");
            Console.WriteLine("HH:MM:SS");
            string timeOfDay = Console.ReadLine();

            Console.WriteLine("*** Time Interval ***");
            Console.WriteLine("HH:MM:SS");
            string timeInterval = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Input {0}  | Interval {1}", timeOfDay, timeInterval);

            TimeSpan result = SubtractionTimeHelper.SubtractTimeInterval(ValidateFormatTime(timeOfDay), ValidateFormatTime(timeInterval));

            Console.WriteLine("*** Final Result ***");
            Console.WriteLine("Hours | Mins | Secs | Days");
            Console.WriteLine("  {0}  |   {1} |   {2} |   {3}",
                result.Hours,
                result.Minutes,
                result.Seconds,
                result.Days);

            Console.ReadKey();
        }

        public static TimeSpan ValidateFormatTime(string valueTime)
        {
            int[] ints = Array.ConvertAll(valueTime.Split(':'), item => int.Parse(item));
            TimeSpan timeSpan = new TimeSpan(ints[0], ints[1], ints[2]);
            return timeSpan;
        }

        public static TimeSpan ParseFormatTime(string formatTime)
        {
            CultureInfo provider = CultureInfo.CurrentCulture;
            string format = "HH:mm:ss";

            try
            {
                TimeSpan ts = TimeSpan.ParseExact(formatTime, format, provider);
                return ts;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("{0}: Bad Format", formatTime);
                throw new FormatException(ex.Message);
            }
        }
    }
}

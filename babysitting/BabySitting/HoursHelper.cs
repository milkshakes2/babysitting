using System;
using System.Collections.Generic;

namespace BabySitting
{
    public static class HoursHelper
    {
        public const int _hoursInDay = 24;
        private const string _invalidHourInDayMsg = "Input invalid. Must be a valid hour within a day.";
        public static List<int> CalculateHoursRange(int start, int end)
        {
            int counter = start;
            List<int> range = new List<int>();

            ValidateHourInDay(nameof(start), start);
            ValidateHourInDay(nameof(end), end);

            while (counter != end)
            {
                range.Add(counter);
                counter++;
                if (counter == _hoursInDay)
                    counter = 0;
            }
            range.Add(end);
            return range;
        }

        private static void ValidateHourInDay(string paramName, int input)
        {
            if (input < 0 || input > _hoursInDay - 1)
                throw new ArgumentOutOfRangeException(paramName, _invalidHourInDayMsg);
        }
    }
}

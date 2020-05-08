using System;
using System.Collections.Generic;
using System.Linq;

namespace BabySitting
{
    public class Shift
    {
        private const string _invalidShiftHoursMsg = "Input invalid. Worked hours must be within available shift hours.";
        public int FirstHour { get; private set; }
        public int LastHour { get; private set; }
        public List<int> shiftHours { get; private set; }

        public Shift(int shiftStart, int shiftEnd)
        {
            shiftHours = HoursHelper.CalculateHoursRange(shiftStart, shiftEnd);
            FirstHour = shiftStart;
            LastHour = shiftEnd;
        }

        public int CalculatePay(FamilyRate rate)
        {
            List<int> workedHours = HoursHelper.CalculateHoursRange(FirstHour, LastHour);

            int pay = 0;

            foreach (int hour in workedHours)
                pay += rate.HourlyRates[hour];

            return pay;
        }

        public int CalculatePay(int hour, FamilyRate rate)
        {
            ValidateWorkedHours(new List<int>() { hour });
            int pay = rate.HourlyRates[hour];

            return pay;
        }

        public int CalculatePay(int shiftStart, int shiftEnd, FamilyRate rate)
        {
            List<int> workedHours = HoursHelper.CalculateHoursRange(shiftStart, shiftEnd);
            ValidateWorkedHours(workedHours);

            int pay = 0;

            foreach (int hour in workedHours)
                pay += rate.HourlyRates[hour];

            return pay;
        }

        private void ValidateWorkedHours(List<int> workedHours)
        {
            var outOfHours = workedHours.Except(shiftHours).ToList();
            if (outOfHours.Any())
                throw new ArgumentOutOfRangeException(nameof(workedHours), _invalidShiftHoursMsg);
        }
    }
}

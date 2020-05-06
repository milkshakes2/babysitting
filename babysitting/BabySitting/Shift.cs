using System;
using System.Collections.Generic;
using System.Linq;

namespace BabySitting
{
    public class Shift
    {
        private const string _invalidShiftHoursMsg = "Input invalid. Worked hours must be within available shift hours.";
        public List<int> shiftHours { get; private set; }
        
        public Shift(int shiftStart, int shiftEnd) : base()
        {
            shiftHours = HoursHelper.CalculateHoursRange(shiftStart, shiftEnd);
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

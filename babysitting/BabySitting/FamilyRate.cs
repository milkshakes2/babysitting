using System.Collections.Generic;

namespace BabySitting
{
    public class FamilyRate
    {
        public int[] HourlyRates { get; private set; }

        public FamilyRate()
        {
            HourlyRates = new int[HoursHelper._hoursInDay];
        }
        
        public void SetHourlyRates(int rateStart, int rateEnd, int rate)
        {
            List<int> hours = HoursHelper.CalculateHoursRange(rateStart, rateEnd);
            foreach (int hour in hours)
                HourlyRates[hour] = rate;
        }
    }
}

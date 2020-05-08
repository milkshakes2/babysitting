using System;

namespace BabySitting
{
    class Program
    {
        static void Main(string[] args)
        {
            // The time ranges are the same as the babysitter (5pm through 3am--i.e. no later than 4am)
            Shift shift = new Shift(17, 3);

            // Family A pays $15 per hour before 11pm, and $20 per hour the rest of the night
            FamilyRate familyA = new FamilyRate();
            familyA.SetHourlyRates(shift.FirstHour, 22, 15);
            familyA.SetHourlyRates(23, shift.LastHour, 20);

            // Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night
            FamilyRate familyB = new FamilyRate();
            familyB.SetHourlyRates(shift.FirstHour, 21, 12);
            familyB.SetHourlyRates(17, 21, 12);
            familyB.SetHourlyRates(0, shift.LastHour, 16);

            // Family C pays $21 per hour before 9pm, then $15 the rest of the night
            FamilyRate familyC = new FamilyRate();
            familyC.SetHourlyRates(shift.FirstHour, 20, 21);
            familyC.SetHourlyRates(21, shift.LastHour, 15);

            Console.WriteLine("BabySitting Calculator Output");
            Console.WriteLine("Family A pays $15 per hour before 11pm, and $20 per hour the rest of the night");
            Console.WriteLine($"Full Shift:        ${shift.CalculatePay(familyA)}");
            Console.WriteLine($"17 thru 22:        ${shift.CalculatePay(17, 22, familyA)}");
            Console.WriteLine($"23 thru  3:        ${shift.CalculatePay(23, 3, familyA)}");
            Console.WriteLine($"1 hour shift @ 17: ${shift.CalculatePay(17, familyA)}");
            Console.WriteLine($"1 hour shift @ 23: ${shift.CalculatePay(23, familyA)}");
            Console.WriteLine();
            Console.WriteLine("Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night");
            Console.WriteLine($"Full Shift:        ${shift.CalculatePay(familyB)}");
            Console.WriteLine($"17 thru 21:        ${shift.CalculatePay(17, 21, familyB)}");
            Console.WriteLine($"22 thru 23:        ${shift.CalculatePay(22, 23, familyB)}");
            Console.WriteLine($" 0 thru  3:        ${shift.CalculatePay(0, 3, familyB)}");
            Console.WriteLine($"1 hour shift @ 17: ${shift.CalculatePay(17, familyB)}");
            Console.WriteLine($"1 hour shift @ 22: ${shift.CalculatePay(22, familyB)}");
            Console.WriteLine($"1 hour shift @  0: ${shift.CalculatePay(0, familyB)}");
            Console.WriteLine();
            Console.WriteLine("Family C pays $21 per hour before 9pm, then $15 the rest of the night");
            Console.WriteLine($"Full Shift:        ${shift.CalculatePay(familyC)}");
            Console.WriteLine($"17 thru 21:        ${shift.CalculatePay(17, 21, familyC)}");
            Console.WriteLine($"22 thru 23:        ${shift.CalculatePay(22, 23, familyC)}");
            Console.WriteLine($" 0 thru  3:        ${shift.CalculatePay(0, 3, familyC)}");
            Console.WriteLine($"1 hour shift @ 17: ${shift.CalculatePay(17, familyC)}");
            Console.WriteLine($"1 hour shift @ 22: ${shift.CalculatePay(22, familyC)}");
            Console.WriteLine($"1 hour shift @  0: ${shift.CalculatePay(0, familyC)}");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabySitting
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("**************************************");
            Console.WriteLine("Welcome to BabySitting Rate Calculator");
            Console.WriteLine("**************************************");
                        
            bool retry = true;
            int shiftStart = 0, shiftEnd = 0;
            //string exitMessage = "Exiting BabySitting Rate Calculator. Goodbye.";
            do
            {
                Console.Write("Enter shift start hour (0 to 23): ");
                string shiftStartInput = Console.ReadLine();
                if (int.TryParse(shiftStartInput, out shiftStart) && shiftStart > -1 && shiftStart < 24)
                    retry = false;
                else
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 23.");
            } while (retry);

            retry = true;

            do
            {
                Console.Write("Enter shift end hour (0 to 23): ");
                string shiftEndInput = Console.ReadLine();
                if (int.TryParse(shiftEndInput, out shiftEnd) && shiftEnd > -1 && shiftEnd < 24)
                    retry = false;
                else
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 23.");
            } while (retry);


        }

        static bool ProgramExit(string input)
        {
            if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
                return true;
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    public class DriverActions
    {
        public static bool IsTesting = false;

        public static void Rest(Driver driver)
        {
            driver.Tiredness = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The driver has rested and is now refreshed. Press Enter to continue.");
            Console.ResetColor();
            if (!IsTesting) Console.ReadKey();
        }

        public static void CheckTiredness(Driver driver)
        {
            if (driver.Tiredness >= 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The driver is extremely tired! It is very dangerous to keep driving. REST! Press Enter to continue.");
                Console.ResetColor();
                if (!IsTesting) Console.ReadKey();
            }
            else if (driver.Tiredness >= 70)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("The driver is getting tired and needs to take a break. Press Enter to continue.");
                Console.ResetColor();
                if (!IsTesting) Console.ReadKey();
            }
        }
    }
}

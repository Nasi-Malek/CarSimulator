using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    public class Status
    {
        public static bool IsTesting = false;

        public void PrintStatus(Car car, Driver driver)
        {
            Console.WriteLine($"\nStatus:");
            Console.WriteLine($"Direction: {car.Direction}");
            Console.WriteLine($"Fuel: {car.Fuel}%");
            Console.WriteLine($"Fatigue: {driver.Tiredness}%");
        }
    }
}

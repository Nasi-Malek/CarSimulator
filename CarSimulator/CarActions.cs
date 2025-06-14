using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    public class CarActions
    {
        public static bool IsTesting = false;

        public static void Drive(Car car, Driver driver)
        {
            if (car.Fuel <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fuel is empty! You must refuel. Press Enter to continue.");
                Console.ResetColor();
                if (!IsTesting) Console.ReadKey();
                return;
            }

            car.Fuel -= 10;
            driver.Tiredness += 10;

            Console.WriteLine($"The car moves forward and is now facing {car.Direction}. Press Enter to continue.");
            DriverActions.CheckTiredness(driver);
            if (!IsTesting) Console.ReadKey();
        }

        public static void TurnLeft(Car car, Driver driver)
        {
            if (car.Fuel <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fuel is empty! You must refuel. Press Enter to continue.");
                Console.ResetColor();
                if (!IsTesting) Console.ReadKey();
                return;
            }

            car.Direction = car.Direction switch
            {
                "North" => "West",
                "West" => "South",
                "South" => "East",
                "East" => "North",
                _ => car.Direction
            };

            car.Fuel -= 5;
            driver.Tiredness += 5;

            Console.WriteLine($"The car turns left and is now facing {car.Direction}. Press Enter to continue.");
            DriverActions.CheckTiredness(driver);
            if (!IsTesting) Console.ReadKey();
        }

        public static void TurnRight(Car car, Driver driver)
        {
            if (car.Fuel <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fuel is empty! You must refuel. Press Enter to continue.");
                Console.ResetColor();
                if (!IsTesting) Console.ReadKey();
                return;
            }

            car.Direction = car.Direction switch
            {
                "North" => "East",
                "East" => "South",
                "South" => "West",
                "West" => "North",
                _ => car.Direction
            };

            car.Fuel -= 5;
            driver.Tiredness += 5;

            Console.WriteLine($"The car turns right and is now facing {car.Direction}. Press Enter to continue.");
            DriverActions.CheckTiredness(driver);
            if (!IsTesting) Console.ReadKey();
        }

        public static void Reverse(Car car, Driver driver)
        {
            if (car.Fuel <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fuel is empty! You must refuel. Press Enter to continue.");
                Console.ResetColor();
                if (!IsTesting) Console.ReadKey();
                return;
            }

            car.Fuel -= 5;
            driver.Tiredness += 5;

            Console.WriteLine($"The car is reversing and is now facing {car.Direction}. Press Enter to continue.");
            DriverActions.CheckTiredness(driver);
            if (!IsTesting) Console.ReadKey();
        }

        public void Refuel(Car car, Driver driver)
        {
            car.Fuel = 100;
            driver.Tiredness += 5;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The car is now fully refueled. Press Enter to continue.");
            Console.ResetColor();

            if (!IsTesting) Console.ReadKey();
        }
    }
}


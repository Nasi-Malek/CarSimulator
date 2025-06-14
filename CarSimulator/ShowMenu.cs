using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSimulator
{
    public class ShowMenu
    {
        public static void PrintMenu()
        {
            Console.WriteLine("\nAvailable commands:");
            Console.WriteLine("1. Move forward");
            Console.WriteLine("2. Turn left");
            Console.WriteLine("3. Turn right");
            Console.WriteLine("4. Reverse");
            Console.WriteLine("5. Refuel");
            Console.WriteLine("6. Rest");
            Console.WriteLine("7. Exit");
            Console.Write("Choose a command: ");
        }
    }
}

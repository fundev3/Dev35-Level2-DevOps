using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevVehicle35_Motors.App
{
    using DevVehicle35_Motors.Models;
    internal static class MiniBusInteraction
    {
        public static MiniBus CreateMinibus()
        {
            int capacity;
            string input;
            do
            {
                Console.WriteLine("How many passenger does it have?(min=1, max=6)");
                input = Console.ReadLine() ?? "0";
                capacity = int.Parse(input);
            }while (capacity < 1 || capacity > 6);
            do
            {
                Console.WriteLine("Does it have automatic doors? Y/N");
                input = (Console.ReadLine() ?? "N")
                               .ToString()
                               .ToUpper();
                if (input == "Y" || input == "N")
                {
                    return new MiniBus(capacity, input == "Y" ? true : false);
                }
            } while (true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevVehicle35_Motors.App
{
    using DevVehicle35_Motors.Models;

    internal class QuadInteraction
    {
        internal static void BuildQuad()
        {
            Console.WriteLine("Let's start construct a Quad!");
            Console.WriteLine("What Type of fuel should it have?(Gasoline/Diesel)");
            string fuel = fuelValidator(Console.ReadLine());
            Console.WriteLine("Do you want include a helmet for this Quad?(yes/no)");
            string res= resValidator(Console.ReadLine());
            bool helmet = res == "yes";
            Console.WriteLine("How many horse power should it have?(1200/1400)");
            int power = int.Parse(Console.ReadLine());
            Quad quad = new Quad();
            quad.DeterminePrice(fuel, helmet, power);
            Console.WriteLine("The Quad is ready!");
            Console.WriteLine(quad.GetDescription());
        }
        private static string fuelValidator(string fuel)
        {
            if (fuel == "Gasoline" || fuel == "Diesel")
            {
                return fuel;
            }
            else
            {
                Console.WriteLine("Please enter a valid option (Gasoline/Diesel): ");
                fuel = fuelValidator(Console.ReadLine());
                return fuel;
            }
        }

        private static string resValidator(string res)
        {
            if (res == "yes" || res == "no")
            {
                return res;
            }
            else
            {
                Console.WriteLine("Please enter a valid option (yes/no): ");
                res = resValidator(Console.ReadLine());
                return res;
            }
        }

    }
}

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
            string fuel = Console.ReadLine();
            Console.WriteLine("Do you want include a helmet for this Quad?(yes/no)");
            string res= Console.ReadLine();
            bool helmet = res == "yes";
            Console.WriteLine("How many horse power should it have?(1200/1400)");
            int power = int.Parse(Console.ReadLine());
            Quad quad = new Quad();
            quad.DeterminePrice(fuel, helmet, power);
            Console.WriteLine("The Quad is ready!");
            Console.WriteLine(quad.GetDescription());
        }
    }
}

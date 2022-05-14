using DevVehicle35_Motors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevVehicle35_Motors.App
{
    internal class BusInteraction
    {
        internal static void BuildBus() 
        {
            Bus busan = new Bus();
            Console.WriteLine("Wish you add Online Entertainment?");
            Console.WriteLine("1. Yes   2. No");
            int resp = int.Parse(Console.ReadLine());

            if (resp == 1) 
            {
                busan.AddEntertainment();
            }
            else
            {
                
            }
        }
    }
}

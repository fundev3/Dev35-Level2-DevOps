using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevVehicle35_Motors.Models;

namespace DevVehicle35_Motors.App
{
    internal class BusInteraction
    {
        internal static void BuildBus()
        {
            Bus busan = new ();
            if (ValidateInput("Wish you add Online Entertainment?"))
            {
                busan.AddEntertainment();
                Console.Clear();
            }

            if (ValidateInput("Wish you add a bathroom in the bus?"))
            {
                busan.AddBathroom();
                Console.Clear();
            }

            if (ValidateInput("Wish you add more seats?"))
            {
                Console.WriteLine("Enter the amount of seat you wish to add");
                int seatAmount = int.Parse(Console.ReadLine());
                busan.AddSeats(seatAmount);
                Console.Clear();
            }

            Console.WriteLine(busan.GetDescription());
            Console.WriteLine("\nCONGRATULATION YOU HAVE BUILD A BUS SUCESSFULLY");
        }

        private static bool ValidateInput(string message)
        {
            int resp = 0;
            do
            {
                Console.WriteLine("\n=========================");
                Console.WriteLine("|     Building a bus    |");
                Console.WriteLine("=========================\n");
                Console.WriteLine(message);
                Console.WriteLine("1. Yes   2. No");
                string input = Console.ReadLine() ?? "0";
                if (input.Length != 1 || !char.IsNumber(char.Parse(input)) || (int.Parse(input) != 1 && int.Parse(input) != 2))
                {
                    Console.Clear();
                    Console.WriteLine("Please type a valid input");
                }
                else
                {
                    resp = int.Parse(input);
                }
            }
            while (resp != 1 && resp != 2);
            return resp == 1;
        }
    }
}

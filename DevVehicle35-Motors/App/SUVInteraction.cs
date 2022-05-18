using DevVehicle35_Motors.Enum;
using DevVehicle35_Motors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevVehicle35_Motors.App
{
    internal class SUVInteraction
    {
        internal static void BuildSUV()
        {
            int colorInt = 0;
            do
            {
                Console.WriteLine("Please select a color: ");
                PrintColors();
                string? colorString = Console.ReadLine();
                colorInt = ValidateInput(colorString ?? string.Empty);
            } while (!(colorInt > 0 && colorInt < 11));
            //SUV suv = new SUV();
            Console.Clear();
            //Console.WriteLine(bus.GetDescription());
            Console.WriteLine("\nCONGRATULATION YOU HAVE BUILD A BUS SUCESSFULLY");
        }

        private static void PrintColors()
        {
            Console.WriteLine($"1. {Colors.White}");
            Console.WriteLine($"2. {Colors.Black}");
            Console.WriteLine($"3. {Colors.Blue}");
            Console.WriteLine($"4. {Colors.Red}");
            Console.WriteLine($"5. {Colors.Green}");
            Console.WriteLine($"6. {Colors.Yellow}");
            Console.WriteLine($"7. {Colors.Silver}");
            Console.WriteLine($"8. {Colors.Pink}");
            Console.WriteLine($"9. {Colors.Orange}");
            Console.WriteLine($"10. {Colors.Purple}");
        }

        private static int ValidateInput(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return 0;
        }
    }
}

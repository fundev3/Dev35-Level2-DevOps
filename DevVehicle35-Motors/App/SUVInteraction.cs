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
            int tractionInt = 0;
            int numberOfDoors = 0;
            do
            {
                Console.WriteLine("Please select a color: ");
                PrintColors();
                string? colorString = Console.ReadLine();
                colorInt = ValidateInput(colorString ?? string.Empty);
            }
            while (!(colorInt > 0 && colorInt < 11));

            do
            {
                Console.WriteLine("Please select a type of traction: ");
                PrintTractions();
                string? tractionString = Console.ReadLine();
                tractionInt = ValidateInput(tractionString ?? string.Empty);
            }
            while (!(tractionInt > 0 && tractionInt < 3));

            do
            {
                Console.WriteLine("Please select number of doors: ");
                PrintDoorOptions();
                string? numberOfDoorsString = Console.ReadLine();
                numberOfDoors = ValidateInput(numberOfDoorsString ?? string.Empty);
            }
            while (!(numberOfDoors > 0 && numberOfDoors < 3));

            SUV suv = new SUV((Colors)(colorInt - 1), (TypeOfTraction)(tractionInt - 1), (numberOfDoors == 1) ? 2 : 4);
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine(suv.GetDescription());
            Console.WriteLine("===============================");
            Console.WriteLine("\nCONGRATULATION YOU HAVE BUILD A SUV SUCESSFULLY");
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

        private static void PrintTractions()
        {
            Console.WriteLine($"1. {TypeOfTraction.TwoWheel}");
            Console.WriteLine($"2. {TypeOfTraction.FourWheel}");
        }

        private static void PrintDoorOptions()
        {
            Console.WriteLine($"1. 2");
            Console.WriteLine($"2. 4");
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

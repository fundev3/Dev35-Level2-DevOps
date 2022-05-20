using DevVehicle35_Motors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevVehicle35_Motors.App
{
    class CarInteraction
    {
        public static void BuildCar() {
            
            SelectColorView();
            int optionColor = ReadOption();
            string colorCar = DetermineColor(optionColor);
            
            SelectNumberDoorsView();
            int optionDoors = ReadOption();
            int doorsCar = DetermineNumberDoors(optionDoors);

            //Create car
            Car myCar = new Car(colorCar,doorsCar);
            //Price 
            Console.WriteLine(myCar.DeterminePrice());
            //Description
            Console.WriteLine(myCar.GetDescription());
            
        }
        private static void SelectColorView() {

            Console.WriteLine("======= Select a Car color ===============================");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Red");
            Console.WriteLine("2. Green");
            Console.WriteLine("3. Orange");
            Console.WriteLine("4. White");
            Console.WriteLine("======================================");
        }

        private static void SelectNumberDoorsView()
        {
            Console.WriteLine("======= Select Number of Doors =======================");
            Console.WriteLine("======================================");
            Console.WriteLine("1. 2 Doors");
            Console.WriteLine("2. 4 Doors");
            Console.WriteLine("======================================");
        }

        private static string DetermineColor(int optionColor)
        {
            if (optionColor == 1) {
                return "Red";
            } else if (optionColor == 2) {
                return "Green";
            } else if (optionColor == 3)
            {
                return "Orange";
            } else if (optionColor == 4)
            {
                return "White";
            }

            return "Red";
        }

        private static int DetermineNumberDoors(int optionDoors)
        {
            if (optionDoors == 1)
            {
                return 2;
            }
            else if (optionDoors == 2)
            {
                return 4;
            }

            return 2;
        }

        private static int ReadOption() {
            string selection = Console.ReadLine();
            return int.Parse(selection);
        }

    }
}

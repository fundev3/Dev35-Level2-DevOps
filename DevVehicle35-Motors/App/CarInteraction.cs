using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carproject.App
{
    class CarInteraction
    {
        public void BuildCar() {
            
            this.SelectColorView();
            int optionColor = this.ReadOption();
            string colorCar = this.DetermineColor(optionColor);
            
            this.SelectNumberDoors();
            int optionDoors = this.ReadOption();
            int doorsCar = this.DetermineNumberDoors(optionDoors);

            //create car
            //Car car = new Car();
            //car.selectColor(colorCar);
            //car.selectNumberDoors(doorsCar);
            //price 
            //car.showPrice();
            //description
            //car.showDescription();
        }
        private void SelectColorView() {

            Console.WriteLine("======= Select a Car color ===============================");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Red");
            Console.WriteLine("2. Green");
            Console.WriteLine("3. Orange");
            Console.WriteLine("4. White");
            Console.WriteLine("======================================");
        }

        private void SelectNumberDoors()
        {
            Console.WriteLine("======= Select Number of Doors =======================");
            Console.WriteLine("======================================");
            Console.WriteLine("1. 2 Doors");
            Console.WriteLine("2. 4 Doors");
            Console.WriteLine("======================================");
        }

        private string DetermineColor(int optionColor) {
            if (optionColor == 1) {
                return "Red";
            } else if (optionColor == 2) {
                return "Green";
            } else if (optionColor == 3)
            {
                return "Orange";
            } else if (optionColor == 2)
            {
                return "White";
            }

            return "Red";
        }

        private int DetermineNumberDoors(int optionColor)
        {
            if (optionColor == 1)
            {
                return 2;
            }
            else if (optionColor == 2)
            {
                return 4;
            }

            return 2;
        }

        private int ReadOption() {
            string selection = Console.ReadLine();
            return int.Parse(selection);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevVehicle35_Motors.Interface
{
    internal class Tractor : IMainVehicle
    {
        public decimal Price { get; set; }

        public int Speed { get; set; }

        public int HorsePower { get; set; }

        public int capacity { get; set; }

        public int NumberOfWheels { get; set; }

        private bool doesItHaveWarningLights;

        public Tractor(int horsePower)
        {
            this.Price = 120000;
            this.Speed = 80;
            this.DefineHorsePower(horsePower);
            this.Capacity = 1;
            this.NumberOfWheels = 4;
            this.doesItHaveWarningLights = false;
        }

        public string GetDescription()
        {
            string description = "\n---------- TRACTOR DESCRIPTION ----------\n" +
            "\n" +
            "Speed: " + this.Speed +
            "\nHorse power: " + this.HorsePower +
            "\nCapacity: " + this.Capacity +
            "\nNumber of wheels: " + this.NumberOfWheels;

            if (this.doesItHaveWarningLights)
            {
                description += "\n" + "Warning lighths: Yes";
            }

            description += "\n" + "Final price: " + this.Price;
            return description;
        }

        public void DefineHorsePower(int horsePower)
        {
                this.HorsePower = horsePower;
                this.Price = this.Price + (horsePower / 10);
        }

        public void SelectWarningLigths(int warningLigthsNumber)
        {
            if (warningLigthsNumber == 1)
            {
                this.doesItHaveWarningLights = true;
                this.Price = this.Price + 100;
            }
        }

        public void ShowHorsePower()
        {
            Console.WriteLine("horse Power: {0}", this.HorsePower);
        }

        public void DeterminePrice()
        {
            Console.WriteLine("Total price: {0}", this.Price);
        }
    }
}
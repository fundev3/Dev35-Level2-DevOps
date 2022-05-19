using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevVehicle35_Motors.Interface
{
    internal class Tractor : iMainVehicle
    {
        public decimal price { get; set; }

        public int speed { get; set; }

        public int horsePower { get; set; }

        public int capacity { get; set; }

        public int numberOfWheels { get; set; }

        private bool doesItHaveWarningLights;

        public Tractor(int horsePower)
        {
            this.price = 120000;
            this.speed = 80;
            this.DefineHorsePower(horsePower);
            this.capacity = 1;
            this.numberOfWheels = 4;
            this.doesItHaveWarningLights = false;
        }

        public string GetDescription()
        {
            string description = "\n---------- TRACTOR DESCRIPTION ----------\n" +
            "\n" +
            "Speed: " + this.speed +
            "\nHorse power: " + this.horsePower +
            "\nCapacity: " + this.capacity +
            "\nNumber of wheels: " + this.numberOfWheels;

            if (this.doesItHaveWarningLights)
            {
                description += "\n" + "Warning lighths: Yes";
            }

            description += "\n" + "Final price: " + this.price;
            return description;
        }

        public void DefineHorsePower(int horsePower)
        {
                this.horsePower = horsePower;
                this.price = this.price + (horsePower / 10);
        }

        public void SelectWarningLigths(int warningLigthsNumber)
        {
            if (warningLigthsNumber == 1)
            {
                this.doesItHaveWarningLights = true;
                this.price = this.price + 100;
            }
        }

        public void ShowHorsePower()
        {
            Console.WriteLine("horse Power: {0}", this.horsePower);
        }

        public void DeterminePrice()
        {
            Console.WriteLine("Total price: {0}", this.price);
        }
    }
}
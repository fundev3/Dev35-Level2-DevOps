using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevVehicle35_Motors
{
    internal class MiniBus : IMainVehicle
    {
        public decimal Price { get; set; }
        public int Speed { get  ; set ; }
        public int HorsePower { get  ; set  ; }
        public int Capacity { get  ; set  ; }
        public int NumberOfWheels { get  ; set  ; }

        private bool automaticDoor;
        const int passengersCost = 50;
        const int automaticDoorCost = 300;
        public MiniBus()
        {
            Speed = 200;
            HorsePower = 1400;
            Price = 20000;
            NumberOfWheels = 4;
            automaticDoor = false;

            Console.WriteLine("How many passenger does it have?");
            this.capacity(int.Parse(Console.ReadLine()));

            Console.WriteLine("does it have automatic doors? Y/N");
            string automaticDoors = Console.ReadLine();
            if (automaticDoors == "Y") this.AddAutomaticDoor();

            Console.WriteLine(GetDescription());
        }
        public decimal GetPrice()
        {
            return Price;
        }
        public void AddAutomaticDoor()
        {
            automaticDoor = true;
            Price += automaticDoorCost;
        }
        public void capacity(int passengers)
        {
            Capacity = passengers;
            Price += (passengers * passengersCost);
        }
        public string GetDescription()
        {
            return $"The car is an: MiniBus\n " +
                   $"It " + (automaticDoor ? "has" : "has not") + " automaticdoor\n" +
                   $"Capacity: {passengersCost} * {Capacity} \n" +
                   $"Number of wheels: {NumberOfWheels}\n" +
                   $"Horse Power:  {HorsePower}\n" +
                   $"Speed: {Speed}\n" +
                   $"Price: {Price}";
        }
    }
}

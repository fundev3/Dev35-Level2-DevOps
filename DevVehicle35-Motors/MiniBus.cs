﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevVehicle35_Motors
{
    internal class MiniBus : IVehicleBased
    {
        public decimal price { get ; set; }
        public int speed { get; set; }
        public int horsePower { get ; set; }
        public int capacity { get; set; }
        public int numberOfWheels { get; set; }
        private bool automaticDoor;
        const int passengersCost = 50;
        const int automaticDoorCost = 300;
        public MiniBus()
        {
            speed = 200;
            horsePower = 1400;
            price = 20000;
            numberOfWheels = 4;
            automaticDoor = false;

            Console.WriteLine("How many passenger does it have?");
            this.Capacity(int.Parse(Console.ReadLine()));

            Console.WriteLine("does it have automatic doors? Y/N");
            string automaticDoors = Console.ReadLine();
            if (automaticDoors == "Y") this.AddAutomaticDoor();

            Console.WriteLine(GetDescription());
        }
        public decimal GetPrice()
        {
            return price;
        }
        public void AddAutomaticDoor()
        {
            automaticDoor = true;
            price += automaticDoorCost;
        }
        public void Capacity(int passengers)
        {
            capacity = passengers;
            price += (passengers * passengersCost);
        }
        public string GetDescription()
        {
            return $"The car is an: MiniBus\n " +
                   $"It " + (automaticDoor ? "has" : "has not") + " automaticdoor\n" +
                   $"Capacity: {passengersCost} * {capacity} \n" +
                   $"Number of wheels: {numberOfWheels}\n" +
                   $"Horse Power:  {horsePower}\n" +
                   $"Speed: {speed}\n" +
                   $"Price: {price}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevVehicle35_Motors.Models
{
    internal class Bus : IMainVehicle
    {
        public decimal price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int horsePower { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int capacity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int numberOfWheels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private bool hasEntertaintament;
        private bool hasBathroom;

        internal bool HasEntertainment { get => hasEntertaintament; private set => hasEntertaintament = value; }
        internal bool HasBathroom { get => hasBathroom; private set => hasBathroom = value; }

        internal Bus()
        {
            speed = 200;
            horsePower = 10000;
            price = 60000;
            capacity = 20;
            numberOfWheels = 4;
        }

        private void IncreasePrice(decimal increase)
        {
            this.price += increase;
        }

        internal void AddEntertainment()
        {
            this.hasEntertaintament = true;
            this.IncreasePrice(300);
        }

        internal void AddBathroom()
        {
            this.hasBathroom = true;
            this.IncreasePrice(500);
        }
        internal void AddSeats(int seats)
        {
            capacity += seats;
            this.IncreasePrice(seats * 100);
        }
        public string GetDescription()
        {
            string info = "Description of Bus Functionality: \n" +
                "Velocity: " + speed +"\n" + "Horse Power: " + horsePower +"\n"+
                "Seats capacity: " + capacity + "\n"+ "Number Of Wheels: " + numberOfWheels;
            if (hasEntertaintament)
            {
                info= "\n" + "This Bus has Entertainment";
            }
            if (hasBathroom)
            {
                info = "\n" + "Its Final Price is " + price +".$";
            }
            return info;
        }
    }
}

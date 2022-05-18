

namespace DevVehicle35_Motors
{
    using System;
    using System.Text;
    internal class Motorcycle : IMainVehicle
    {
        private VehicleParts parts;
        private bool helmet;
        private ITypeMotorcycle typeMotorcycle;
        internal Motorcycle(bool helmet,VehicleParts vehicleParts ,ITypeMotorcycle typeMotorcycle)
        {
            Speed = 160;
            HorsePower = 1000;
            Price = 2000;
            Capacity = 2;
            this.parts = vehicleParts;
            this.helmet = helmet;
            this.typeMotorcycle = typeMotorcycle;
        }

        public decimal Price { get; set; }
        public int Speed { get; set; }
        public int HorsePower { get; set; }
        public int Capacity { get; set; }
        public int NumberOfWheels { get; set; }

        public string GetDescription()
        {
            return String.Format("\nDescription of Motorcycle Functionality:\n{0}\nPrice =  {1}.",this.ToString(), this.FinalPrice());
        }

        private decimal FinalPrice()
        {
            decimal result = Price + this.parts.Price + this.typeMotorcycle.GetPrice();
            if (helmet)
            {
                result += 100;
            }

            return result;
        }

        private string GetHelmet()
        {
            if (this.helmet)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        public override string ToString()
        {
            return string.Format("\nParts = {0}\nHelmet = {1}\nType = {2}\nSpeed = {3}\nHorsePower = {4}\nCapacity = {5}\nNumberOfWheels = {6}", this.parts.Country, this.GetHelmet(), this.typeMotorcycle.GetTypeMoto(), Price, Speed, HorsePower, Capacity, NumberOfWheels);
        }

    }
}

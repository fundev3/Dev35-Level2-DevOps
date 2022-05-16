using System;

namespace DevVehicle35_Motors
{
    internal class Motorcycle : IVehicleBased
    {
        private VehicleParts parts;
        private bool helmet;
        private ITypeMotorcycle typeMotorcycle;
        internal Motorcycle(bool helmet, ITypeMotorcycle typeMotorcycle)
        {
            this.parts = new VehicleParts("Japan", 250);
            Speed = 160;
            HorsePower = 1000;
            Price = 2000;
            Capacity = 2;
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
            return ";";
        }

        private void FinalPrice()
        {
            decimal result = Price + this.parts.Price + this.typeMotorcycle.GetPrice();
            if (helmet)
            {
                result += 100;
            }

            Console.WriteLine("total price: {0}", result);
        }
    }
}

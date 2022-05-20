using System;

namespace DevVehicle35_Motors
{
    internal class Mountain : ITypeMotorcycle
    {
        private string type;
        private decimal price;
        public Mountain()
        {
            this.type = "Mountain";
            this.price = 200;
        }
        public decimal GetPrice()
        {
            return this.price;
        }

        public string GetTypeMoto()
        {
            return this.type;
        }

    }
}

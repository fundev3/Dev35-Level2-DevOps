using System;

namespace DevVehicle35_Motors
{
    internal class Street : ITypeMotorcycle
    {
        private string type;
        private decimal price;
        public Street()
        {
            this.type = "Street";
            this.price = 300;
        }
        public decimal GetPrice()
        {
            return this.price;
        }
    }
}

using System;

namespace DevVehicle35_Motors
{
    internal class Standard : ITypeMotorcycle
    {
        private string type;
        private decimal price;
        public Standard()
        {
            this.type = "Standard";
            this.price = 0;
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

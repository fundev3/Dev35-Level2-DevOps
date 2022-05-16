using System;

namespace DevVehicle35_Motors
{
    internal class VehicleParts
    {
        private string country;
        private decimal price;

        internal VehicleParts(string country, decimal price)
        {
            this.country = country;
            this.price = price;
        }

        internal string Country
        {
            get { return country; }
            set { country = value; }
        }
        internal decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}

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
        }
        internal decimal Price
        {
            get { return price; }
        }
    }
}

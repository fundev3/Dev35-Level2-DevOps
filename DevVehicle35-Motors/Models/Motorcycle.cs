

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
            NumberOfWheels = 2;
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
            StringBuilder builder = new StringBuilder("\nDescription of Motorcycle Functionality:\n");
            builder.Append("Parts origin:       " + this.parts.Country + "\n");
            builder.Append("Type:               " + this.typeMotorcycle.GetTypeMoto() + "\n");
            builder.Append("Helmet:             " + this.GetHelmet() + "\n");
            builder.Append("Speed:              " + Speed + " km/h\n");
            builder.Append("Horse Power:        " + HorsePower + " hp\n");
            builder.Append("Seats capacity:     " + Capacity + " obviously\n");
            builder.Append("Number Of Wheels:   " + NumberOfWheels + "\n");
            builder.Append("Its Final Price is: " + this.FinalPrice());
            return builder.ToString();
        }

        private decimal FinalPrice()
        {
            decimal result = Price + this.parts.Price + this.typeMotorcycle.GetPrice();
            if (this.helmet)
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
    }
}

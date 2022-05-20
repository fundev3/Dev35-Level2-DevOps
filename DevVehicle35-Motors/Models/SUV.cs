using System.Text;
using DevVehicle35_Motors.Enum;

namespace DevVehicle35_Motors.Models
{
    internal class SUV : IMainVehicle
    {
        public SUV(Colors color, TypeOfTraction traction, int NumberOfDoors)
        {
            this.Speed = 180;
            this.HorsePower = 4000;
            this.Price = 35000;
            this.Capacity = 6;
            this.Color = color;
            this.Traction = traction;
            this.NumberOfWheels = 4;
            this.NumberOfDoors = NumberOfDoors;
            this.SetPrice();
        }

        public decimal Price { get; set; }

        public int Speed { get; set; }

        public int HorsePower { get; set; }

        public int NumberOfWheels { get; set; }

        public int Capacity { get; set; }

        private int NumberOfDoors { get; set; }

        private Colors Color { get; set; }

        private TypeOfTraction Traction { get; set; }

        public string GetDescription()
        {
            StringBuilder description = new StringBuilder("Description of SUV:\n");
            description.AppendLine($"Color: {this.Color}");
            description.AppendLine($"Horse power: {this.HorsePower} HP");
            description.AppendLine($"Speed: {this.Speed} Km/h");
            description.AppendLine($"Capacity: {this.Capacity} people");
            description.AppendLine($"Number of wheels: {this.NumberOfWheels}");
            description.AppendLine($"Number of doors: {this.NumberOfDoors}");
            description.AppendLine($"Traction: {this.Traction}");
            description.AppendLine($"Price: {this.Price}$");

            return description.ToString();
        }

        private void SetPrice()
        {
            this.Price += this.NumberOfDoors == 2 ? 600 : 900;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevVehicle35_Motors.Models
{
    internal class Car:IMainVehicle
    {
        public decimal Price { get; set; } 
        public int Speed { get; set; }
        public int HorsePower { get; set; }
        public int Capacity { get; set; }
        public int NumberOfWheels { get; set; }
        public int NumberOfDoors { get; set; } 
        public string Color { get; set; }

        public Car(string color, int numberOfDoors)
        {
            this.Speed = 120;
            this.HorsePower = 1000;
            this.Price = 12000;
            this.Capacity = 4;
            this.NumberOfWheels = 4;
            this.Color = color;
            this.NumberOfDoors = numberOfDoors;

        }

        public decimal DeterminePrice()
        {
            this.Price = this.NumberOfDoors == 2 ? this.Price + 500 : this.Price + 1000;
            return this.Price;
           
        }

        public string GetDescription()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The Price is: {this.Price}");
            sb.AppendLine($"The Speed is : {this.Speed}");
            sb.AppendLine($"The Capacity is: {this.Capacity}");
            sb.AppendLine($"The Number of Wheels is: {this.NumberOfWheels}");
            sb.AppendLine($"The Number of Doors is: {this.NumberOfDoors}");
            sb.AppendLine($"The Horse power is : {this.HorsePower}");
            sb.AppendLine($"The Car's color is : {this.Color}");
            return sb.ToString();

        }

        
    }
}

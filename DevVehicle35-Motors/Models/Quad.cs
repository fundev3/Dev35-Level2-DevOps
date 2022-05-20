using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevVehicle35_Motors.Models
{
    internal class Quad : IMainVehicle

    {
        private  bool hadHelmet;

        private string typeOfFuel = string.Empty;


        public Quad()
        {
            Speed = 200;
            Price = 4000;
            Capacity = 2;

        }

        public decimal Price { get ; set; } 
    
        public int Speed { get; set; }

        public int HorsePower { get ; set; }

        public int Capacity { get; set; }

        public int NumberOfWheels { get ; set; }


   

        public decimal DeterminePrice(string fuel,bool helmet,int power)
        {
            SetTypeOfFuel(fuel);
            IncludeHelmet(helmet);
            SelectHorsePower(power);
            return this.Price;
        }

        public string GetDescription()
        {
            StringBuilder sb = new StringBuilder("Description of Quad: ");
            sb.AppendLine($"The Price is : {Price}");
            sb.AppendLine($"The Speed is : {Speed}");
            sb.AppendLine($"The Capacity is: {Capacity}");
            sb.AppendLine($"The type of fuel is : {this.typeOfFuel}");
            sb.AppendLine($"The Horse power is : {this.HorsePower}");
            if (this.hadHelmet)
            {
                sb.AppendLine($"This quad have a helmet");
            }
            return sb.ToString();
        }

        private void SetTypeOfFuel(string fuel)
        {
            this.typeOfFuel = fuel;
            if (fuel == "Gasoline")
            {
                this.Price += 80;
            }
            else
            {
                this.Price += 120;
            }
        }

        private void IncludeHelmet(bool helmet)
        {
            if (helmet)
            {
                this.Price += 100;
                this.hadHelmet = true;
            }

        }

        private void SelectHorsePower(int power)
        {
            if (power > 1200)
            {
                this.Price += 10;
                this.HorsePower = 1400;
            }
            else
            {
                this.HorsePower = 1200;
            }

        }








    }
}

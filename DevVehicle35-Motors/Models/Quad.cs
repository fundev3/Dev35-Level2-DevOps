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

        private  int horsePower;

        private string typeOfFuel = string.Empty;
        

        public decimal Price { get ; set; } 
    
        public int Speed { get; set; }

        public int HorsePower { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Capacity { get; set; }

        public int NumberOfWheels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Quad()
        {
            Speed= 200;
            Price = 4000;
            Capacity = 2;

        }

        private void SetTypeOfFuel(string fuel)
        {
            this.typeOfFuel = fuel;
            if (fuel == "Gasoline")
            {
                Price += 80;
            }
            else
            {
                Price += 120;
            }
        }

        private void IncludeHelmet(bool helmet)
        {
            if (helmet)
            {
                Price += 100;
                this.hadHelmet = true;
            }

        }

        private void SelectHorsePower(int power)
        {
            if (power > 1200)
            {
                Price += 10;
            }
        }

        public decimal DeterminePrice(string fuel,bool helmet,int power)
        {
            SetTypeOfFuel(fuel);
            IncludeHelmet(helmet);
            SelectHorsePower(power);
            return Price;
        }

        public string GetDescription()
        {
            StringBuilder sb = new StringBuilder("Description of Quad: ");
            sb.AppendLine($"The Price is : {Price}");
            sb.AppendLine($"The Speed is : {Speed}");
            sb.AppendLine($"The Capacity is: {Capacity}");
            sb.AppendLine($"The type of fuel is : {this.typeOfFuel}");
            sb.AppendLine($"The Horse power is : {this.horsePower}");
            if (this.hadHelmet)
            {
                sb.AppendLine($"This quad have a helmet");
            }
            return sb.ToString();
        }








    }
}

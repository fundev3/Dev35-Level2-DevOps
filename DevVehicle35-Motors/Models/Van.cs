using DevVehicle35_Motors.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevVehicle35_Motors.Enum;

namespace DevVehicle35_Motors.Models
{
    //bathroom, capacity, size of bed, price method,display description
    internal class Van : IMainVehicle
    {
        public decimal Price { get; set; }

        public int Speed { get; set; }

        public int HorsePower { get; set; }

        public int Capacity { get; set; }

        public int NumberOfWheels { get; set; }

        private bool Bathroom { get; set; }

        private SizeOfBedsEnum SizeofBed { get; set; }



        public bool SetCapacity(int capacity)
        {
            if (capacity > 0 && capacity <= 3)
            {
                this.Capacity = capacity;
                return true;
            }

            return false;
        }

        public void SetBathroom(bool bathroom)
        {
            if (bathroom == true)
            {
                this.Bathroom = true; 
            }
            else
            {
                this.Bathroom = false;
            }
        }

        public string GetDescription()
        {
            CalculatePrice();
            Console.WriteLine("***********************************************");
            StringBuilder builder = new StringBuilder("Description of Van Functionality: \n");
            builder.Append("Velocity:           " + Speed + "\n");
            builder.Append("Horse Power:        " + HorsePower + "\n");
            builder.Append("Seats capacity:     " + Capacity + "\n");
            builder.Append("Number Of Wheels:   " + NumberOfWheels + "\n");
            builder.Append("Has bathroom        " + (Bathroom ? "Yes" : "No") + "\n");
            builder.Append("Size of Bed:  " + SizeofBed + "\n");
            builder.Append("Its Final Price is: " + Price);
            Console.WriteLine("***********************************************");
            return builder.ToString();
        }

        internal Van()
        {
            Speed = 120;
            HorsePower = 10000;
            Price = 70000;
            NumberOfWheels = 4;
        }

        public void CalculatePrice()
        {
            int cont = 0;
            if (Bathroom) cont += 500;
            cont += Capacity * 250;
            this.Price += cont;
        }
        public void SetSizeofBed(SizeOfBedsEnum size)
        {
            this.SizeofBed = size;
        }
    }
}

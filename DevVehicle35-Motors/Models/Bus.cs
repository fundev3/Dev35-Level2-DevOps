using System.Text;

namespace DevVehicle35_Motors.Models
{
    internal class Bus : IMainVehicle
    {
        public decimal Price { get; set; }

        public int Speed { get; set; }

        public int HorsePower { get; set; }

        public int Capacity { get; set; }

        public int NumberOfWheels { get; set; }

        private bool hasEntertainment;
        private bool hasBathroom;

        internal bool HasEntertainment { get => hasEntertainment; private set => hasEntertainment = value; }

        internal bool HasBathroom { get => hasBathroom; private set => hasBathroom = value; }

        internal Bus()
        {
            Speed = 200;
            HorsePower = 10000;
            Price = 60000;
            Capacity = 20;
            NumberOfWheels = 4;
        }

        public string GetDescription()
        {
            StringBuilder builder = new StringBuilder("Description of Bus Functionality: \n");
            builder.Append("Velocity:           " + Speed + "\n");
            builder.Append("Horse Power:        " + HorsePower + "\n");
            builder.Append("Seats capacity:     " + Capacity + "\n");
            builder.Append("Number Of Wheels:   " + NumberOfWheels + "\n");
            builder.Append("Has Entertainment:  " + hasEntertainment + "\n");
            builder.Append("Has bathroom        " + hasBathroom + "\n");
            builder.Append("Its Final Price is: " + Price);
            return builder.ToString();
        }

        internal void AddEntertainment()
        {
            this.hasEntertainment = true;
            this.IncreasePrice(300);
        }

        internal void AddBathroom()
        {
            this.hasBathroom = true;
            this.IncreasePrice(500);
        }

        internal void AddSeats(int seats)
        {
            Capacity += seats;
            this.IncreasePrice(seats * 100);
        }

        private void IncreasePrice(decimal increase)
        {
            this.Price += increase;
        }
    }
}

namespace DevVehicle35_Motors.Models
{
    internal class Bus : IMainVehicle
    {
        public decimal price { get; set; }

        public int speed { get; set; }

        public int horsePower { get; set; }

        public int capacity { get; set; }

        public int numberOfWheels { get; set; }

        private bool hasEntertainment;
        private bool hasBathroom;

        internal bool HasEntertainment { get => hasEntertainment; private set => hasEntertainment = value; }

        internal bool HasBathroom { get => hasBathroom; private set => hasBathroom = value; }

        internal Bus()
        {
            speed = 200;
            horsePower = 10000;
            price = 60000;
            capacity = 20;
            numberOfWheels = 4;
        }

        public string GetDescription()
        {
            string info = "Description of Bus Functionality: \n" +
                "Velocity:           " + speed + "\n" + "Horse Power:        " + horsePower + "\n" +
                "Seats capacity:     " + capacity + "\n" + "Number Of Wheels:   " + numberOfWheels;
            if (hasEntertainment)
            {
                info += "\n" + "Has Entertainment:  " + hasEntertainment;
            }

            if (hasBathroom)
            {
                info += "\n" + "Has bathroom        " + hasBathroom;
            }

            info += "\n" + "Its Final Price is: " + price + " $.";
            return info;
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
            capacity += seats;
            this.IncreasePrice(seats * 100);
        }

        private void IncreasePrice(decimal increase)
        {
            this.price += increase;
        }
    }
}

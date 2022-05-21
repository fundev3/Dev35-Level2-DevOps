namespace DevVehicle35_Motors.Models
{
    internal class MiniBus : IMainVehicle
    {
        public decimal Price { get; set; }

        public int Speed { get; set; }

        public int HorsePower { get; set; }

        public int Capacity { get; set; }

        public int NumberOfWheels { get; set; }

        private bool automaticDoor;
        const int passengersCost = 50;
        const int automaticDoorCost = 300;

        public MiniBus(int capacity, bool automaticDoor)
        {
            this.Speed = 200;
            this.HorsePower = 1400;
            this.Price = 20000;
            this.NumberOfWheels = 4;
            this.automaticDoor = automaticDoor;
            this.AddCapacity(capacity);
            Console.WriteLine(this.GetDescription());
        }

        public decimal GetPrice()
        {
            return this.Price;
        }

        public void AddAutomaticDoor()
        {
            this.automaticDoor = true;
            this.Price += automaticDoorCost;
        }

        public void AddCapacity(int passengers)
        {
            this.Capacity = passengers;
            this.Price += passengers * passengersCost;
        }

        public string GetDescription()
        {
            return $"The car is an: MiniBus\n" +
                   $"It " + (this.automaticDoor ? "has" : "has not") + " automaticdoor: "+ (this.automaticDoor ? automaticDoorCost : "0") + "\n" +
                   $"Capacity: {this.Capacity}\n" +
                   $"Number of wheels: {this.NumberOfWheels}\n" +
                   $"Horse Power:  {this.HorsePower}\n" +
                   $"Speed: {this.Speed}\n" +
                   $"Price: {this.Price}";
        }
    }
}

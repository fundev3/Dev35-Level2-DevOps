namespace DevVehicle35_Motors
{
    internal interface IMainVehicle
    {
        public decimal Price { get; set; }

        public int Speed { get; set; }

        public int HorsePower { get; set; }

        public int Hapacity { get; set; }

        public int NumberOfWheels { get; set; }

        public string GetDescription();
    }
}

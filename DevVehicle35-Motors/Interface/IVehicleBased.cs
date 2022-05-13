namespace DevVehicle35_Motors
{
    internal interface iMainVehicle
    {
        public decimal price { get; set; }
        public int speed { get; set; }
        public int horsePower { get; set; }
        public int capacity { get; set; }
        public int numberOfWheels { get; set; }
        public string GetDescription();
    }
}

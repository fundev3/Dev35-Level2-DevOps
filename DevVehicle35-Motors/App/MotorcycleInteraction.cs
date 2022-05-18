

namespace DevVehicle35_Motors.App
{
    using DevVehicle35_Motors.Factorys;
    internal class MotorcycleInteraction
    {
        internal MotorcycleInteraction()
        {

        }
        internal static void BuildMotorcycle()
        {
            bool helmet = ChooseHelmet();
            VehicleParts vehicleParts = ChooseVehicleParts();
            ITypeMotorcycle type = ChooseType();
            Motorcycle motorcycle = new Motorcycle(helmet,vehicleParts,type);
            Console.WriteLine(motorcycle.GetDescription());
        }


        private static bool ChooseHelmet()
        {
            bool helmet = false;
            Console.WriteLine("\nDo you want include a helmet?");
            MenuAbstractClass.CreateOptionMenu(new string[] { "Yes", "No" });
            Console.WriteLine("Enter your option: ");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                helmet = true;
            }
            return helmet;
        }

        private static VehicleParts ChooseVehicleParts()
        {
            Console.WriteLine("\nSelect the origin of the motorcycle parts:");
            MenuAbstractClass.CreateOptionMenu(new string[] { "Japan", "Korea" });
            Console.WriteLine("Enter your option: ");
            return FactoryParts.CreateVehicleParts(int.Parse(Console.ReadLine()));            
        }

        private static ITypeMotorcycle ChooseType()
        {
            Console.WriteLine("\nSelect the motorcycle type:");
            MenuAbstractClass.CreateOptionMenu(new string[] { "Standard", "Mountain", "Street" });
            Console.WriteLine("Enter your option: ");
            return FactoryMotorcycleType.CreateMotorcycleType(int.Parse(Console.ReadLine()));
        }



    }
}

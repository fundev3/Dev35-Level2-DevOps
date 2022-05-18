

namespace DevVehicle35_Motors.App
{
    using DevVehicle35_Motors.Factorys;
    internal class MotorcycleInteraction
    {
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
            bool isNumber = false;
            int option;
            do
            {
                Console.WriteLine("Enter your option: ");
                isNumber= int.TryParse(Console.ReadLine(), out option);
                if (option > 2 || option <= 0) isNumber = false;
            } while (isNumber == false);

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
            bool isNumber = false;
            int option;
            do
            {
                Console.WriteLine("Enter your option: ");
                isNumber = int.TryParse(Console.ReadLine(), out option);
                if (option > 2 || option <= 0) isNumber = false;
            } while (isNumber == false);
            return FactoryParts.CreateVehicleParts(option);            
        }
        private static ITypeMotorcycle ChooseType()
        {
            Console.WriteLine("\nSelect the motorcycle type:");
            MenuAbstractClass.CreateOptionMenu(new string[] { "Standard", "Mountain", "Street" });
            bool isNumber = false;
            int option;
            do
            {
                Console.WriteLine("Enter your option: ");
                isNumber = int.TryParse(Console.ReadLine(), out option);
                if (option > 3 || option <= 0) isNumber = false;
            } while (isNumber == false);
            return FactoryMotorcycleType.CreateMotorcycleType(option);
        }
    }
}

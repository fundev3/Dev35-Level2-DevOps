using DevVehicle35_Motors.App;
using System;

Console.WriteLine("DevVehicles 35 Car Dealership");
Console.WriteLine("===============================");

string option = string.Empty;
while (option != "q")
{
    Console.WriteLine();
    Console.WriteLine("Select the type of vehicle you want to build:");
    Console.WriteLine("1. Car");
    Console.WriteLine("2. Bus");
    Console.WriteLine("3. Quad");
    Console.WriteLine("4. Motorcycle");
    Console.WriteLine("5. SUV");
    Console.WriteLine("6. Tractor");
    Console.WriteLine("7. Van");
    Console.WriteLine("9. Scooter");
    Console.WriteLine("q. Quit");
    option = Console.ReadLine() ?? string.Empty;
    if (option != "q")
    {
        switch (int.Parse(option))
        {
            case 1:
                CarInteraction.BuildCar();
                break;
            case 2:
                BusInteraction.BuildBus();
                break;
            case 3:
                QuadInteraction.BuildQuad();
                break;
            case 4:
                MotorcycleInteraction.BuildMotorcycle();
                break;
            case 5:
                SUVInteraction.BuildSUV();
                break;
            case 6:
                TractorInteraction.BuildTractor();
                break;
            case 7:
                VanInteraction.BuildVan();
                break; 
            case 9:
                ScooterInteraction.BuildScooter(); 
                break; 
            default:
                break;
        }
    }
}

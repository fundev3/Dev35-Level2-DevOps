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
            default:
                break;
        }
    }
}

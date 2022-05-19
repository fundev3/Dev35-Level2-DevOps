using DevVehicle35_Motors.App;
using System;

Console.WriteLine("DevVehicles 35 Car Dealership");
Console.WriteLine("===============================");

string option = string.Empty;
while (option != "q")
{
    Console.WriteLine();
    Console.WriteLine("Select the type of vehicle you want to build:");
    Console.WriteLine("2. Bus");
    Console.WriteLine("3. Quad");
    Console.WriteLine("6. Tractor");
    Console.WriteLine("q. Quit");
    option = Console.ReadLine() ?? string.Empty;
    if (option != "q")
    {
        switch (int.Parse(option))
        {
            case 2:
                BusInteraction.BuildBus();
                break;
            case 3:
                QuadInteraction.BuildQuad();
                break;
            case 6:
                TractorInteraction.BuildTractor();
                break;
            default:
                break;
        }
    }
}

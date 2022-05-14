using DevVehicle35_Motors.App;

Console.WriteLine("DevVehicles 35 Fabrica de Autos");
Console.WriteLine("===============================");

string option = string.Empty;
while (option != "q")
{
    Console.WriteLine();
    Console.WriteLine("Select the type of vehicle you want to build:");
    Console.WriteLine("2. Bus");
    Console.WriteLine("q. Quit");
    option = Console.ReadLine() ?? string.Empty;
    switch (int.Parse(option))
    {
        case 2:
            BusInteraction.BuildBus();
            break;
        default:
            break;
    }
}

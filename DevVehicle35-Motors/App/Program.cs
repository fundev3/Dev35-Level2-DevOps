using DevVehicle35_Motors;
Console.WriteLine("DevVehicles 35 Fabrica de Autos");
Console.WriteLine("===============================");

string option = string.Empty;
while (option != "q")
{
    Console.WriteLine();
    Console.WriteLine("Select the type of vehicle you want to build:");
    Console.WriteLine("q. Quit");
    option = Console.ReadLine() ?? string.Empty;
    if(option == "minibus")
	{
        MiniBus miniStarter = new MiniBus();
        Console.WriteLine(miniStarter);
    }
}

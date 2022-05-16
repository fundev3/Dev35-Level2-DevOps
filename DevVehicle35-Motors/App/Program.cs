using DevVehicle35_Motors.App;

Console.WriteLine("DevVehicles 35 Fabrica de Autos");
Console.WriteLine("===============================");

string option = string.Empty;
while (option != "q")
{
    Console.WriteLine();
    Console.WriteLine("Select the type of vehicle you want to build:");
    Console.WriteLine("3. Quad");
    Console.WriteLine("q. Quit");
    option = Console.ReadLine() ?? string.Empty;
    if (option != "q")
    {
        switch (int.Parse(option))
        {
            case 3:
                QuadInteraction.BuildQuad();
                break;
            default:
                break;
        }
    }
}

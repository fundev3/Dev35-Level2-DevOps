using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevVehicle35_Motors.App
{
    internal class TractorInteraction 
    {
        internal void BuildTractor()
        {
            Console.WriteLine("Welcome to build tractor!!");
            Console.WriteLine("how much horse power do you want in the tractor?");
            int horsePower = Console.ReadLine();
            Tractor tractor = new Tractor(horsePower);
            Console.WriteLine("Do you want warning lights?");
            int numberWarningLigths = (int)Console.ReadLine();
            tractor.SelectWarningLigths(numberWarningLigths);
            Console.WriteLine("Your Tractor is ready!!");
            tractor.ShowHorsePower();
            tractor.DeterminePrice();
            tractor.GetDescription();
        }

    }
}






using DevVehicle35_Motors.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevVehicle35_Motors.App
{
    internal class TractorInteraction 
    {
        private static int horsePower;

        internal static void BuildTractor()
        {
            Console.WriteLine("Welcome to build tractor!!");
            Console.WriteLine("how much horse power do you want in the tractor?");
            bool whileHelper = true;
            while (whileHelper) 
            {
               
                horsePower = int.Parse(Console.ReadLine());
                if (horsePower >= 63000 && horsePower <= 70000) 
                {
                    whileHelper=false;

                }
                if (whileHelper==false) 
                {
                    break;
                }
                Console.WriteLine("The horse power should be between 63000 and 70000");
                Console.WriteLine("how much horse power do you want in the tractor?");
            }

            Tractor tractor = new Tractor(horsePower);
            Console.WriteLine("Do you want warning lights?  1=Yes  2=No");
            int numberWarningLigths = int.Parse(Console.ReadLine());
            tractor.SelectWarningLigths(numberWarningLigths);
            Console.WriteLine("Your Tractor is ready!!");
            tractor.ShowHorsePower();
            tractor.DeterminePrice();
            Console.WriteLine(tractor.GetDescription());
        }

    }
}






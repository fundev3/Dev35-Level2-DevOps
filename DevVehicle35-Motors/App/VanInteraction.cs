using DevVehicle35_Motors.Models;

namespace DevVehicle35_Motors.App
{
    internal class VanInteraction
    {
        internal static int Vcapacity = 0;

        public static void BuildVan()
        {
            string? opt;
            int optN;
            Van van = new Van();
            Console.WriteLine(string.Empty);
            Console.WriteLine("Hi! We will help you to find the Van of your dreams...");
            BathroomChoise();
            opt = Console.ReadLine();
            optN = ValidateInput(opt, 1, 2, 1);
            switch (optN)
            {
                case 1: van.SetBathroom(true);
                    break;
                case 2: van.SetBathroom(false);
                    break;
                default: Console.WriteLine("Thanks for visiting us!"); Environment.Exit(0); break;
            }
            Console.WriteLine(string.Empty);
            CapacityChoise();
            opt = Console.ReadLine();
            optN = ValidateInput(opt, 1, 3, 2);
            if (optN == 0)
            {
                Console.WriteLine("Thanks for visiting us!");
                Environment.Exit(0);
            }
            van.SetCapacity(optN);
            Vcapacity = optN;
            SizeOfBedChoise();
            opt = Console.ReadLine();
            optN = Vcapacity>1? ValidateInput(opt, 2, 3, 3): ValidateInput(opt, 1, 3, 3);
            switch (optN)
            {
                case 1: van.SetSizeofBed(Enum.SizeOfBedsEnum.Simple);
                    break;
                case 2: van.SetSizeofBed(Enum.SizeOfBedsEnum.Double);
                    break;
                case 3: van.SetSizeofBed(Enum.SizeOfBedsEnum.KingSize);
                    break;
                default: break;
            }
            ShowDescription(van);
        }

        private static int ValidateInput(string? resp, int min, int max, int menu)
        {
            int opt = 0;
            while (opt == 0)
            {
                try
                {
                    if (resp == "q")
                    {
                        return 0;
                    }

                    opt = int.Parse(resp);
                    if (opt >= min && opt <= max)
                    {
                        return opt;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception e)
                {
                    opt = 0;
                    Console.WriteLine("You have entered a wrong input value, try again.");
                    switch (menu)
                    {
                        case 1: BathroomChoise(); break;
                        case 2: CapacityChoise(); break;
                        case 3: SizeOfBedChoise(); break;
                        default: break;
                    }
                    resp = Console.ReadLine();
                    Console.WriteLine("");
                }
            }
            return opt;
        }

        private static void SizeOfBedChoise()
        {
            Console.WriteLine("Tell us, What is your preferred bed size?:");
            if(Vcapacity == 1)
            {
                Console.WriteLine("1. Simple Bed");
             }
            else
            {
                Console.WriteLine("1. --------");
            }
            Console.WriteLine("2. Double");
            Console.WriteLine("3. King Size");
            Console.WriteLine("q. Quit");

        }
        private static void ShowDescription(Van van)
        {
            Console.WriteLine("Your Van is ready!");
            Console.WriteLine("Here are some details about it:");
            Console.WriteLine(van.GetDescription());
        }

        private static void BathroomChoise()
        {
            Console.WriteLine("Tell us, do you want it with a bathroom?:");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.WriteLine("q. Quit");
        }

        private static void CapacityChoise()
        {
            Console.WriteLine("Tell us, how many passengers are going to fit in the Van?");
            Console.WriteLine("(Max. 3 passengers).");
            Console.WriteLine("q. Quit");
        }

        
    }
}

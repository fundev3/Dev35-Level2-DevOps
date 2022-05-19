using System;

namespace DevVehicle35_Motors.App
{
    internal abstract class MenuAbstractClass
    {
        internal MenuAbstractClass()
        {

        }

        public static void CreateOptionMenu(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Option {0}: {1}.", i+1, array[i]);
            }
        }
        public abstract void CreateOptionMenu();
    }
}
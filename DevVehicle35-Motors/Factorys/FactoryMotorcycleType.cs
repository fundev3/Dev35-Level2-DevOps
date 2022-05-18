using System;

namespace DevVehicle35_Motors.Factorys
{
    internal abstract class FactoryMotorcycleType
    {

        internal FactoryMotorcycleType()
        {

        }
		internal static ITypeMotorcycle CreateMotorcycleType(int option)
		{
			ITypeMotorcycle type = null;
			switch (option)
			{
				case 1:
					type = new Standard();
					break;
				case 2:
					type = new Mountain();
					break;
				case 3:
					type = new Street();
					break;
			}
			return type;
			//return type.CreatePizza();
		}

	}
}

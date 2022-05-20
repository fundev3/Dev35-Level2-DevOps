using System;


namespace DevVehicle35_Motors.Factorys
{
    internal class FactoryParts
    {

		internal static VehicleParts CreateVehicleParts(int option)
		{
			VehicleParts vehParts = null;
			switch (option)
			{
				case 1:
					vehParts = new VehicleParts("Japan", 250);
					break;
				case 2:
					vehParts = new VehicleParts("Korea", 300);
					break;
			}
			return vehParts;
		}
	}

}
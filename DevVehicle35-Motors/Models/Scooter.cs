using System;
using System.Text;
using static System.Console; 
//We need to have the functionality to build
//a vehicle that is a Scooter, besides all the
//basic features, this one must be able to:
//-Select top speed betwen 40 and 90 kmh (Multiply
//this value by 8.5 to get price to be added)
//-Select if it will have helmet or not (Add 100$ to final price)
//-Choose the color based on a list. if its not white add 100$
//- Have a method to determine the price.
//- Show the description of the final design and price for each car.

//Default values:
//-Horse Power: 10000
//- Price: 1000
namespace DevVehicle35_Motors.Models
{
	public class Scooter : IMainVehicle
	{

		public decimal Price { get; set; }
		public int HorsePower { get; set; }
		public int Speed { get; set; } //--
		public int Capacity { get; set; }
		public int NumberOfWheels { get; set; }
		public bool Helmet { get; set; } = false; 
		public string[] Colors { get; set; } = new[] {"RED", "BLUE", "BLACK", "WHITE", "PINK", "PURPLE", "TURQUOISE"}; 

		public Scooter()
				{
					HorsePower = 10000;
					Price = 1000;
				}

		public double GettingPrice()
		{
			SelecTopSpeed();
			SelectHelmet();
			ChooseColor();

			
			return 0; 
		}
		public string GetDescription()
		{
			//StringBuilder sb = new StringBuilder("Description of Quad: ");
			//sb.AppendLine($"The Price is : {Price}");
			//sb.AppendLine($"The Speed is : {Speed}");
			//sb.AppendLine($"The Horse power is : {this.horsePower}");
			//if (this.hadHelmet)
			//{
			//	sb.AppendLine($"This quad have a helmet");
			//}
			//return sb.ToString();
			//return ""; 
		}

		public void SelecTopSpeed()
		{
			WriteLine(@"
					  Choose Top Speed
					  🛵 ➡ 40 km/h
					  🛵 ➡ 50 km/h
					  🛵 ➡ 60 km/h
					  🛵 ➡ 70 km/h
					  🛵 ➡ 80 km/h
					  🛵 ➡ 90 km/h ");
			string TopSpeed = ReadLine();
			
		

		}



	}
}


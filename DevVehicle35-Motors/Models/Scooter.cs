using System;
using System.Text;
using static System.Console;
//We need to have the functionality to build
//a vehicle that is a Scooter, besides all the
//basic features, this one must be able to:
//-Select top speed betwen 40 and 90 kmh (Multiply
//this value by 8.5 to get price to be added)✅
//-Select if it will have helmet or not (Add 100$ to final price)✅
//-Choose the color based on a list. if its not white add 100$✅
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
		public string[] Colors { get; set; } = new[] { "WHITE","RED", "BLUE", "BLACK","PINK", "PURPLE", "TURQUOISE"}; 

		public Scooter()
				{
					HorsePower = 10000;
					Price = 1000;
				}

		public void GettingPrice()
		{
			SelectTopSpeed();
			SelectHelmet();
			SelectColor();
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
			return ""; 
		}

		public void SelectTopSpeed()
		{
			int[] Speed = new[] { 40, 50, 60, 70, 80, 90 };
			const decimal PriceOfSpeed = 8.5m; 
			WriteLine(@"
					  Choose Top Speed
					  🛵 ➡ 40 km/h
					  🛵 ➡ 50 km/h
					  🛵 ➡ 60 km/h
					  🛵 ➡ 70 km/h
					  🛵 ➡ 80 km/h
					  🛵 ➡ 90 km/h ");
			string TopSpeed = ReadLine();
			//SpeddVerification();
			this.Price = Price + Decimal.Multiply(Convert.ToDecimal(TopSpeed),(PriceOfSpeed));
		}
		public void SelectHelmet()
		{
			WriteLine(@"
						Do you want a helmet?
						write: (yes / no)");
			string AddHelmed = ReadLine();
			if (AddHelmed.ToUpper() == "YES")
			{
				this.Price += 100m;
			}
		}

		public void SelectColor()
		{
			WriteLine("Choose the numer of the color ------");
			foreach (var color in this.Colors)
			{
				WriteLine("Color {0}: ", color);
			}
			string NumberOfColor = ReadLine();
			int NumberColor = Int32.Parse(NumberOfColor);
			if (NumberColor-1 != 0)
			{
				this.Price += 100m; 
			}

		}
	}
}


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

		public void GettingPrice(string TopSpeed, string Helmet, string Color)
		{
			SelectTopSpeed(TopSpeed);
			SelectHelmet(Helmet);
			SelectColor(Color);
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

		public void SelectTopSpeed(string TopSpeed)
		{
			const decimal PriceOfSpeed = 8.5m;
			this.Price = Price + Decimal.Multiply(Convert.ToDecimal(TopSpeed),(PriceOfSpeed));
		}

		public void SelectHelmet(string Helmet)
		{
			if (Helmet.ToUpper() == "YES")
			{
				this.Price += 100m;
			}
		}

		public void SelectColor(string Color)
		{
			int ColorNumber = Int32.Parse(Color);
			if (ColorNumber - 1 != 0)
			{
				this.Price += 100m; 
			}

		}
	}
}


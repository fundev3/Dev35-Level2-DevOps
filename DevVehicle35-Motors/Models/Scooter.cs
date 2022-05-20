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
		public string Color { get; set; } 

		public Scooter()
				{
					HorsePower = 10000;
					Price = 1000;
				}

		public void GettingPrice(string topSpeed, string Helmet, string Color)
		{
			SelectTopSpeed(topSpeed);
			SelectHelmet(Helmet);
			SelectColor(Color);
		}

		public string GetDescription()
		{   
			string presentation = (@"
					---------------------------------
					You Got the Following Scooter 🛵
					----------------------------------");
			string Description = $"\n \t \t \t \t \t The price is: {Price} \n" +
                   $"\t \t \t \t \t The color is: {Color} \n" +
			       $"\t \t \t \t \t The Top Speed is: {Speed} \n" +
				   $"\t \t \t \t \t The Horse power is: {this.HorsePower} \n";
			string GotHelmet = ""; 
			if (this.Helmet)
			{
				GotHelmet = $"\t \t \t \t \t You got a Helmet\n"; 
			}
            return presentation + Description + GotHelmet; 
		}

		public void SelectTopSpeed(string TopSpeed)
		{
			this.Speed = Int32.Parse(TopSpeed); 
			const decimal PriceOfSpeed = 8.5m;
			this.Price = Price + Decimal.Multiply(Convert.ToDecimal(TopSpeed),(PriceOfSpeed));
		}

		public void SelectHelmet(string Helmet)
		{
			if (Helmet.ToUpper() == "YES")
			{
				this.Helmet = true; 
				this.Price += 100m;
			}
		}

		public void SelectColor(string Color)
		{
			string[] ScooterColors = new[] { "WHITE", "RED", "BLUE", "BLACK", "PURPLE", "YELLOW" };
			this.Color = ScooterColors[Int32.Parse(Color) - 1]; 
			int ColorNumber = Int32.Parse(Color);
			if (ColorNumber - 1 != 0)
			{
				this.Price += 100m; 
			}

		}
	}
}


//We need to have the functionality to build
//a vehicle that is a Scooter, besides all the
//basic features, this one must be able to:
//-Select top speed betwen 40 and 90 kmh (Multiply
//this value by 8.5 to get price to be added)✅
//- Select if it will have helmet or not (Add 100$ to final price)✅
//- Choose the color based on a list. if its not white add 100$✅
//- Have a method to determine the price.
//- Show the description of the final design and price for each car.
using System;
using static System.Console;
using DevVehicle35_Motors.Models;

namespace DevVehicle35_Motors.App
{
	
	public class ScooterInteraction
	{
		
		internal void BuildScooter()
		{
			WriteLine(@"
						----------------------------
						Let's build your own Scooter
						----------------------------
						Select the Top Seep of your Scooter
						  Choose Top Speed
						  🛵 ➡ 40 km/h
						  🛵 ➡ 50 km/h
						  🛵 ➡ 60 km/h
						  🛵 ➡ 70 km/h
						  🛵 ➡ 80 km/h
						  🛵 ➡ 90 km/h "); 
			string TopSpeed = ReadLine();
			string CorrectTopSpeed = SpeedValidator(TopSpeed);//Correct speed

			WriteLine(@"
						Do you want to get a helmet ?
						write: yes / no");
			string Helmet = ReadLine();
			string HelmetPreference = HelmetVerification(Helmet);//Corect helmet

			WriteLine(@"
						Choose the number color of your scooter:
						1. ⚪️ WHITE
						2. 🔴 RED
						3. 🔵 BLUE
						4. ⚫️BLACK
						5. 🟣PURPLE
						6. 🟡Yellow");
			string Color = ReadLine();
			string CorrectColor = ColorVerification(Color);

			var Scooter = new Scooter();
			Scooter.GettingPrice(CorrectTopSpeed, HelmetPreference, CorrectColor);
			WriteLine("The Quad is ready!");
			Console.WriteLine(Scooter.GetDescription());
		}
		public ScooterInteraction()
		{
		}

		public string  SpeedValidator(string Speed)
		{
			int[] Speeds = new[] { 40, 50, 60, 70, 80, 90 };
			int index = Array.IndexOf(Speeds, Speed);
			if (index == -1)
			{
				WriteLine("Introduce a correct speed");
				return SpeedValidator(ReadLine());
			}
			else
			{
				return Speed[index].ToString();
			}
		}

		public string HelmetVerification(string Helmet)
		{
			if (Helmet.ToUpper() == "YES" | Helmet.ToUpper() == "NO")
			{
				return Helmet.ToUpper();
			}
			else
			{
				return HelmetVerification(ReadLine());
			}
			
		}

		public string ColorVerification(string Color)
		{
			int NumberOfColor = Int32.Parse(Color); 
			if(NumberOfColor > 0 && NumberOfColor < 7)
			{
				return Color; 
			}
			else
			{
				return ColorVerification(ReadLine()); 
			}
		}
	}
}


using static System.Console;
using DevVehicle35_Motors.Models;

namespace DevVehicle35_Motors.App
{
	
	public class ScooterInteraction
	{
		
		internal static void BuildScooter()
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
						4. ⚫️ BLACK
						5. 🟣 PURPLE
						6. 🟡 Yellow");
			string Color = ReadLine();
			string CorrectColor = ColorVerification(Color);

			var Scooter = new Scooter();
			Scooter.GettingPrice(CorrectTopSpeed, HelmetPreference, CorrectColor);
			WriteLine(@"
						The Scooter is ready!");
			Console.WriteLine(Scooter.GetDescription());
		}
		public ScooterInteraction()
		{
		}

		public static string SpeedValidator(string Speed)
		{
			var Speeds = new[] { "40", "50","60","70", "80", "90" };
			string index = Array.Find(Speeds, element => element == Speed);
            if (index == null)
            {
                WriteLine("Introduce a correct speed");
                Speed = SpeedValidator(ReadLine());
                return Speed;
            }
            else
            {
				return Speed; 
            }
        }

		public static string HelmetVerification(string Helmet)
		{
			if (Helmet.ToUpper() == "YES" | Helmet.ToUpper() == "NO")
			{
				return Helmet.ToUpper();
			}
			else
			{
				WriteLine("Introduce yes or no, please");
				return HelmetVerification(ReadLine());
			}
			
		}

		public static string ColorVerification(string Color)
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


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
			string topSpeed = ReadLine();
			string correctTopSpeed = SpeedValidator(topSpeed);//Correct speed

			WriteLine(@"
						Do you want to get a helmet ?
						write: yes / no");
			string helmet = ReadLine();
			string helmetPreference = HelmetVerification(helmet);//Corect helmet

			WriteLine(@"
						Choose the number color of your scooter:
						1. ⚪️ WHITE
						2. 🔴 RED
						3. 🔵 BLUE
						4. ⚫️ BLACK
						5. 🟣 PURPLE
						6. 🟡 YELLOW");
			string color = ReadLine();
			string correctColor = ColorVerification(color);

			var scooter = new Scooter();
			scooter.GettingPrice(correctTopSpeed, helmetPreference, correctColor);
			WriteLine(@"
						The Scooter is ready!");
			Console.WriteLine(scooter.GetDescription());
		}
		public ScooterInteraction()
		{
		}

		public static string SpeedValidator(string speed)
		{
			var speeds = new[] { "40", "50","60","70", "80", "90" };
			string index = Array.Find(speeds, element => element == speed);
            if (index == null)
            {
                WriteLine("Introduce a correct speed");
                speed = SpeedValidator(ReadLine());
                return speed;
            }
            else
            {
				return speed; 
            }
        }

		public static string HelmetVerification(string helmet)
		{
			if (helmet.ToUpper() == "YES" | helmet.ToUpper() == "NO")
			{
				return helmet.ToUpper();
			}
			else
			{
				WriteLine("Introduce yes or no, please");
				return HelmetVerification(ReadLine());
			}
			
		}

		public static string ColorVerification(string color)
		{
			int numberOfColor = Int32.Parse(color); 
			if(numberOfColor > 0 && numberOfColor < 7)
			{
				return color; 
			}
			else
			{
				return ColorVerification(ReadLine()); 
			}
		}
	}
}


using System.Text;

namespace DiceRoller
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool goOn = true;
			int length = 0;
			int rolls = 1;
			Console.WriteLine("Welcome to the casino");
			while (goOn)
			{
				try
				{
					Console.WriteLine("How big do you want the dice to be ?");
					length = int.Parse(Console.ReadLine());
					if (length >= 2)
					{

					}
					else
					{
						Console.WriteLine("Please enter 2 or more :)");
						continue;
					}
					
					break;
				}
				catch (FormatException)
				{
					Console.WriteLine("your input was not a valid number");
					continue;
				}
			}
			bool keepRolling = true;
			while (keepRolling)
			{
				int die1 = GenerateNumber(length);
				int die2 = GenerateNumber(length);
				PrintResults(length, rolls, die1, die2);
				rolls++;
				keepRolling = AskToContinue();
			}

		Console.WriteLine("thank you! :D");
		}
		public static int GenerateNumber(int length)
		{
			Random r = new Random();
			return r.Next(1, length);
		}
		public static string GiveMessage(int length, int total, int die1, int die2)
		{
			StringBuilder together = new StringBuilder("");
			if (length == 6)
			{
				if (die1 == 1 && die2 == 1)
				{
					together.Append("snake eyes \n");
				}
				if ((die1 == 1 && die2 == 2) || (die1 == 2 && die2 == 1))
				{
					together.Append("ace duece \n");
				}
				if ((die1 == 7 && die2 == 11) || (die1 == 11 && die2 == 7))
				{
					together.Append("win \n");
				}
				if (die1 == 6 && die2 == 6)
				{
					together.Append("box cars \n");
				}
				if (total == 2 || total == 3 || total == 12)
				{
					together.Append("craps! \n");
				}
			}
			else if (length == 25)
			{
				if ((die1 == 12 && die2 == 13)||(die1 == 13 && die2 == 12))
				{
					together.Append("split! \n");
				}
			}
			return together.ToString();
		}
		public static void PrintResults(int length, int rolls, int die1, int die2)
		{
			int total = die1 + die2;
			Console.WriteLine($"Roll {rolls}:");
			Console.WriteLine($"you rolled a {die1} and a {die2}! ({total} total)");
			Console.WriteLine(GiveMessage(length, total, die1, die2));
			Console.WriteLine("");

		}
		public static bool AskToContinue()
		{
			Console.WriteLine("would you like to roll again? (y/n)");
			string input = Console.ReadLine().ToLower();
			if (input == "y" || input == "yes")
			{
				return true;

			}
			else if (input == "n" || input == "no")
			{
				return false;
			}
			else
			{
				Console.WriteLine("try again (y/n)");
				return AskToContinue();
			}
		}
	}

}
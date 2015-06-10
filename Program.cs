using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundSharp
{
    struct MP3Player
    {
        public int id;
        public string make;
        public string model;
        public double mbSize;
        public float price;
    }

    class Program
	{
		const int ALLOWED_AUTHENTICATION_ATTEMPTS = 3;

		static void Main(string[] args)
		{
			Console.WriteLine("Vul uw naam in:");
			var name = Console.ReadLine();
			Console.Clear();
			var auth = Login();

			switch (auth)
			{
				case "NietOK":
					Console.WriteLine("Het is niet gelukt om u in te loggen.");
					break;

				case "OK":
					Console.WriteLine("Welkom bij SoundSharp, " + name + "!");
					break;

				default:
					Console.WriteLine("U heeft niks ingevult, hierbij gaan wij er van uit dat u SoundSharp wilt afsluiten.");
					break;
			}

			/* Pause the script */
			Console.WriteLine("Druk op Enter om door te gaan...");
			Console.ReadLine();
		}

        static void ShowMenu()
        {
            IDictionary<char, string> menu = new Dictionary<char, string>();
            menu['1'] = "Overzicht mp3 spelers";
            menu['9'] = "Exit";

            foreach (KeyValuePair<char, string> menuItem in menu)
                Console.WriteLine(menuItem.Key + ". " + menuItem.Value);

            while (true)
            {
                var input = Console.ReadKey(true);

                if (menu.ContainsKey(input.KeyChar))
                {
                    Console.Clear();
                    Console.WriteLine("Gekoze actie: " + menu[input.KeyChar]);

                    switch (input.KeyChar)
                    {
                        case '9':
                            Console.WriteLine("Tot ziens!");
                            break;
                    }
                }
            }
        }

        static MP3Player GetMP3Player(int id)
        {
            MP3Player mp3Player;
            mp3Player.id = 1;
            mp3Player.make = "GET technologies .inc";
            mp3Player.model = "HF 410";
            mp3Player.mbSize = 4096;
            mp3Player.price = 129.95f;
            return mp3Player;
        }

		static string Login()
		{
			var attemptsLeft = ALLOWED_AUTHENTICATION_ATTEMPTS;

			while (true)
			{
				if (attemptsLeft == 1)
					Console.WriteLine("(LET OP: Laatste poging!)");
				else
					Console.WriteLine("(Poging " + attemptsLeft + " van " + ALLOWED_AUTHENTICATION_ATTEMPTS + ")");

				Console.WriteLine("Vul het juiste wachtwoord in:");
				var password = Console.ReadLine();
				Console.Clear();

				if (password == "")
					return "Onbekend";
				else if (password == "SHARPSOUND")
					return "OK";

				if (--attemptsLeft <= 0)
					break;

				Console.WriteLine("Dit wachtwoord is onjuist, probeert u het opnieuw.");
			}

			return "NietOK";
		}
	}
}

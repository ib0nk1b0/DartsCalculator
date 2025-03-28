namespace DartsCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }
        
        struct Player(string name, int score)
        {
            public string name = name;
            public int score = score;
        }

        static void StartGame()
        {
            Console.Clear();
            Console.Write("Enter number of players: ");
            string? input = Console.ReadLine();
            if (input == null)
                input = "";

            if (int.TryParse(input, out int numPlayers))
            {
                PlayGame(numPlayers);
            }
            else if (input.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
            {
                Environment.Exit(0);
            }
            else
            {
                StartGame();
            }
        }

        static void PlayGame(int numPlayers)
        {
            if (numPlayers <= 0)
            {
                return;
            }

            List<Player> players = new List<Player>();

            for (int i = 0; i < numPlayers; i++)
            {
                Console.Write($"Enter Name of Player {i + 1}: ");
                string? name = Console.ReadLine();
                if (string.IsNullOrEmpty(name))
                    name = "Player " + i;
                players.Add(new Player(name, 501));
            }
            bool gameWon = false;
            while (!gameWon)
            {
                for (int i = 0; i < numPlayers; i++)
                {
                    if (gameWon)
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine("Play 501");
                    Player currentPlayer = players[i];
                    for (int j = 0; j < numPlayers; j++)
                    {
                        Console.WriteLine($"{players[j].name} - {players[j].score}");
                    }
                    Console.Write($"Enter Player {i + 1} score: ");
                    int score;
                    while (!int.TryParse(Console.ReadLine(), out score) || score > currentPlayer.score)
                    {
                        Console.Write($"Enter Player {i + 1} score: ");
                    }
                    currentPlayer.score -= score;
                    players[i] = currentPlayer;

                    if (currentPlayer.score == 0)
                    {
                        gameWon = true;
                    }
                }
            }

            Console.WriteLine("Game Over! Press any key to start over...");
            Console.ReadKey();
            StartGame();
        }
    }
}

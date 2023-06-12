using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace MathTricks
{
    static public class Game
    {
        private static Grid grid;
        public static List<Player> players = new List<Player>();
        private static int turn = 0;
        private static int game = 1;
        public static int initialScore;
        public static int playersCount;

        static public void Run()
        {
            grid = new Grid();
            Console.Clear();
            Console.WriteLine(grid.ToString());

            grid.FillGrid();
            grid.AddPlayers(players);
            grid.ManageAdjecentCells();

            while (true)// actual game loop
            {
                turn++;
                for (int i = 0; i < playersCount; i++)
                {
                    if (players.Where(p => p.Surrendered || p.HasNoMoreViableMoves()).ToList().Count >= playersCount - 1)
                        PrintGameSummary(GetWinner(), players.Where(p => p != GetWinner()).ToList());

                    PrintTurnText(players[i]);
                    if (players[i].Surrendered || players[i].HasNoMoreViableMoves()) continue;
                    else players[i].TakeTurn(Console.ReadKey(true).Key);
                }
            }
        }
        public static void PrintGameSummary(Player winner, List<Player> losers)
        {
            Console.SetCursorPosition(0, grid.Height * 2 + 2);
            Console.WriteLine("---------- GAME SUMMARY ----------" + new string(' ', 75));
            Console.WriteLine($"WINNER: {winner.Name} [{winner.Score:f2}]" + new string(' ', 75));
            for (int i = 0; i < losers.Count; i++) Console.WriteLine($"LOSER: {losers[i].Name} [{losers[i].Score:f2}]" + new string(' ', 75));
            Console.WriteLine($"TURNS: {turn}" + new string(' ', 100));
            Console.WriteLine(new string(' ', 100));
            Console.WriteLine($"NEW GAME? CLICK ENTER TO TRY AGAIN!" + new string(' ', 200));
            Console.WriteLine(new string(' ', 150));
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                for (int i = 0; i < playersCount; i++) players[i].Score = initialScore;
                turn = 0;
                game++;
                Run();
            }
            else Environment.Exit(0);
        }
        public static void PrintTurnText(Player player)
        {
            Console.SetCursorPosition(0, 2 * grid.Height + 2);
            Console.Write($"Game: {game} [");
            for (int i = 0; i < playersCount; i++)
            {
                Console.BackgroundColor = players[i].Color;
                Console.Write($"{players[i].Wins}");
                Console.ResetColor();
                if (i!=playersCount-1) Console.Write($":");
            }
            Console.WriteLine($"] Turn: {turn}");
            for (int i = 0; i < playersCount; i++)
            {
                Console.BackgroundColor = players[i].Color;
                Console.WriteLine($"{players[i].Name}'s score is {players[i].Score:f2}  ");
            }
            Console.ResetColor();
            Console.BackgroundColor = player.Color;
            Console.WriteLine($"\nWaiting for {player.Name}...");
            Console.WriteLine($"NumPad 1 - down left diagonal | NumPad 2 - down | NumPad 3 - down right diagonal");
            Console.WriteLine($"NumPad 4 - left            | escape to surrender | NumPad 6 - right             ");
            Console.WriteLine($"NumPad 7 - up left diagonal   | NumPad 8 - up   | NumPad 9 - up right diagonal  ");
            Console.ResetColor();
        }
        public static Player GetWinner()
        {
            Player winner = players.Where(p => !p.Surrendered).OrderByDescending(p => p.Score).FirstOrDefault();
            winner.Wins++;
            return winner;
        }
        public static void GetPlayersCount()
        {
            Console.WriteLine("WELCOME TO MATHTRICKS");
            Console.WriteLine("Number of players:  (2/4)");
            Console.WriteLine("Initial score:  (0-9)");
            Console.SetCursorPosition(18, 1);

            while (!int.TryParse(Console.ReadLine(), out playersCount) || (playersCount != 2 && playersCount != 4))
            {
                Console.SetCursorPosition(18, 1);
                Console.Write("  (2/4)" + new string(' ', 50));
                Console.SetCursorPosition(18, 1);
            }
        }
        public static void GetPlayersInitialScore()
        {
            Console.SetCursorPosition(14, 2);
            while (!int.TryParse(Console.ReadLine(), out initialScore) || initialScore < 0 || initialScore > 9)
            {
                Console.SetCursorPosition(14, 2);
                Console.Write("  (0-9)" + new string(' ', 50));
                Console.SetCursorPosition(14, 2);
            }
        }
        public static void RegistratePlayers()
        {
            ConsoleColor color;
            string name;
            for (int i = 1; i <= playersCount; i++)
            {
                Console.Clear();
                Console.WriteLine($"WELCOME PLAYER {i}");
                Console.WriteLine("Name: ");
                Console.WriteLine("Color: ");
                Console.SetCursorPosition(5, 1);
                name = Console.ReadLine();
                Console.SetCursorPosition(6, 2);
                while (!Enum.TryParse(Console.ReadLine(), true, out color))
                {
                    Console.SetCursorPosition(6, 2);
                    Console.Write(new string(' ', 50));
                    Console.SetCursorPosition(6, 2);
                }
                players.Add(new Player(name, color, initialScore));
            }
        }
    }
}

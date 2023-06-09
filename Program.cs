using System;

namespace MathTricks
{
    public class Program
    {
        private static Player player1 = new Player("player1", ConsoleColor.Red);
        private static Player player2 = new Player("player2", ConsoleColor.Blue);
        private static Grid grid;
        private static int turn = 0;
        static void Main()
        {
            grid = new Grid();
            Console.Clear();
            Console.WriteLine(grid.ToString());

            grid.FillGrid();
            grid.AddPlayers(player1, player2);
            grid.ManageAdjecentCells();

            while (true) // actual game loop
            {
                turn++;
                PrintGameInitials();
                do
                {
                    PrintTurnText(player1);
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (player1.HasSurrendered(key)) PrintGameSummary(player2, player1, $"{player1.Name} has surrendered");
                    if (player1.TakeTurn(key)) break;
                } while (true);


                PrintGameInitials();
                do
                {
                    PrintTurnText(player2);
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (player2.HasSurrendered(key)) PrintGameSummary(player1, player2, $"{player2.Name} has surrendered");
                    if (player2.TakeTurn(key)) break;
                } while (true);

                if (GameHasFinished()) PrintGameSummary(GetWinner(), GetLoser(), GetGameEndReason());
            }
        }
        private static bool GameHasFinished()
        {
            if (player1.HasNoMoreViableMoves() || player2.HasNoMoreViableMoves()) return true;
            else return false;
        }
        private static Player GetWinner()
        {
            if (player1.HasNoMoreViableMoves() && player2.HasNoMoreViableMoves()) // both players don't have any viable moves on this turn and we must compare their score to decide the winner
            {
                if (player1.Score > player2.Score) return player1;
                else if (player2.Score > player1.Score) return player2;
                else return null;
            }
            
            if (player2.HasNoMoreViableMoves()) return player1;// the second player is stuck
            else if (player1.HasNoMoreViableMoves()) return player2;// the first player is stuck

            else return null;// this code should never be reached
        }
        private static Player GetLoser()
        {
            if (player1.HasNoMoreViableMoves() && player2.HasNoMoreViableMoves()) // both players don't have any viable moves on this turn and we must compare their score to decide the winner
            {
                if (player1.Score > player2.Score) return player2;
                else if (player2.Score > player1.Score) return player1;
                else return null;
            }

            if (player2.HasNoMoreViableMoves()) return player2;// the second player is stuck
            else if (player1.HasNoMoreViableMoves()) return player1;// the first player is stuck

            else return null;// this code should never be reached
        }
        private static string GetGameEndReason()
        {
            // both players don't have any viable moves on this turn and we must compare their score to decide the winner
            if (player1.HasNoMoreViableMoves() && player2.HasNoMoreViableMoves()) return "Score victory";
            else if (player2.HasNoMoreViableMoves()) return $"{player2.Name} is stuck";// the second player is stuck
            else if (player1.HasNoMoreViableMoves()) return $"{player1.Name} is stuck";// the first player is stuck

            else return null;// this code should never be reached
        }
        private static void PrintGameSummary(Player winner, Player loser, string reason)
        {
            Console.SetCursorPosition(0, grid.Height * 2 + 2);
            Console.WriteLine("---------- GAME SUMMARY ----------" + new string(' ', 75));
            Console.WriteLine($"WINNER: {winner.Name} [{winner.Score:f2}]" + new string(' ', 75));
            Console.WriteLine($"LOSER: {loser.Name} [{loser.Score:f2}]" + new string(' ', 75));
            Console.WriteLine(reason + new string(' ', 75));
            Console.WriteLine($"TURNS: {turn}" + new string(' ', 75));
            Console.WriteLine(new string(' ', 125));
            Console.WriteLine($"NEW GAME? CLICK ENTER TO TRY AGAIN!");
            if (Console.ReadKey(true).Key == ConsoleKey.Enter) 
            {
                player1.Score = 10;
                player2.Score = 10;
                turn = 0;
                Main(); 
            }
            else Environment.Exit(0);
        }
        private static void PrintGameInitials()
        {
            Console.SetCursorPosition(0, 2 * grid.Height + 2);
            Console.WriteLine($"Turn: {turn}");
            Console.BackgroundColor = player1.Color;
            Console.WriteLine($"{player1.Name}'s score is {player1.Score:f2}  ");
            Console.BackgroundColor = player2.Color;
            Console.WriteLine($"{player2.Name}'s score is {player2.Score:f2}  ");
            Console.ResetColor();
        }
        private static void PrintTurnText(Player player)
        {
            Console.SetCursorPosition(0, 2 * grid.Height + 5);
            Console.WriteLine(new string(' ', 100));
            Console.BackgroundColor = player.Color;
            Console.WriteLine($"Waiting for {player.Name}...");
            Console.WriteLine($"Use the number pad to move and esc to surrender");
            Console.ResetColor();
        }
    }
}

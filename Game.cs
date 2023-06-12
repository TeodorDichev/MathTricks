using System;

namespace MathTricks
{
    static public class Game
    {
        private static Player player1 = new Player("player1", ConsoleColor.Red, initialScore);
        private static Player player2 = new Player("player2", ConsoleColor.Blue, initialScore);
        private static Grid grid;
        private static int turn = 0;
        private static int game = 1;
        private const int initialScore = 10;

        static public void Run()
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
                do
                {
                    PrintTurnText(player1);
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (player1.HasSurrendered(key)) PrintGameSummary(player2, player1, $"{player1.Name} has surrendered");
                    if (player1.TakeTurn(key)) break;
                } while (true);

                //In case after the first player has made their turn and has blocked the moves of the other player
                //GameHasFinished() does not work because it will not allow the second player to make their last move
                if (player2.HasNoMoreViableMoves()) PrintGameSummary(GetWinner(), GetLoser(), GetGameEndReason());

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
        static string GetGameEndReason()
        {
            // both players don't have any viable moves on this turn and we must compare their score to decide the winner
            if (player1.HasNoMoreViableMoves() && player2.HasNoMoreViableMoves()) return "Score victory";
            else if (player2.HasNoMoreViableMoves()) return $"{player2.Name} is stuck";// the second player is stuck
            else if (player1.HasNoMoreViableMoves()) return $"{player1.Name} is stuck";// the first player is stuck

            else return null;// this code should never be reached
        }
        static void PrintGameSummary(Player winner, Player loser, string reason)
        {
            Console.SetCursorPosition(0, grid.Height * 2 + 2);
            Console.WriteLine("---------- GAME SUMMARY ----------" + new string(' ', 75));
            Console.WriteLine($"WINNER: {winner.Name} [{winner.Score:f2}]" + new string(' ', 75));
            Console.WriteLine($"LOSER: {loser.Name} [{loser.Score:f2}]" + new string(' ', 75));
            Console.WriteLine(reason + new string(' ', 75));
            Console.WriteLine($"TURNS: {turn}" + new string(' ', 100));
            Console.WriteLine(new string(' ', 100));
            Console.WriteLine($"NEW GAME? CLICK ENTER TO TRY AGAIN!" + new string(' ', 200));
            Console.WriteLine(new string(' ', 150));
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                player1.Score = initialScore;
                player2.Score = initialScore;
                turn = 0;
                game++;
                Run();
            }
            else Environment.Exit(0);
        }
        static void PrintTurnText(Player player)
        {
            Console.SetCursorPosition(0, 2 * grid.Height + 2);
            Console.Write($"Game: {game} [");
            Console.BackgroundColor = player1.Color;
            Console.Write($"{player1.Wins}");
            Console.ResetColor();
            Console.Write($":");
            Console.BackgroundColor = player2.Color;
            Console.Write($"{player2.Wins}");
            Console.ResetColor();
            Console.WriteLine($"]| Turn: {turn}");
            Console.BackgroundColor = player1.Color;
            Console.WriteLine($"{player1.Name}'s score is {player1.Score:f2}  ");
            Console.BackgroundColor = player2.Color;
            Console.WriteLine($"{player2.Name}'s score is {player2.Score:f2}  ");
            Console.ResetColor();
            Console.BackgroundColor = player.Color;
            Console.WriteLine($"\nWaiting for {player.Name}...");
            Console.WriteLine($"NumPad 1 - down left diagonal | NumPad 2 - down | NumPad 3 - down right diagonal");
            Console.WriteLine($"NumPad 4 - left            | escape to surrender | NumPad 6 - right             ");
            Console.WriteLine($"NumPad 7 - up left diagonal   | NumPad 8 - up   | NumPad 9 - up right diagonal  ");
            Console.ResetColor();
        }
        static Player GetLoser()
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
        static bool GameHasFinished()
        {
            if (player1.HasNoMoreViableMoves() || player2.HasNoMoreViableMoves()) return true;
            else return false;
        }
        static Player GetWinner()
        {
            if (player1.HasNoMoreViableMoves() && player2.HasNoMoreViableMoves()) // both players don't have any viable moves on this turn and we must compare their score to decide the winner
            {
                if (player1.Score > player2.Score) { player1.Wins++; return player1; }
                else if (player2.Score > player1.Score) { player2.Wins++; return player2; }
                else return null;
            }

            if (player2.HasNoMoreViableMoves()) { player1.Wins++; return player1; }// the second player is stuck
            else if (player1.HasNoMoreViableMoves()) { player2.Wins++; return player2; }// the first player is stuck

            else return null;// this code should never be reached
        }
    }
}

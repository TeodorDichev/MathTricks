using System;
using System.Linq;

namespace MathTricks
{
    public class Player
    {
        private string name;
        private ConsoleColor color;
        private double score;
        private int wins;
        private Cell currCell;
        private Cell selectedCell;

        public Player(string name, ConsoleColor color, double score)
        {
            this.Name = name;
            this.Color = color;
            this.Score = score;
            this.Wins = 0;
        }
        public bool HasNoMoreViableMoves()
        {
            return CurrCell.AdjeicentCells.All(x => x.Captured);
        }
        public bool HasSurrendered(ConsoleKey key)
        {
            return key == ConsoleKey.Escape;
        }
        public bool TakeTurn(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.NumPad1://left down diagonal
                    SelectedCell = CurrCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == CurrCell.Width - 5 && x.Height == CurrCell.Height + 2);

                    if (Move()) return true;
                    else return false;

                case ConsoleKey.NumPad2://down straight
                    SelectedCell = CurrCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == CurrCell.Width && x.Height == CurrCell.Height + 2);

                    if (Move()) return true;
                    else return false;

                case ConsoleKey.NumPad3://right down diagonal
                    SelectedCell = CurrCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == CurrCell.Width + 5 && x.Height == CurrCell.Height + 2);

                    if (Move()) return true;
                    else return false;

                case ConsoleKey.NumPad4://left side
                    SelectedCell = CurrCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == CurrCell.Width - 5 && x.Height == CurrCell.Height);

                    if (Move()) return true;
                    else return false;

                case ConsoleKey.NumPad6://right side
                    SelectedCell = CurrCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == CurrCell.Width + 5 && x.Height == CurrCell.Height);

                    if (Move()) return true;
                    else return false;

                case ConsoleKey.NumPad7://left up diagonal
                    SelectedCell = CurrCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == CurrCell.Width - 5 && x.Height == CurrCell.Height - 2);

                    if (Move()) return true;
                    else return false;

                case ConsoleKey.NumPad8://straight up
                    SelectedCell = CurrCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == CurrCell.Width && x.Height == CurrCell.Height - 2);

                    if (Move()) return true;
                    else return false;

                case ConsoleKey.NumPad9://right up diagonal
                    SelectedCell = CurrCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == CurrCell.Width + 5 && x.Height == CurrCell.Height - 2);

                    if (Move()) return true;
                    else return false;

                default:
                    return false;
            }
        }
        private void AdjustScore(char operation, int number)
        {
            switch (operation)
            {
                case '+':
                    Score += number;
                    break;
                case '-':
                    Score -= number;
                    break;
                case '/':
                    Score /= number;
                    break;
                case '*':
                    Score *= number;
                    break;
            }
        }
        private bool Move()
        {
            if (SelectedCell is null || SelectedCell.Captured) return false;

            Console.BackgroundColor = Color;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(CurrCell.Width, CurrCell.Height);
            Console.Write(CurrCell.Operation.ToString() + CurrCell.Number.ToString());

            Console.BackgroundColor = Color;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(SelectedCell.Width, SelectedCell.Height);
            Console.Write(SelectedCell.Operation.ToString() + SelectedCell.Number.ToString());
            Console.ResetColor();
            SelectedCell.Captured = true;
            AdjustScore(SelectedCell.Operation, SelectedCell.Number);
            CurrCell = SelectedCell;
            return true;
        }
        public void SetStartPosition(Cell cell)
        {
            Console.SetCursorPosition(cell.Width, cell.Height);
            CurrCell = cell;
            Console.BackgroundColor = Color;
            Console.Write("p" + Name.Last());
            Console.ResetColor();
        }
        public Cell CurrCell
        {
            get { return currCell; }
            set { currCell = value; }
        }
        public Cell SelectedCell
        {
            get { return selectedCell; }
            set { selectedCell = value; }
        }
        public int Wins
        {
            get { return wins; }
            set { wins = value; }
        }
        public double Score
        {
            get { return score; }
            set { score = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
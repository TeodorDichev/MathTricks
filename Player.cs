using System;
using System.Linq;

namespace MathTricks
{
    public class Player
    {
        private string name;
        private ConsoleColor color;
        private double score;
        private Cell currCell;
        private Cell selectedCell;

        public Player(string name, ConsoleColor color)
        {
            this.Name = name;
            this.Color = color;
            Score = 10;
        }
        public Player() { }
        public bool HasNoMoreViableMoves()
        {
            return currCell.AdjeicentCells.All(x => x.Captured);
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
                    selectedCell = currCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == currCell.Width - 5 && x.Height == currCell.Height + 2);

                    if (selectedCell is null || selectedCell.Captured) return false;

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(currCell.Width, currCell.Height);
                    Console.Write(currCell.Operation.ToString() + currCell.Number.ToString());

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(selectedCell.Width, selectedCell.Height);
                    Console.Write(selectedCell.Operation.ToString() + selectedCell.Number.ToString());
                    Console.ResetColor();
                    selectedCell.Captured = true;
                    AdjustScore(selectedCell.Operation, selectedCell.Number);
                    currCell = selectedCell;
                    return true;

                case ConsoleKey.NumPad2://down straight
                    selectedCell = currCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == currCell.Width && x.Height == currCell.Height + 2);

                    if (selectedCell is null || selectedCell.Captured) return false;

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(currCell.Width, currCell.Height);
                    Console.Write(currCell.Operation.ToString() + currCell.Number.ToString());

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(selectedCell.Width, selectedCell.Height);
                    Console.Write(selectedCell.Operation.ToString() + selectedCell.Number.ToString());
                    Console.ResetColor();
                    selectedCell.Captured = true;
                    AdjustScore(selectedCell.Operation, selectedCell.Number);
                    currCell = selectedCell;
                    return true;

                case ConsoleKey.NumPad3://right down diagonal
                    selectedCell = currCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == currCell.Width + 5 && x.Height == currCell.Height + 2);

                    if (selectedCell is null || selectedCell.Captured) return false;

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(currCell.Width, currCell.Height);
                    Console.Write(currCell.Operation.ToString() + currCell.Number.ToString());

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(selectedCell.Width, selectedCell.Height);
                    Console.Write(selectedCell.Operation.ToString() + selectedCell.Number.ToString());
                    Console.ResetColor();
                    selectedCell.Captured = true;
                    AdjustScore(selectedCell.Operation, selectedCell.Number);
                    currCell = selectedCell;
                    return true;

                case ConsoleKey.NumPad4://left side
                    selectedCell = currCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == currCell.Width - 5 && x.Height == currCell.Height);

                    if (selectedCell is null || selectedCell.Captured) return false;

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(currCell.Width, currCell.Height);
                    Console.Write(currCell.Operation.ToString() + currCell.Number.ToString());

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(selectedCell.Width, selectedCell.Height);
                    Console.Write(selectedCell.Operation.ToString() + selectedCell.Number.ToString());
                    Console.ResetColor();
                    selectedCell.Captured = true;
                    AdjustScore(selectedCell.Operation, selectedCell.Number);
                    currCell = selectedCell;
                    return true;

                case ConsoleKey.NumPad6://right side
                    selectedCell = currCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == currCell.Width + 5 && x.Height == currCell.Height);

                    if (selectedCell is null || selectedCell.Captured) return false;

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(currCell.Width, currCell.Height);
                    Console.Write(currCell.Operation.ToString() + currCell.Number.ToString());

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(selectedCell.Width, selectedCell.Height);
                    Console.Write(selectedCell.Operation.ToString() + selectedCell.Number.ToString());
                    Console.ResetColor();
                    selectedCell.Captured = true;
                    AdjustScore(selectedCell.Operation, selectedCell.Number);
                    currCell = selectedCell;
                    return true;

                case ConsoleKey.NumPad7://left up diagonal
                    selectedCell = currCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == currCell.Width - 5 && x.Height == currCell.Height - 2);

                    if (selectedCell is null || selectedCell.Captured) return false;
                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(currCell.Width, currCell.Height);
                    Console.Write(currCell.Operation.ToString() + currCell.Number.ToString());

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(selectedCell.Width, selectedCell.Height);
                    Console.Write(selectedCell.Operation.ToString() + selectedCell.Number.ToString());
                    Console.ResetColor();
                    selectedCell.Captured = true;
                    AdjustScore(selectedCell.Operation, selectedCell.Number);
                    currCell = selectedCell;
                    return true;

                case ConsoleKey.NumPad8://straight up
                    selectedCell = currCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == currCell.Width && x.Height == currCell.Height - 2);

                    if (selectedCell is null || selectedCell.Captured) return false;

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(currCell.Width, currCell.Height);
                    Console.Write(currCell.Operation.ToString() + currCell.Number.ToString());

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(selectedCell.Width, selectedCell.Height);
                    Console.Write(selectedCell.Operation.ToString() + selectedCell.Number.ToString());
                    Console.ResetColor();
                    selectedCell.Captured = true;
                    AdjustScore(selectedCell.Operation, selectedCell.Number);
                    currCell = selectedCell;
                    return true;

                case ConsoleKey.NumPad9://right up diagonal
                    selectedCell = currCell.AdjeicentCells
                        .FirstOrDefault(x => x.Width == currCell.Width + 5 && x.Height == currCell.Height - 2);

                    if (selectedCell is null || selectedCell.Captured) return false;

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(currCell.Width, currCell.Height);
                    Console.Write(currCell.Operation.ToString() + currCell.Number.ToString());

                    Console.BackgroundColor = Color;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(selectedCell.Width, selectedCell.Height);
                    Console.Write(selectedCell.Operation.ToString() + selectedCell.Number.ToString());
                    Console.ResetColor();
                    selectedCell.Captured = true;
                    AdjustScore(selectedCell.Operation, selectedCell.Number);
                    currCell = selectedCell;
                    return true;

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
        public void SetStartPosition(Cell cell)
        {
            Console.SetCursorPosition(cell.Width, cell.Height);
            currCell = cell;
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
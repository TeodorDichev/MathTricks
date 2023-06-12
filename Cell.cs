using System;
using System.Collections.Generic;
using System.Text;

namespace MathTricks
{
    public class Cell
    {
		private int width;
		private int height;
		private bool captured;
		private ConsoleColor color;
		private char operation;
		private int number;
        private List<Cell> adjeicentCells;

        public override string ToString()
        {
            StringBuilder cell = new StringBuilder();
            Console.SetCursorPosition(Width, Height);
            cell.Append(Operation.ToString() + Number.ToString());

            return cell.ToString();
        }
        public Cell(int width, int height, bool captured, ConsoleColor color, char operation, int number)
        {
			AdjeicentCells = new List<Cell>();
			Captured = captured;
			Width = width;
			Height = height;
			Color = color;
			Operation = operation;
            Number = number;
        }
        public int Width
		{
			get { return width; }
			set { width = value; }
		}
		public int Height
		{
			get { return height; }
			set { height = value; }
		}
		public bool Captured
        {
			get { return captured; }
			set { captured = value; }
		}
		public ConsoleColor Color
        {
			get { return color; }
			set { color = value; }
		}
		public char Operation
        {
			get { return operation; }
			set { operation = value; }
		}
		public int Number
        {
			get { return number; }
			set { number = value; }
		}
		public List<Cell> AdjeicentCells
        {
			get { return adjeicentCells; }
			set { adjeicentCells = value; }
		}
	}
}

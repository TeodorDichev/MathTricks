using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathTricks
{
    public class Grid
    {
		private int width;
		private int height;
        private List<Cell> cells;

        public Grid()
        {
            int[] dimensions = GetGridDimensions();
            Width = dimensions[0];
            Height = dimensions[1];

            Cells = new List<Cell>();
        }
        public void ManageAdjecentCells()
        {
            int topLeft = 0;
            int topRight = Width - 1;
            int bottomLeft = Width * (Height - 1);
            int bottomRight = Height * Width - 1;

            for (int i = 0; i < Cells.Count; i++)
            {
                if (i == topLeft)
                {
                    Cells.ElementAt(topLeft).AdjeicentCells
                        .Add(Cells.ElementAt(topLeft + 1));//right
                    Cells.ElementAt(topLeft).AdjeicentCells
                        .Add(Cells.ElementAt(topLeft + Width));//down
                    Cells.ElementAt(topLeft).AdjeicentCells
                        .Add(Cells.ElementAt(topLeft + Width + 1));//down right

                }//top left corner
                else if (i == topRight)
                {
                    Cells.ElementAt(topRight).AdjeicentCells
                        .Add(Cells.ElementAt(topRight - 1));//left
                    Cells.ElementAt(topRight).AdjeicentCells
                        .Add(Cells.ElementAt(topRight + Width - 1));//down left
                    Cells.ElementAt(topRight).AdjeicentCells
                        .Add(Cells.ElementAt(topRight + Width));//down

                }//top right corner
                else if (i == bottomLeft)
                {
                    Cells.ElementAt(bottomLeft).AdjeicentCells
                        .Add(Cells.ElementAt(bottomLeft - Width));//up
                    Cells.ElementAt(bottomLeft).AdjeicentCells
                        .Add(Cells.ElementAt(bottomLeft - Width + 1));//up right
                    Cells.ElementAt(bottomLeft).AdjeicentCells
                        .Add(Cells.ElementAt(bottomLeft + 1));//right
                }//bottom left corner
                else if (i == bottomRight)
                {
                    Cells.ElementAt(bottomRight).AdjeicentCells
                        .Add(Cells.ElementAt(bottomRight - Width - 1));//up left
                    Cells.ElementAt(bottomRight).AdjeicentCells
                        .Add(Cells.ElementAt(bottomRight - Width));//up
                    Cells.ElementAt(bottomRight).AdjeicentCells
                        .Add(Cells.ElementAt(bottomRight - 1));//left
                }//bottom right corner
                else if (i > topLeft && i < topRight && i < Width)
                {
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - 1));//left
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + 1));//right
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + Width - 1));//down left
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + Width));//down
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + Width + 1));//down right
                }//top row
                else if (i > bottomLeft && i < bottomRight && i > Width*(Height-1))
                {
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - Width - 1));//up left
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - Width));//up
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - Width + 1));//up right
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - 1));//left
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + 1));//right
                }//bottom row
                else if (i > topLeft && i < bottomRight && Cells.ElementAt(i).Width == 1)
                {
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - Width));//up
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - Width + 1));//up right
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + 1));//right
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + Width));//down
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + Width + 1));//down right
                }//left column
                else if (i > topLeft && i < bottomRight && Cells.ElementAt(i).Width == 1 + 5 * (Width - 1))
                {
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - Width - 1));//up left
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - Width));//up
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - 1));//left
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + Width - 1));//down left
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + Width));//down
                }//right column
                else
                {
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - Width - 1));//up left
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - Width));//up
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - Width + 1));//up right
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i - 1));//left
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + 1));//right
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + Width - 1));//down left
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + Width));//down
                    Cells.ElementAt(i).AdjeicentCells
                        .Add(Cells.ElementAt(i + Width + 1));//down right
                }//all middle ones
            }
        }
        public void FillGrid()
        {
            string operations = "+++--/*";
            Random r = new Random();

            for (int j = Height; j > 0; j--)
                for (int i = Width; i > 0; i--)
                {
                    Cell cell = new Cell
                        (1 + 5 * (Width - i), 
                        1 + 2 * (Height - j),
                        false,
                        ConsoleColor.DarkGray,
                        operations[r.Next(0, 7)],
                        r.Next(1, 6));

                    Cells.Add(cell);
                    Console.BackgroundColor = cell.Color;
                    Console.Write(cell.ToString());
                    Console.ResetColor();
                }
        }
        public void AddPlayers(Player[] players)
        {
            if (Game.playersCount == 2)
            {
                Game.players[0].SetStartPosition(cells[0]);
                Game.players[1].SetStartPosition(cells[width * height - 1]);
            }
            else
            {
                Game.players[0].SetStartPosition(cells[0]);
                Game.players[1].SetStartPosition(cells[width - 1]);
                Game.players[2].SetStartPosition(cells[width * (height - 1)]);
                Game.players[3].SetStartPosition(cells[width * height - 1]);
            }
        }
        public override string ToString()
        {
            StringBuilder grid = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    grid.Append("+--+ ");
                }
                grid.AppendLine();
                for (int j = 0; j < Width; j++)
                {
                    grid.Append("|  | ");
                }
                grid.AppendLine();
            }
            for (int j = 0; j < Width; j++)
            {
                grid.Append("+--+ ");
            }
            grid.AppendLine();
            return grid.ToString();
        }
        private int[] GetGridDimensions()
        {
            bool invalidInput = false;
            int width = 0;
            int height = 0;
            do
            {
                invalidInput = false;
                Console.Clear();
                try
                {
                    Console.WriteLine("Enter grid dimensions (3-12)");
                    Console.Write("Grid width: ");
                    width = int.Parse(Console.ReadLine());
                    Console.Write("Grid height: ");
                    height = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    invalidInput = true;
                }
                if (!invalidInput && (width < 3 || height < 3 || width > 12 || height > 12))
                {
                    invalidInput = true;
                }
            } while (invalidInput);
            return new int[] { width, height };
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
		public List<Cell> Cells
        {
			get { return cells; }
			set { cells = value; }
		}
	}
}
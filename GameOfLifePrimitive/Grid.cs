using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifePrimitive
{
    internal class Grid
    {
        private bool[,] values;
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public bool Wrap { get; set; }
        public bool ShowGrid { get; set; }
        public Grid(int rows, int columns)
        {
            values = new bool[rows, columns];
            Rows = rows;
            Columns = columns;
            Wrap = false;
            ShowGrid = true;
        }
        public Grid() : this(36, 36)
        {
        }
        public void Randomize(double percent)
        {
            Random random = new Random();
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    if (random.NextDouble() < percent)
                    {
                        values[row, column] = true;
                    }
                    else
                    {
                        values[row, column] = false;
                    }
                }
            }
        }
        private bool IsCellAliveWrapped(int row, int column)
        {
            row = (row + Rows) % Rows;
            column = (column + Columns) % Columns;
            return values[row, column];
        }
        private bool IsCellAliveUnwrapped(int row, int column)
        {
            if(row < 0)
            {
                return false;
            }
            if(row >= Rows)
            {
                return false;
            }
            if(column < 0)
            {
                return false;
            }
            if(column >= Columns)
            {
                return false;
            }
            return values[row, column];
        }
        private bool IsCellAlive(int row, int column)
        {
            if(Wrap)
            {
                return IsCellAliveWrapped(row, column);
            }
            else
            {
                return IsCellAliveUnwrapped(row, column);
            }
        }
        public int CountNeighbors(int row, int column)
        {
            var count = 0;
            if(IsCellAlive(row - 1, column - 1))
            {
                count++;
            }
            if(IsCellAlive(row - 1, column))
            {
                count++;
            }
            if(IsCellAlive(row, column - 1))
            {
                count++;
            }
            if(IsCellAlive(row + 1, column - 1))
            {
                count++;
            }
            if (IsCellAlive(row - 1, column + 1))
            {
                count++;
            }
            if (IsCellAlive(row + 1, column))
            {
                count++;
            }
            if(IsCellAlive(row, column + 1))
            {
                count++;
            }
            if(IsCellAlive(row + 1, column + 1))
            {
                count++;
            }
            return count;
        }
        public void Update()
        {
            bool[,] nextGeneration = new bool[Rows, Columns];
            for (int row = 0; row < Rows; row++)
            {
                for(int column = 0; column < Columns; column++)
                {
                    var count = CountNeighbors(row, column);
                    var isCurrentlyAlive = values[row, column];
                    if(isCurrentlyAlive && count > 3)
                    {
                        isCurrentlyAlive = false;
                    }
                    else if(isCurrentlyAlive && count < 2)
                    {
                        isCurrentlyAlive = false;
                    }
                    else if (!isCurrentlyAlive && count == 3)
                    {
                        isCurrentlyAlive = true;
                    }
                    nextGeneration[row, column] = isCurrentlyAlive;
                }
            }
            values = nextGeneration;
        }
        public void Draw()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("███");
            for (int column = 0; column < Columns + 1; column++)
            {
                Console.Write("██");
            }
            Console.WriteLine();
            for(int row = 0; row < Rows; row++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("██ ");
                for (int column = 0; column < Columns; column++)
                {
                    var alive = values[row, column];
                    if(alive)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("O ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        if(ShowGrid)
                        {
                            Console.Write(". ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("██");
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("███");
            for (int column = 0; column < Columns + 1; column++)
            {
                Console.Write("██");
            }
            Console.WriteLine();
        }
        public void Set(int row, int column, bool on)
        {
            values[row, column] = on;
        }
        public void Clear()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    values[row, column] = false;
                }
            }
        }
    }
}

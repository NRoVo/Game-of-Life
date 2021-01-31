using System;

namespace GameOfLifePrimitive
{
    internal class Grid
    {
        private bool[,] _values;
        private int Rows { get; }
        private int Columns { get; }
        public bool Wrap { get; set; }
        public bool ShowGrid { get; set; }

        private Grid(int rows, int columns)
        {
            _values = new bool[rows, columns];
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
            var random = new Random();
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    if (random.NextDouble() < percent)
                    {
                        _values[row, column] = true;
                    }
                    else
                    {
                        _values[row, column] = false;
                    }
                }
            }
        }
        private bool IsCellAliveWrapped(int row, int column)
        {
            row = (row + Rows) % Rows;
            column = (column + Columns) % Columns;
            return _values[row, column];
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
            return _values[row, column];
        }
        private bool IsCellAlive(int row, int column)
        {
            return Wrap ? IsCellAliveWrapped(row, column) : IsCellAliveUnwrapped(row, column);
        }

        private int CountNeighbors(int row, int column)
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
            var nextGeneration = new bool[Rows, Columns];
            for (var row = 0; row < Rows; row++)
            {
                for(var column = 0; column < Columns; column++)
                {
                    var count = CountNeighbors(row, column);
                    var isCurrentlyAlive = _values[row, column];
                    switch (isCurrentlyAlive)
                    {
                        case true when count > 3:
                        case true when count < 2:
                            isCurrentlyAlive = false;
                            break;
                        case false when count == 3:
                            isCurrentlyAlive = true;
                            break;
                    }
                    nextGeneration[row, column] = isCurrentlyAlive;
                }
            }
            _values = nextGeneration;
        }
        public void Draw()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("███");
            for (var column = 0; column < Columns + 1; column++)
            {
                Console.Write("██");
            }
            Console.WriteLine();
            for(var row = 0; row < Rows; row++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("██ ");
                for (var column = 0; column < Columns; column++)
                {
                    var alive = _values[row, column];
                    if(alive)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("O ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(ShowGrid ? ". " : "  ");
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
            _values[row, column] = on;
        }
        public void Clear()
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var column = 0; column < Columns; column++)
                {
                    _values[row, column] = false;
                }
            }
        }
    }
}

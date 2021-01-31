using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GameOfLifePrimitive.Commands
{
    internal class PremadeCommand : ICommand
    {
        private readonly bool[,] _objectGrid;
        public string CommandText { get; }

        public string HelpText
        {
            get
            {
                var text = "";
                text += $"{CommandText}:\n";
                text += $"    Places a {CommandText} on the grid at a specific location.\n";
                text += $"    Usage: {CommandText} {{x}} {{y}}\n";
                text += $"    Example: {CommandText} 4 6\n";
                return text;
            }
        }
        private static int DetermineLongestLine(IEnumerable<string> lines)
        {
            return lines.Select(t => t.Length).Prepend(0).Max();
        }
        public PremadeCommand(string filename)
        {
            var lines = File.ReadAllLines(filename);
            var rows = lines.Length;
            CommandText = Path.GetFileNameWithoutExtension(filename);
            var maxLength = DetermineLongestLine(lines);
            _objectGrid = new bool[rows, maxLength];
            for(var row = 0; row < lines.Length; row++)
            {
                for(var column = 0; column < maxLength; column++)
                {
                    if (column >= lines[row].Length)
                    {
                        _objectGrid[row, column] = false;
                    }
                    else
                    {
                        _objectGrid[row, column] = (lines[row][column] == 'X');
                    }
                }
            }
        }
        public bool Execute(Grid grid, string[] parameters)
        {
            if (parameters.Length != 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error executing '{0}' command.", CommandText);
                Console.WriteLine("\n  Example: '{0} 3 7' will place the object at x=3, y=7.", CommandText);
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            try
            {
                var row = Convert.ToInt32(parameters[1]);
                var column = Convert.ToInt32(parameters[2]);
                for(var objectRow = 0; objectRow < this._objectGrid.GetLength(0); objectRow++)
                {
                    for(var objectColumn = 0; objectColumn < this._objectGrid.GetLength(1); objectColumn++)
                    {
                        grid.Set(row + objectRow, column + objectColumn, _objectGrid[objectRow, objectColumn]);
                    }
                }
                return true;
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not parse parameter.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
    }
}

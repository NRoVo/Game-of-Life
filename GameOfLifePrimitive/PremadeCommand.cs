using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameOfLifePrimitive
{
    internal class PremadeCommand : Command
    {
        private string name;
        private bool[,] objectGrid;
        public string CommandText
        {
            get
            {
                return name;
            }
        }
        public string HelpText
        {
            get
            {
                string text = "";
                text += name + ":\n";
                text += "    Places a " + name + " on the grid at a specific location.\n";
                text += "    Usage: " + name + " {x} {y}\n";
                text += "    Example: " + name + " 4 6\n";
                return text;
            }
        }
        private static int DetermineLongestLine(string[] lines)
        {
            var maxLength = 0;
            for(int index = 0; index < lines.Length; index++)
            {
                if(lines[index].Length > maxLength)
                {
                    maxLength = lines[index].Length;
                }
            }
            return maxLength;
        }
        public PremadeCommand(string filename)
        {
            var lines = File.ReadAllLines(filename);
            var rows = lines.Length;
            name = Path.GetFileNameWithoutExtension(filename);
            var maxLength = DetermineLongestLine(lines);
            objectGrid = new bool[rows, maxLength];
            for(int row = 0; row < lines.Length; row++)
            {
                for(int column = 0; column < maxLength; column++)
                {
                    if (column >= lines[row].Length)
                    {
                        objectGrid[row, column] = false;
                    }
                    else
                    {
                        objectGrid[row, column] = (lines[row][column] == 'X');
                    }
                }
            }
        }
        public bool Execute(Grid grid, string[] parameters)
        {
            if (parameters.Length != 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error executing '{0}' command.", name);
                Console.WriteLine("\n  Example: '{0} 3 7' will place the object at x=3, y=7.", name);
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            try
            {
                var row = Convert.ToInt32(parameters[1]);
                var column = Convert.ToInt32(parameters[2]);
                for(int objectRow = 0; objectRow < this.objectGrid.GetLength(0); objectRow++)
                {
                    for(int objectColumn = 0; objectColumn < this.objectGrid.GetLength(1); objectColumn++)
                    {
                        grid.Set(row + objectRow, column + objectColumn, objectGrid[objectRow, objectColumn]);
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

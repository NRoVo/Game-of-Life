using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifePrimitive
{
    internal class RandomizeCommand : Command
    {
        public string CommandText
        {
            get
            {
                return "randomize";
            }
        }
        public string HelpText
        {
            get
            {
                string text = "randomize:\n";
                text += "    Randomly turns all cells in the grid on or off.\n";
                text += "    Usage: randomize {percent}\n";
                text += "    Example: randomize .25";
                return text;
            }
        }
        public bool Execute(Grid grid, string[] parameters)
        {
            if(parameters.Length != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error executing 'randomize' command. Randomize must include an amount to fill and no other parameters.\n");
                Console.WriteLine("\n  Example: 'randomize 0.25' will randomly fill 25% of the grid with live cells.\n");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            try
            {
                var percent = Convert.ToDouble(parameters[1]);
                grid.Randomize(percent);
                return true;
            }
            catch(Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error interpreting '" + parameters[1] + "'. It is not a number.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
    }
}

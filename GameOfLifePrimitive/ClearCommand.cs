using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifePrimitive
{
    internal class ClearCommand : Command
    {
        public string CommandText 
        {
            get 
            {
                return "clear";
            }
        }
        public string HelpText
        {
            get 
            {
                var text = "clear:\n";
                text += "    Empties entire board.\n";
                text += "    Usage: clear";
                return text;
            }
        }
        public bool Execute(Grid grid, string[] parameters)
        {
            if(parameters.Length != 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error executing 'clear' command." +
                    "Clear must not have any parameters.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            grid.Clear();
            return true;
        }
    }
}

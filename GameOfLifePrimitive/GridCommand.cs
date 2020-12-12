using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifePrimitive
{
    internal class GridCommand : Command
    {
        public string CommandText
        {
            get
            {
                return "grid";
            }
        }
        public string HelpText
        {
            get
            {
                var text = "grid:\n";
                text += "    Turns the display of the grid on or off.\n";
                text += "    Usage: grid on|off";
                return text;
            }
        }
        public bool Execute(Grid grid, string[]parameters)
        {
            if(parameters.Length != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error executing grid command. This command must include the word");
                Console.WriteLine("'on' or 'off' as the first parameter.");
                Console.WriteLine("\n  Examples: 'grid on' will draw the grid.");
                Console.WriteLine("\n            'grid off' will turn off grid drawing.");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            try
            {
                var turnOn = true;
                if (parameters[1] == "on")
                {
                    turnOn = true;
                }
                else if (parameters[1] == "off")
                {
                    turnOn = false;
                }
                else throw new Exception("Error interpreting first parameter. Must be 'on' or 'off'.");
                grid.ShowGrid = turnOn;
                return true;
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
    }
}

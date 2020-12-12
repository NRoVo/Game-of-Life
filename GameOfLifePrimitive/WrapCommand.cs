using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifePrimitive
{
    internal class WrapCommand : Command
    {
        public string CommandText
        {
            get
            {
                return "wrap";
            }
        }
        public string HelpText
        {
            get
            {
                string text = "";
                text += "wrap:\n";
                text += "    Allows the board to wrap around from side to side and top to bottom.\n";
                text += "    Usage: wrap on|off";
                return text;
            }
        }
        public bool Execute(Grid grid, string[] parameters)
        {
            if(parameters.Length != 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error executing wrap command. This command must include the word");
                Console.WriteLine("'on' or 'off' as the first parameter.");
                Console.WriteLine("\n  Examples: 'wrap on' will allow the world to wrap around the edges.");
                Console.WriteLine("\n            'wrap off' will prevent wrapping.");
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
                grid.Wrap = turnOn;
                return true;
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

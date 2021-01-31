using System;

namespace GameOfLifePrimitive.Commands
{
    internal class WrapCommand : ICommand
    {
        public string CommandText => "wrap";

        public string HelpText
        {
            get
            {
                var text = "";
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
                bool turnOn;
                switch (parameters[1])
                {
                    case "on":
                        turnOn = true;
                        break;
                    case "off":
                        turnOn = false;
                        break;
                    default:
                        throw new Exception("Error interpreting first parameter. Must be 'on' or 'off'.");
                }
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

using System;

namespace GameOfLifePrimitive.Commands
{
    internal class GridCommand : ICommand
    {
        public string CommandText => "grid";

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

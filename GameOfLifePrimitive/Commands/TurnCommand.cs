using System;

namespace GameOfLifePrimitive.Commands
{
    internal class TurnCommand : ICommand
    {
        public string CommandText => "turn";

        public string HelpText
        {
            get
            {
                var text = "turn:\n";
                text += "    Turns individual cells on or off\n";
                text += "    Usage: turn on|off {x} {y}\n";
                text += "    Example: turn on 4 6";
                return text;
            }
        }
        public bool Execute(Grid grid, string[] parameters)
        {
            if(parameters.Length != 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error executing 'turn on/off' command. This command must include the word");
                Console.WriteLine("'on' or 'off' as the first parameter, and an x and y coordinate must be given.");
                Console.WriteLine("\n  Examples: 'turn on 3 7' will make x=3 and y=7 on, or alive.");
                Console.WriteLine("\n            'turn off 15 2' will make x=15 and y=2 off, or dead.");
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
                var row = Convert.ToInt32(parameters[2]) - 1;
                var column = Convert.ToInt32(parameters[3]) - 1;
                grid.Set(row, column, turnOn);
                return true;
            }
            catch(FormatException)
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

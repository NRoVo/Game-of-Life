using System;
using System.Collections.Generic;

namespace GameOfLifePrimitive.Commands
{
    internal class HelpCommand : ICommand
    {
        public List<ICommand> Commands { get; set; }
        public string CommandText => "help";

        public string HelpText => "";

        public bool Execute(Grid grid, string[] parameters)
        {
            Console.WriteLine("\n" + (Commands.Count + 2).ToString() + " commands available.\n");
            Console.WriteLine("exit:");
            Console.WriteLine("    Exits the program.");
            Console.WriteLine("    Usage: exit");
            Console.WriteLine();
            Console.WriteLine("start:");
            Console.WriteLine("    Begins animating.");
            Console.WriteLine("    Usage: start");
            Console.WriteLine();
            Console.WriteLine("help:");
            Console.WriteLine("    Shows this help.");
            Console.WriteLine("    Usage: help");
            Console.WriteLine();
            foreach(var command in Commands)
            {
                Console.WriteLine(command.HelpText);
                Console.WriteLine();
            }
            return true;
        }
    }
}

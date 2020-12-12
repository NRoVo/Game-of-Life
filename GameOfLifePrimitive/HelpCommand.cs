using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifePrimitive
{
    internal class HelpCommand : Command
    {
        public List<Command> Commands { get; set; }
        public string CommandText
        {
            get
            {
                return "help";
            }
        }
        public string HelpText
        {
            get
            {
                return "";
            }
        }
        public bool Execute(Grid grid, string[] parameters)
        {
            Console.WriteLine("\n" + (Commands.Count + 2) + " commands available.\n");
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
            foreach(Command command in Commands)
            {
                Console.WriteLine(command.HelpText);
                Console.WriteLine();
            }
            return true;
        }
    }
}

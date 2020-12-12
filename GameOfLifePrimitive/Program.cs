using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime;
using System.IO;

namespace GameOfLifePrimitive
{
    static class Program
    {
        private static Grid grid;
        private static bool running = true;
        private static List<Command> commands;
        static void Main(string[] args)
        {
            InitializeAllCommands();
            grid = new Grid();
            grid.Randomize(0.5);
            Thread thread = new Thread(RunAnimationLoop);
            thread.Start();
            Thread.Sleep(500);
            while(true)
            {
                Console.ReadKey(true);
                running = false;
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Beginning a command mode. Type 'help' for help and a list of all available commands. " +
                    "Type 'start' to begin animating. Type 'exit' to exit the program.");
                while(true)
                {
                    Console.Write(">>> ");
                    var allInput = Console.ReadLine();
                    var parameters = allInput.Split(' ');
                    var command = parameters[0];
                    var success = false;
                    if(command == "start")
                    {
                        break;
                    }
                    if(command == "exit")
                    {
                        Environment.Exit(0);
                    }
                    if(command == "help")
                    {
                        HelpCommand helpCommand = new HelpCommand();
                        helpCommand.Commands = commands;
                        helpCommand.Execute(grid, parameters);
                    }
                    for(int index = 0; index < commands.Count; index++)
                    {
                        if(command == commands[index].CommandText)
                        {
                            success = commands[index].Execute(grid, parameters);
                            break;
                        }                       
                    }
                    if(success)
                    {
                        grid.Draw();
                    }
                }
                running = true;
            }
        }
        private static void InitializeAllCommands()
        {
            commands = new List<Command>();
            commands.Add(new RandomizeCommand());
            commands.Add(new TurnCommand());
            commands.Add(new GridCommand());
            commands.Add(new WrapCommand());
            commands.Add(new ClearCommand());
            var path = "./Resources/";
            var premadeObjects = Directory.GetFiles(path);
            foreach(string objectFile in premadeObjects)
            {
                commands.Add(new PremadeCommand(objectFile));
            }    
        }
        private static void RunAnimationLoop()
        {
            while(true)
            {
                if(running)
                {
                    grid.Update();
                    grid.Draw();
                }
                Thread.Sleep(500);
            }
        }
    }
}

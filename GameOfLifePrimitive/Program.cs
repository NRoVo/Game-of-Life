using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Linq;
using GameOfLifePrimitive.Commands;

namespace GameOfLifePrimitive
{
    internal static class Program
    {
        private static Grid _grid;
        private static bool _running = true;
        private static List<ICommand> _commands;

        private static void Main()
        {
            InitializeAllCommands();
            _grid = new Grid();
            _grid.Randomize(0.5);
            var thread = new Thread(RunAnimationLoop);
            thread.Start();
            Thread.Sleep(500);
            while(true)
            {
                Console.ReadKey(true);
                _running = false;
                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.White;
                RunCommandMode();
                _running = true;
            }
        }

        private static void RunCommandMode()
        {
            Console.WriteLine("Beginning a command mode. Type 'help' for help and a list of all available commands. " +
                              "Type 'start' to begin animating. Type 'exit' to exit the program.");
            while (true)
            {
                Console.Write(">>> ");
                var allInput = Console.ReadLine();
                var parameters = allInput?.Split(' ');
                var command = parameters?[0];
                if (command == "start")
                {
                    break;
                }

                switch (command)
                {
                    case "exit":
                        Environment.Exit(0);
                        break;
                    case "help":
                    {
                        var helpCommand = new HelpCommand {Commands = _commands};
                        helpCommand.Execute(_grid, parameters);
                        break;
                    }
                }

                var success = (from t in _commands where command == t.CommandText select t.Execute(_grid, parameters))
                   .FirstOrDefault();
                if (success)
                {
                    _grid.Draw();
                }
            }
        }

        private static void InitializeAllCommands()
        {
            _commands = new List<ICommand>
            {
                new RandomizeCommand(),
                new TurnCommand(),
                new GridCommand(),
                new WrapCommand(),
                new ClearCommand()
            };
            const string path = "./Resources/";
            var premadeObjects = Directory.GetFiles(path);
            foreach(var objectFile in premadeObjects)
            {
                _commands.Add(new PremadeCommand(objectFile));
            }    
        }
        private static void RunAnimationLoop()
        {
            while(true)
            {
                if(_running)
                {
                    _grid.Update();
                    _grid.Draw();
                }
                Thread.Sleep(500);
            }
            
        }
    }
}

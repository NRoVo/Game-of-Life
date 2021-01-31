namespace GameOfLifePrimitive.Commands
{
    internal interface ICommand
    {
        string CommandText { get; }
        string HelpText { get; }
        bool Execute(Grid grid, string[] parameters);
    }
}

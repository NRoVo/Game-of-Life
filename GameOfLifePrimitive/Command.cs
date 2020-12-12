using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifePrimitive
{
    internal interface Command
    {
        string CommandText { get; }
        string HelpText { get; }
        bool Execute(Grid grid, string[] parameters);
    }
}

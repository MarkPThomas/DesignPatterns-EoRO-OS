using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UndoGraphicMove.Tests;

namespace UndoGraphicMove
{
    class Program
    {
        static void Main(string[] args)
        {
            MementoTest.Run();
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BoolInterpreter.Tests;

namespace BoolInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            RegExtInterpreterTests.Run();
            Console.ReadKey();
        }
    }
}

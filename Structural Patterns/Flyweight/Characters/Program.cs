using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Characters.Tests;

namespace Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.CreateDocument();
            Console.WriteLine("Success!");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeSingleton.Model;

namespace MazeSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeFactory mazeFactory;

            mazeFactory = MazeFactory.Instance();

            mazeFactory = MazeFactory.InstanceWithSubclasses("bombed");
            mazeFactory = MazeFactory.InstanceWithSubclasses("enchanted");
        }
    }
}

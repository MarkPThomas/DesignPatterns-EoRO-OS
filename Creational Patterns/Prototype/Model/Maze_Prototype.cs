using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeDemo.Model;

namespace MazePrototype.Model
{
    internal class Maze_Prototype : Maze, ICloneable
    {
        public object Clone()
        {
            Maze_Prototype clone = new Maze_Prototype();
            return clone;
        }
    }
}

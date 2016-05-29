using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeDemo.Model;

namespace MazeAbstractFactory.Model
{
    internal abstract class MazeFactory
    {
        internal MazeFactory() { }

        internal virtual Maze MakeMaze()
        {
            return new Maze();
        }

        internal virtual Wall MakeWall()
        {
            return new Wall();
        }

        internal virtual Room MakeRoom(int n)
        {
            return new Room(n);
        }

        internal virtual Door MakeDoor(Room r1, Room r2)
        {
            return new Door(r1, r2);
        }

    }
}

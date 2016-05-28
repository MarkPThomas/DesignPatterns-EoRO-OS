using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeDemo.Model
{
    internal abstract class MazeBuilder
    {
        protected MazeBuilder() { }

        internal virtual void BuildMaze() { }
        internal virtual void BuildRoom(int roomNo) { }
        internal virtual void BuildDoor(int room1, int room2) { }
        internal virtual Maze GetMaze() { return null; }
    }
}

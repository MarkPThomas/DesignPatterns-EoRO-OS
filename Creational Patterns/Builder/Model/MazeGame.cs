using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeDemo.Model
{
    internal class MazeGame
    {
        internal Maze CreateMaze(MazeBuilder builder)
        {
            builder.BuildRoom(1);
            builder.BuildRoom(2);
            builder.BuildDoor(1, 2);

            return builder.GetMaze();
        }

        internal Maze CreateComplexMaze(MazeBuilder builder)
        {
            builder.BuildRoom(1);
            // ...
            builder.BuildRoom(1001);

            return builder.GetMaze();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeDemo.Model;

namespace MazeFactory.Model
{
    internal class BombedMazeGame : MazeGame
    {
        internal override Wall MakeWall()
        {
            return new BombedWall();
        }

        internal override Room MakeRoom(int n)
        {
            return new RoomWithABomb(n);
        }
    }
}

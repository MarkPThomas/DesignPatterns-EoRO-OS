using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeDemo.Model;

namespace MazeSingleton.Model
{
    internal class MazeFactory
    {
        protected static MazeFactory _instance;

        protected MazeFactory() { }

        public static MazeFactory Instance()
        {
            if (_instance == null)
            {
                _instance = new MazeFactory();
            }
            return _instance;
        }

        public static MazeFactory InstanceWithSubclasses(string mazeStyle)
        {
            if (_instance == null)
            {
                switch (mazeStyle)
                {
                    case "bombed":
                        _instance = new BombedMazeFactory();
                        break;
                    case "enchanted":
                        _instance = new EnchantedMazeFactory();
                        break;
                    default:
                        _instance = new MazeFactory();
                        break;
                }
            }
            return _instance;
        }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeDemo.Model;
using MazePrototype.Model;

namespace MazePrototype
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeGame game = new MazeGame();
            Maze maze;

            MazePrototypeFactory simpleMazeFactory = new MazePrototypeFactory(new Maze_Prototype(), 
                                                                                new WallPrototype(), 
                                                                                new RoomPrototype(), 
                                                                                new DoorPrototype());
            maze = game.CreateMaze(simpleMazeFactory);

            MazePrototypeFactory bombedMazeFactory = new MazePrototypeFactory(new Maze_Prototype(),
                                                                                new BombedWallPrototype(),
                                                                                new RoomWithABombPrototype(),
                                                                                new DoorPrototype());
            maze = game.CreateMaze(bombedMazeFactory);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeFactory.Model;

namespace MazeFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeGame mazeGame = new MazeGame();
            mazeGame.CreateMaze();

            BombedMazeGame bombedMazeGame = new BombedMazeGame();
            bombedMazeGame.CreateMaze();

            EnchantedMazeGame enchantedMazeGame = new EnchantedMazeGame();
            enchantedMazeGame.CreateMaze();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeAbstractFactory.Model;

namespace MazeAbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            MazeGame mazeGame = new MazeGame();
            BombedMazeFactory bombFactory = new BombedMazeFactory();
            mazeGame.CreateMaze(bombFactory);

            EnchantedMazeFactory enchantedFactory = new EnchantedMazeFactory();
            mazeGame.CreateMaze(enchantedFactory);

        }
    }
}

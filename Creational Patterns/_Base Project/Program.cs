using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeDemo.Model;

namespace MazeDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MazeGame mazeGame = new MazeGame();
            mazeGame.CreateMaze();
        }
    }
}

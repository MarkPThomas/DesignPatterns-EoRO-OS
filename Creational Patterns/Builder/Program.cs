using System;

using MazeDemo.Model;

namespace MazeDemo
{
    /// <summary>
    /// Client.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Concrete Builder
            StandardMazeBuilder builder = new StandardMazeBuilder();

            // Director
            MazeGame game = new MazeGame();
            game.CreateMaze(builder);

            // Getting product ...
            Maze maze = builder.GetMaze();

            
            // Concrete Builder
            CountingMazeBuilder builderCount = new CountingMazeBuilder();

            // Director
            MazeGame gameCount = new MazeGame();
            gameCount.CreateMaze(builderCount);

            int rooms;
            int doors;
            builderCount.GetCounts(out rooms, out doors);

            Console.WriteLine("The maze has {0} rooms and {1} doors.", rooms, doors);
        }

        
    }
}

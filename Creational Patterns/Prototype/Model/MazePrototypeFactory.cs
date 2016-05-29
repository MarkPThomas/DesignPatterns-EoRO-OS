using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeDemo.Model;

namespace MazePrototype.Model
{
    internal class MazePrototypeFactory : MazeFactory
    {
        private Maze_Prototype _prototypeMaze;
        private WallPrototype _prototypeWall;
        private RoomPrototype _prototypeRoom;
        private DoorPrototype _prototypeDoor;

        internal MazePrototypeFactory(Maze_Prototype maze, WallPrototype wall, RoomPrototype room, DoorPrototype door)
        {
            _prototypeMaze = maze;
            _prototypeWall = wall;
            _prototypeRoom = room;
            _prototypeDoor = door;
        }

        internal override Maze MakeMaze()
        {
            return (Maze)_prototypeMaze.Clone();
        }

        internal override Wall MakeWall()
        {
            return (Wall)_prototypeWall.Clone();
        }

        internal override Door MakeDoor(Room r1, Room r2)
        {
            DoorPrototype door = (DoorPrototype)_prototypeDoor.Clone();
            door.Initialize(r1, r2);
            return door;
        }

        internal override Room MakeRoom(int n)
        {
            RoomPrototype room = (RoomPrototype)_prototypeRoom.Clone();
            room.Initialize(n);
            return room;
        }
    }
}

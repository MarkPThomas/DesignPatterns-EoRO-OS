using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeDemo.Model
{
    internal class StandardMazeBuilder : MazeBuilder
    {
        private Maze _currentMaze;
        internal override Maze GetMaze()
        {
            return _currentMaze;
        }


        internal StandardMazeBuilder()
        {
            
        }

        internal override void BuildMaze()
        {
            _currentMaze = new Maze();
        }

        internal override void BuildRoom(int roomNo)
        {
            if (_currentMaze.RoomNo(roomNo) == null)
            {
                Room room = new Room(roomNo);
                _currentMaze.AddRoom(room);

                room.SetSide(Direction.North, new Wall());
                room.SetSide(Direction.South, new Wall());
                room.SetSide(Direction.East, new Wall());
                room.SetSide(Direction.West, new Wall());
            }
        }

        internal override void BuildDoor(int room1, int room2)
        {
            Room r1 = _currentMaze.RoomNo(room1);
            Room r2 = _currentMaze.RoomNo(room2);
            Door d = new Door(r1, r2);

            r1.SetSide(CommonWall(r1, r2), d);
            r2.SetSide(CommonWall(r2, r1), d);
        }


   
        private Direction CommonWall(Room room1, Room room2)
        {
            Direction directionTest = Direction.North;
            if (IsCommonWall(room1, room2, directionTest)) { return directionTest; }

            directionTest = Direction.South;
            if (IsCommonWall(room1, room2, directionTest)) { return directionTest; }

            directionTest = Direction.East;
            if (IsCommonWall(room1, room2, directionTest)) { return directionTest; }

            directionTest = Direction.West;
            if (IsCommonWall(room1, room2, directionTest)) { return directionTest; }

            return directionTest;
        }

        private bool IsCommonWall(Room room1, Room room2, Direction direction)
        {
            return (room1.GetSide(direction) == room2.GetSide(direction));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeDemo.Model
{
    public class Maze
    {
        private Dictionary<int, Room> _rooms = new Dictionary<int, Room>();

        public Maze() { }

        public void AddRoom(Room room)
        {
            if (!_rooms.Keys.Contains(room.RoomNumber))
            {
                _rooms.Add(room.RoomNumber, room);
            }
        }

        public Room RoomNo(int roomNo)
        {
            if (!_rooms.Keys.Contains(roomNo))
            {
                return _rooms[roomNo];
            }
            else
            {
                return null;
            }
        }
    }
}

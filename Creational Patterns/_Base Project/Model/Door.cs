using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeDemo.Model
{
    public class Door : MapSite
    {
        protected Room _room1;
        protected Room _room2;
        protected bool _isOpen;

        public Door(Room room1, Room room2)
        {
            _room1 = room1;
            _room2 = room2;
        }

        public override void Enter()
        {
            if (_isOpen)
            {
                Console.WriteLine("The door is open and you pass through it to the next room.");
            }
            else
            {
                Console.WriteLine("The door is closed! You hurt your nose walking into the door.");
            }
        }

        public Room OtherSideFrom(Room roomFrom)
        {
            if (roomFrom == _room1)
            {
                return _room2;
            }
            else if(roomFrom == _room2)
            {
                return _room1;
            }
            else
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeDemo.Model;

namespace MazePrototype.Model
{
    internal class DoorPrototype : Door, ICloneable
    {
        public DoorPrototype(Room room1, Room room2) : base(room1, room2)
        {
        }

        public DoorPrototype() : base(null, null) { }

        internal void Initialize(Room room1, Room room2)
        {
            _room1 = room1;
            _room2 = room2;
        }

        public object Clone()
        {
            DoorPrototype clone = new DoorPrototype();
            clone._isOpen = _isOpen;
            clone._room1 = _room1;
            clone._room2 = _room1;
            return clone;
        }
    }
}

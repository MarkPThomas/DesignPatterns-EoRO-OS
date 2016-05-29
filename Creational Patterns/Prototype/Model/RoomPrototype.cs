using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeDemo.Model;

namespace MazePrototype.Model
{
    internal class RoomPrototype : Room, ICloneable
    {
        public RoomPrototype(int roomNo) : base(roomNo)
        {
        }

        public RoomPrototype() : base(0) { }

        internal void Initialize(int roomNo)
        {
            RoomNumber = roomNo;
        }

        public virtual object Clone()
        {
            RoomPrototype clone = new RoomPrototype();
            clone.RoomNumber = RoomNumber;
            clone._sides = _sides;
            return clone;
        }
    }
}

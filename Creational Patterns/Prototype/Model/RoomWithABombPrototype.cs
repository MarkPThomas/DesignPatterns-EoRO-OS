using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazePrototype.Model
{
    internal class RoomWithABombPrototype : RoomPrototype
    {
        public RoomWithABombPrototype(int roomNo) : base(roomNo)
        {
        }

        public RoomWithABombPrototype() : base(0) { }

        public override object Clone()
        {
            RoomWithABombPrototype clone = (RoomWithABombPrototype)base.Clone();
            return clone;
        }
    }
}

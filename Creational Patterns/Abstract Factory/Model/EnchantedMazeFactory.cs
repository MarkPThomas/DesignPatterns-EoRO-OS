using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeDemo.Model;

namespace MazeAbstractFactory.Model
{
    internal class EnchantedMazeFactory : MazeFactory
    {
        protected Spell CastSpell;

        internal EnchantedMazeFactory() { }

        internal override Room MakeRoom(int n)
        {
            return new EnchantedRoom(n, CastSpell);
        }

        internal override Door MakeDoor(Room r1, Room r2)
        {
            return new DoorNeedingSpell(r1, r2);
        }
    }
}

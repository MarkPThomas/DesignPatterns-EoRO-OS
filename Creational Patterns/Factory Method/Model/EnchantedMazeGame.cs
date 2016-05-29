using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeDemo.Model;

namespace MazeFactory.Model
{
    internal class EnchantedMazeGame : MazeGame
    {
        protected Spell CastSpell;

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

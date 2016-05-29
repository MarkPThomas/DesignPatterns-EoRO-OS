using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeDemo.Model
{
    public class EnchantedRoom : Room
    {
        protected Spell _castSpell;

        public EnchantedRoom(int roomNo, Spell castSpell) : base(roomNo)
        {
            _castSpell = castSpell;
        }
    }
}

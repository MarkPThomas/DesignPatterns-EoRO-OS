using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazePrototype.Model
{
    internal class BombedWallPrototype : WallPrototype
    {
        protected bool _bomb;
        public bool HasBomb { get { return _bomb; } protected set {; } }

        public override object Clone()
        {
            BombedWallPrototype clone = (BombedWallPrototype)base.Clone();
            clone._bomb = _bomb;
            return clone;
        }
    }
}

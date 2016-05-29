using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MazeDemo.Model;

namespace MazePrototype.Model
{
    internal class WallPrototype : Wall, ICloneable
    {
        public virtual object Clone()
        {
            WallPrototype clone = new WallPrototype();
            return clone;
        }
    }
}

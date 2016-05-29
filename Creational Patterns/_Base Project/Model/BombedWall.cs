using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeDemo.Model
{
    public class BombedWall : Wall
    {
        protected bool _bomb;
        public bool HasBomb { get { return _bomb; } protected set {; } }
    }
}

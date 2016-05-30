using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoGraphicMove.Model
{
    public abstract class Command
    {
        protected Command() { }

        public abstract void Execute();
    }
}

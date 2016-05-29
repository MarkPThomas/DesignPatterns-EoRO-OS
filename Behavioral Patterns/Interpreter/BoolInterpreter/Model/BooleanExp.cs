using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoolInterpreter.Model
{
    public abstract class BooleanExp
    {
        public BooleanExp()
        {

        }

        public abstract bool Evaluate(Context aContext);
        public abstract BooleanExp Replace(char name, BooleanExp exp);
        public abstract BooleanExp Copy();
    }
}

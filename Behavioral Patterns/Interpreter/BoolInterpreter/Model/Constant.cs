using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoolInterpreter.Model
{
    public class Constant : BooleanExp
    {
        private bool _value;

        public Constant(bool value)
        {
            _value = value;
        }

        public override BooleanExp Copy()
        {
            return new Constant(_value);
        }

        public override BooleanExp Replace(char name, BooleanExp exp)
        {
            return new Constant(_value);
        }
        
        public override bool Evaluate(Context aContext)
        {
            return _value;
        }
    }
}

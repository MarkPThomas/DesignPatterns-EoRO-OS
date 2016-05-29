using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoolInterpreter.Model
{
    public class VariableExp : BooleanExp
    {
        private char _name;
        public char Name { get { return _name; } }

        public VariableExp(char name)
        {
            _name = name;
        }

        public override BooleanExp Copy()
        {
            return new VariableExp(_name);
        }

        public override BooleanExp Replace(char name, BooleanExp exp)
        {
            if (_name == name)
            {
                return exp.Copy();
            }
            else
            {
                return new VariableExp(_name);
            }
        }

        public override bool Evaluate(Context aContext)
        {
            return aContext.Lookup(_name);
        }
    }
}

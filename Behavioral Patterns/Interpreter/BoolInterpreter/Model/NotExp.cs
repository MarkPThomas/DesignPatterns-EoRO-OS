using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoolInterpreter.Model
{
    public class NotExp : BooleanExp
    {
        private BooleanExp _operand1;

        public NotExp(BooleanExp op1)
        {
            _operand1 = op1;
        }

        public override BooleanExp Copy()
        {
            return new NotExp(_operand1.Copy());
        }

        public override BooleanExp Replace(char name, BooleanExp exp)
        {
            return new NotExp(_operand1.Replace(name, exp));
        }

        public override bool Evaluate(Context aContext)
        {
            return !_operand1.Evaluate(aContext);
        }      
    }
}

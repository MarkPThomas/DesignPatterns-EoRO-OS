using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoolInterpreter.Model
{
    public class OrExp : BooleanExp
    {
        private BooleanExp _operand1;
        private BooleanExp _operand2;

        public OrExp(BooleanExp op1, BooleanExp op2)
        {
            _operand1 = op1;
            _operand2 = op2;
        }

        public override BooleanExp Copy()
        {
            return new OrExp(_operand1.Copy(), _operand2.Copy());
        }

        public override BooleanExp Replace(char name, BooleanExp exp)
        {
            return new OrExp(
                _operand1.Replace(name, exp),
                _operand2.Replace(name, exp));
        }

        public override bool Evaluate(Context aContext)
        {
            return
                _operand1.Evaluate(aContext) ||
                _operand2.Evaluate(aContext);
        }
    }
}

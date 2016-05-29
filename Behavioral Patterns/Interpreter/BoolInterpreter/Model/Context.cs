using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoolInterpreter.Model
{
    public class Context
    {
        private Dictionary<char, bool> _map = new Dictionary<char, bool>();

        public Context()
        {
        }


        public bool Lookup(char name)
        {
            if (_map.ContainsKey(name))
            {
                return _map[name];
            }
            else
            {
                return false;
            }
        }

        public void Assign(VariableExp variableExp, bool value)
        {
            if (!_map.ContainsKey(variableExp.Name))
            {
                _map.Add(variableExp.Name, value);
            }
            else
            {
                _map[variableExp.Name] = value;
            }
        }
    }
}

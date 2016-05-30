using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UndoGraphicMove.Model
{
    /// <summary>
    /// Originator.
    /// Creates a memento containing a snapshot of its current internal state.
    /// Uses the memento to restore its internal state.
    /// </summary>
    public class ConstraintSolver
    {
        private List<Graphic> _startConnections = new List<Graphic>();
        private List<Graphic> _endConnections = new List<Graphic>();
        private static ConstraintSolver _constraintSolver;

        private List<string> _stateList = new List<string>();

        public string StateItem1 { get; set; }
        public int StateItem2 { get; set; }


        private ConstraintSolver()
        {
            StateItem1 = "Original state";
            StateItem2 = -1;
            _stateList.Add("Original item 1");
            _stateList.Add("Original item 2");
        }

        public static ConstraintSolver Instance()
        {
            if (_constraintSolver == null)
            {
                _constraintSolver = new ConstraintSolver();
            }
            return _constraintSolver;
        }

        
        /// <summary>
        /// Quick cheat of changing state that would be caused by moving the graphic in this class's registry.
        /// </summary>
        public void ChangeState()
        {
            Console.WriteLine("\nChanging state!\n");
            StateItem1 = "New state";
            StateItem2 = 1;
            _stateList.RemoveAt(1);
            _stateList.Add("New item 1");
            _stateList.Add("New item 2");
        }

        /// <summary>
        /// Solves the constraints registered with AddConstraint operation.
        /// Changes state based on state that is to be restored.
        /// </summary>
        public void Solve()
        {
            Console.WriteLine("StateItem1: {0} \nStateItem2: {1}", StateItem1, StateItem2);
            Console.WriteLine("_stateList: ");
            foreach (string item in _stateList)
            {
                Console.WriteLine(item);
            }
        }

        public void AddConstraint(Graphic startConnection, Graphic endConnection)
        {
            _startConnections.Add(startConnection);
            _endConnections.Add(endConnection);
        }

        public void RemoveConstraint(Graphic startConnection, Graphic endConnection)
        {
            int removeIndex = -1;
            for (int i = 0; i < _startConnections.Count; i++)
            {
                if ((_startConnections[i] == startConnection) &&
                    (_endConnections[i] == endConnection))
                {
                    removeIndex = i;
                    break;
                }
            }

            if (removeIndex >= 0)
            {
                _startConnections.RemoveAt(removeIndex);
                _endConnections.RemoveAt(removeIndex);
            }
        }

        public object CreateMemento()
        {
            ConstraintSolverMemento memento = new ConstraintSolverMemento();

            // Save state here
            memento.StateItem1 = StateItem1;
            memento.StateItem2 = StateItem2;
            memento._stateList = new List<string>(_stateList);

            return memento;
        }
        
        public void SetMemento(object memento)
        {
            if (memento.GetType() == typeof(ConstraintSolverMemento))
            {
                Console.WriteLine("\nRestoring old state ...\n");
                ConstraintSolverMemento oldState = (ConstraintSolverMemento)memento;

                // Restore state here ...
                StateItem1 = oldState.StateItem1;
                StateItem2 = oldState.StateItem2;
                _stateList = oldState._stateList;
            }
            else
            {
                Console.WriteLine("\nHa! Nice try! That object was not a proper memento!\n");
            }
        }

        /// <summary>
        /// Memento.
        /// Stores internal state of the originator object.
        /// Stores as much or little of the state as is necessary for a restore.
        /// Defined as private class here to avoid exposing the state outside of the class.
        /// Instead, this is boxed up into an 'object'.
        /// The originator receives an 'object', which it can tell is of this type, and if so, it is unboxed to restore state.
        /// </summary>
        private class ConstraintSolverMemento
        {
            internal List<string> _stateList = new List<string>();

            internal string StateItem1 { get; set; }
            internal int StateItem2 { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UndoGraphicMove.Model
{
    /// <summary>
    /// Serves as caretaker of memento by keeping it stored here.
    /// </summary>
    public class MoveCommand : Command
    {
        private Point _delta;
        private Graphic _target;
        //private ConstraintSolverMemento _state;
        private object _state;
        
        public MoveCommand(Graphic target, Point delta)
        {
            _target = target;
            _delta = delta;
        }

        public override void Execute()
        {
            Console.WriteLine("\nExecute!\n");
            ConstraintSolver solver = ConstraintSolver.Instance();
            // This is done just to show the current state.
            solver.Solve(); 

            // Create a memento
            // Acting as caretaker by storing it here
            _state = solver.CreateMemento();

            // Move graphic
            _target.Move(_delta);

            // Adjust constraints for movement
            solver.ChangeState();
            solver.Solve();
        }

        public void Unexecute()
        {
            Console.WriteLine("\nUndo!\n");
            ConstraintSolver solver = ConstraintSolver.Instance();    

            // Reverse graphic movement
            _delta.X = -_delta.X;
            _delta.Y = -_delta.Y;
            _target.Move(_delta);
                        
            // Restore state
            solver.SetMemento(_state);
            
            // Adjust constraints for reversed movement
            solver.Solve();
        }


        /// <summary>
        /// This is just to try passing back in an invalid memento.
        /// </summary>
        public void BadExecute()
        {
            Console.WriteLine("\nBad Execute!\n");
            ConstraintSolver solver = ConstraintSolver.Instance();
            solver.ChangeState();

            // Creating an object that is NOT a memento and storing it in the memento slot!
            object graphic = new Graphic();
            _state = graphic;
        }

        /// <summary>
        /// This is just to try passing back an invalid memento.
        /// </summary>
        public void BadUnexecute()
        {
            Console.WriteLine("\nBad Undo!\n");
            ConstraintSolver solver = ConstraintSolver.Instance();

            // Restore bad state
            solver.SetMemento(_state);

            // Adjust constraints for reversed movement
            solver.Solve();
        }
        
    }
}

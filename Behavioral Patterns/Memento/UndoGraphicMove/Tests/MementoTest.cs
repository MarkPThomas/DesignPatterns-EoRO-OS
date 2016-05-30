using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using UndoGraphicMove.Model;

namespace UndoGraphicMove.Tests
{
    public class MementoTest
    {
        public static void Run()
        {
            Graphic target = new Graphic();
            Point delta = new Point(5, 10);

            MoveCommand moveCommand = new MoveCommand(target, delta);
            moveCommand.Execute();
            moveCommand.Unexecute();

            Console.WriteLine();
            moveCommand.BadExecute();
            moveCommand.BadUnexecute();
        }
    }
}

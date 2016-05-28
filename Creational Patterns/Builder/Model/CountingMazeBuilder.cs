using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeDemo.Model
{
    internal class CountingMazeBuilder : MazeBuilder
    {
        int _doors;
        int _rooms;

        internal CountingMazeBuilder()
        {
            _rooms = _doors = 0;
        }

        internal override void BuildRoom(int roomNo)
        {
            _rooms++;
        }

        internal override void BuildDoor(int room1, int room2)
        {
            _doors++;
        }

        internal void GetCounts(out int rooms, out int doors)
        {
            rooms = _rooms;
            doors = _doors;
        }
    }
}

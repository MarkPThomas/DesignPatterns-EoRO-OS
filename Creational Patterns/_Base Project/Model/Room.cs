using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeDemo.Model
{
    public class Room : MapSite
    {
        private MapSite[] _sides = new MapSite[4];

        public int RoomNumber { get; private set; }

        public Room(int roomNo)
        {
            RoomNumber = roomNo;
        }

        public MapSite GetSide(Direction direction)
        {
            return _sides[(int)direction];
        }

        public void SetSide(Direction direction, MapSite mapsite)
        {
            _sides[(int)direction] = mapsite;
        }

        public override void Enter()
        {
            Console.WriteLine("You have entered the next room.");
        }


    }
}

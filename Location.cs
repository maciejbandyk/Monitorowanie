using System;
using System.Collections.Generic;
using System.Text;

namespace Monitorowanie
{
    class Location
    {
        public Location(int x, int y, DateTime dateTime)
        {
            X = x;
            Y = y;
            this.dateTime = dateTime;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public DateTime dateTime { get; set; }

    }
}

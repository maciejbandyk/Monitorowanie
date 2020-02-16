using System;
using System.Collections.Generic;
using System.Text;

namespace Monitorowanie
{
    class Tracker
    {
        public List<Location> LocationList { get; set; }

        public void OnChangeLocation(Location CurrentLocation)
        {
            LocationList.Add(CurrentLocation);
        }
    }
}
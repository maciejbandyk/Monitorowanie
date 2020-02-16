using System;
using System.Collections.Generic;
using System.Text;

namespace Monitorowanie
{
    class Colors
    {
        private string[] colors = new string[9] { "#e6beff", "#f032e6", "#000075", "#f58231", "#bfef45", "#42d4f4", "#ffd8b1", "#800000", "#FFFFFF" };

        public string this[int i]
        {
            get => colors[i];
        }

        public string SetRandomColor()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 9);
            return colors[randomNumber];
        }
    }
}

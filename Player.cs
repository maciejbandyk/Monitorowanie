using System;
using System.Collections.Generic;
using System.Threading;
using Pastel;

namespace Monitorowanie
{
    class Player
    {
        public int ID { get; private set; }
        static int nextID;
        public Location CurrentLocation { get; set; }
        public List<Location> LocationList = new List<Location>();
        private Random randomX = new Random();
        private Random randomY = new Random();
        private Field _field;
        public string TextColor { get; set; }

        public Player(Field field)
        {
            ID = Interlocked.Increment(ref nextID);
            _field = field;
        }
        public void SetPosition(Cell[,] cells)
        {
            int X;
            int Y;
            do
            {
                X = randomX.Next(1, 24);
                Y = randomY.Next(1, 89);
                if (!cells[X, Y].HasPlayerSet)
                {
                    cells[X, Y].CellInside = "*".Pastel(TextColor);
                    cells[X, Y].HasPlayerSet = true;
                    CurrentLocation = new Location(X, Y, DateTime.Now);
                }
            } while (!cells[X,Y].HasPlayerSet);      
        }

        public void StartMoving(Cell[,] cells, bool updateToken)
        {
            int i = 0;
            Random randDirection = new Random();
            Random randSpeedX = new Random();
            Random randSpeedY = new Random();
            while (true)
            {
                int speedX;
                int speedY;
                int random = randDirection.Next(1,6);
                if (random < 3)
                {
                    speedY = randSpeedY.Next(1, 4);
                    speedX = 0;
                }
                else
                {
                    speedX = randSpeedX.Next(1, 4);
                    speedY = 0;
                }
                switch (random)
                {
                    // GO RIGHT
                    case 1:
                        if (!_field.CheckIfValidMove(cells, speedX, speedY, random, CurrentLocation, _field, TextColor))
                            break;
                        CurrentLocation = new Location(CurrentLocation.X, CurrentLocation.Y + speedY, DateTime.Now);
                        LocationList.Add(CurrentLocation);
                        break;
                    // GO LEFT
                    case 2:
                        if(!_field.CheckIfValidMove(cells, speedX, speedY, random, CurrentLocation, _field, TextColor))
                            break;
                        CurrentLocation = new Location(CurrentLocation.X, CurrentLocation.Y - speedY, DateTime.Now);
                        LocationList.Add(CurrentLocation);                     
                        break;                      
                    // GO DOWN
                    case 3:
                        if (!_field.CheckIfValidMove(cells, speedX, speedY, random, CurrentLocation, _field, TextColor))
                            break;
                        CurrentLocation = new Location(CurrentLocation.X + speedX, CurrentLocation.Y, DateTime.Now);
                        LocationList.Add(CurrentLocation);
                        break;
                    // GO UP
                    case 4:
                         if (!_field.CheckIfValidMove(cells, speedX, speedY, random, CurrentLocation, _field, TextColor))
                             break;
                         CurrentLocation = new Location(CurrentLocation.X - speedX, CurrentLocation.Y, DateTime.Now);
                         LocationList.Add(CurrentLocation);
                         break;
                     // STAY
                    case 5:
                         CurrentLocation = new Location(CurrentLocation.X, CurrentLocation.Y, DateTime.Now);
                         LocationList.Add(CurrentLocation);
                         break;
                    default:
                        break;
                }
                i++;
                if (updateToken)
                    _field.UpdateField();
              
                Thread.Sleep(150);
            }
        }  
    }
}


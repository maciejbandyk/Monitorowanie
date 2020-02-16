using Pastel;
using static System.Console;

namespace Monitorowanie
{
    class Field
    {
        private readonly string upDownBorder = "-".Pastel("#ff0000");
        private readonly string rightLeftBorder = "|".Pastel("#ff0000");
        private Cell[,] arrayOfCells;
        private int _width;
        public int Width { get => _width; }
        private int _height;
        public int Height { get => _height; }

        public Field(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void InitField()
        {
            arrayOfCells = new Cell[_height, _width];
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Cell cell = new Cell(i, j);
                    arrayOfCells[i, j] = cell;
                }
            }
            SetBorder();
        }
        private void SetBorder()
        {
            foreach (var cell in arrayOfCells)
            {
                if (cell.X == 0 || cell.X == _height-1)
                    cell.CellInside = upDownBorder;
                if (cell.Y == 0 || cell.Y == _width-1)
                    cell.CellInside = rightLeftBorder;       
            }
        }

        public Cell[,] ReturnCells()
        {
            return arrayOfCells;
        }

        
        public void UpdateField()
        {
            SetCursorPosition(0, 0);
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    arrayOfCells[i, j].draw();
                }
                WriteLine();
            }
        }

        public void SetCell(int x, int y, string znak)
        {
            WriteLine($" X: {arrayOfCells[x,y].X}");
            WriteLine($" y: {arrayOfCells[x, y].Y}");
            arrayOfCells[x, y].CellInside = znak;
        }

        public bool CheckIfValidMove(Cell[,] cells, int speedOfMoveX, int speedOfMoveY, int random, Location CurrentLocation, Field _field, string TextColor)
        {
            if (random == 4 && cells[CurrentLocation.X, CurrentLocation.Y].X - speedOfMoveX < 1) { return false; }
            if (random == 1 && cells[CurrentLocation.X, CurrentLocation.Y].Y + speedOfMoveY >= _field.Width - 1) { return false; }
            if (random == 3 && cells[CurrentLocation.X, CurrentLocation.Y].X + speedOfMoveX >= _field.Height - 1) { return false; }
            if (random == 2 && cells[CurrentLocation.X, CurrentLocation.Y].Y - speedOfMoveY <= 1) { return false; }

            MarkVisitedCells(cells, speedOfMoveX, speedOfMoveY, random, CurrentLocation, TextColor);
            return true;
        }

        public void MarkVisitedCells(Cell[,] cells, int speedOfMoveX, int speedOfMoveY, int random, Location CurrentLocation, string TextColor)
        {
            if (speedOfMoveX > 0)
            {
                if (random % 2 == 0)
                {
                    for (int i = 0; i < speedOfMoveX; i++)
                    {
                        cells[CurrentLocation.X - i, CurrentLocation.Y].CellInside = "x".Pastel(TextColor);
                    }
                }
                else
                {
                    for (int i = 0; i < speedOfMoveX; i++)
                    {
                        cells[CurrentLocation.X + i, CurrentLocation.Y].CellInside = "x".Pastel(TextColor);
                    }
                }

            }
            else
            {
                if (random % 2 == 0)
                {
                    for (int i = 0; i < speedOfMoveY; i++)
                    {
                        cells[CurrentLocation.X, CurrentLocation.Y - i].CellInside = "x".Pastel(TextColor);
                    }
                }
                else
                {
                    for (int i = 0; i < speedOfMoveY; i++)
                    {
                        cells[CurrentLocation.X, CurrentLocation.Y + i].CellInside = "x".Pastel(TextColor);
                    }
                }

            }
        }
    }

    internal class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasPlayerSet { get; set; }
        public string CellInside = " ";
        
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void draw()
        {
            Write(CellInside);
        }
    }
}

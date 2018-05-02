using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Cells
{
    public static class CoordinatesHelper
    {
        public static List<Coordinates> GetNeighbours(Coordinates Coords)
        {
            List<Coordinates> neighbours = new List<Coordinates>();

            if (Coords.X != 0 && Coords.Y != 0)
            {
                neighbours.Add(new Coordinates(Coords.X - 1, Coords.Y - 1, Coords.LastRow, Coords.LastLine));
            }

            if (Coords.X != 0)
            {
                neighbours.Add(new Coordinates(Coords.X - 1, Coords.Y, Coords.LastRow, Coords.LastLine));
                if (Coords.Y < Coords.LastLine)
                {
                    neighbours.Add(new Coordinates(Coords.X - 1, Coords.Y + 1, Coords.LastRow, Coords.LastLine));
                }
            }

            if (Coords.Y > 0)
            {
                neighbours.Add(new Coordinates(Coords.X, Coords.Y - 1, Coords.LastRow, Coords.LastLine));
            }
            if (Coords.Y < Coords.LastLine)
            {
                neighbours.Add(new Coordinates(Coords.X, Coords.Y + 1, Coords.LastRow, Coords.LastLine));
            }

            if (Coords.X < Coords.LastRow)
            {
                neighbours.Add(new Coordinates(Coords.X + 1, Coords.Y, Coords.LastRow, Coords.LastLine));

                if (Coords.Y < Coords.LastLine)
                {
                    neighbours.Add(new Coordinates(Coords.X + 1, Coords.Y + 1, Coords.LastRow, Coords.LastLine));
                }
                if (Coords.Y != 0)
                {
                    neighbours.Add(new Coordinates(Coords.X + 1, Coords.Y - 1, Coords.LastRow, Coords.LastLine));
                }
            }
            return neighbours;
        }

        public static int CountLivingNeighbours(List<Coordinates> neighbours, ObservableCollection<ObservableCollection<Cell>> cellGrid)
        {
            int livingNeighbours = 0;
            foreach (Coordinates coords in neighbours)
            {
                if (cellGrid[coords.Y][coords.X].Alive == true)
                {
                    livingNeighbours += 1;
                }
            }
            return livingNeighbours;
        }
    }
}

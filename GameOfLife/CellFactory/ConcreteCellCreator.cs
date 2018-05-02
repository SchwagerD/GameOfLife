using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Cells;
using GameOfLife.ChangeGenerationStrategy.Model;

namespace GameOfLife.CellFactory
{
    class ConcreteCellCreator : CellCreator
    {
        public override Cell FactoryMethod(string Type, Coordinates coords)
        {
            switch(Type)
            {
                case "Connway":
                    Cell cell = new Cell(false, coords);
                    cell.Neighbours = CoordinatesHelper.GetNeighbours(cell.Coordinates);
                    cell.ChangeGenerationStrategy = new ConnwayCellChangeGenerationStrategy();
                    return cell;
                default:
                    throw new ArgumentException("Invalid Type", Type);
            }
        }
    }
}

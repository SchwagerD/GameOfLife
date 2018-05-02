using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Cells;

namespace GameOfLife.ChangeGenerationStrategy.Model
{
    public class ConnwayCellChangeGenerationStrategy : CellChangeGenerationStrategy
    {
        public override void Propagate(ObservableCollection<ObservableCollection<Cell>> CellGrid, Cell Cell)
        {
            if (Cell.state != CellState.None)
            {
                Cell.ToggleAlive();
                Cell.state = CellState.None;
            }
        }

        public override void SetStatus(ObservableCollection<ObservableCollection<Cell>> CellGrid, Cell Cell)
        {
            if (Cell.Alive)
            {
                switch (CoordinatesHelper.CountLivingNeighbours(Cell.Neighbours, CellGrid))
                {
                    case 2:
                    case 3:
                        Cell.state = CellState.None;
                        break;
                    default:
                        Cell.state = CellState.Dying;
                        break;
                }
            }
            else
            {
                switch (CoordinatesHelper.CountLivingNeighbours(Cell.Neighbours, CellGrid))
                {
                    case 3:
                        Cell.state = CellState.Growing;
                        break;
                    default:
                        Cell.state = CellState.None;
                        break;
                }
            }
        }
    }
}

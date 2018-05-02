using GameOfLife.Cells;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.ChangeGenerationStrategy
{
    class ConnwayChangeGenerationStrategy : ChangeGenerationStrategyAbstract
    {
        public override void ChangeGeneration(ObservableCollection<ObservableCollection<Cell>> CellGrid)
        {
            CalculateCellGridStatus(CellGrid);
            PropagateCellGrid(CellGrid);
        }

        private void CalculateCellGridStatus(ObservableCollection<ObservableCollection<Cell>> cellGrid)
        {
            for (int i = 0; i < cellGrid.Count; i++)
            {
                for (int j = 0; j < cellGrid[i].Count; j++)
                {
                    cellGrid[j][i].ChangeGenerationStrategy.SetStatus(cellGrid, cellGrid[j][i]);
                }
            }
        }
        private void PropagateCellGrid(ObservableCollection<ObservableCollection<Cell>> cellGrid)
        {
            for (int i = 0; i < cellGrid.Count; i++)
            {
                for (int j = 0; j < cellGrid[i].Count; j++)
                {
                    cellGrid[j][i].ChangeGenerationStrategy.Propagate(cellGrid, cellGrid[j][i]);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Cells;

namespace GameOfLife.ChangeGenerationStrategy.Model
{
    public abstract class CellChangeGenerationStrategy : ChangeGenerationStrategy.ICellChangeGenerationStrategy
    {
        public abstract void Propagate(ObservableCollection<ObservableCollection<Cell>> CellGrid, Cell Cell);
        public abstract void SetStatus(ObservableCollection<ObservableCollection<Cell>> CellGrid, Cell Cell);
    }
}

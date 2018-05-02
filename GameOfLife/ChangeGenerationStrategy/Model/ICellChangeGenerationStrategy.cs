using GameOfLife.Cells;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.ChangeGenerationStrategy
{
    public interface ICellChangeGenerationStrategy
    {
        void SetStatus(ObservableCollection<ObservableCollection<Cell>> CellGrid, Cell Cell);
        void Propagate(ObservableCollection<ObservableCollection<Cell>> CellGrid, Cell Cell);
    }
}

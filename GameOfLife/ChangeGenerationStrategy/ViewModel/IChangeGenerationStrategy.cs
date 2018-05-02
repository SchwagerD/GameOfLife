using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Cells
{
    public interface IChangeGenerationStrategy
    {
        void ChangeGeneration(ObservableCollection<ObservableCollection<Cell>> cellGrid);
    }
}

using GameOfLife.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.CellFactory
{
    abstract class CellCreator
    {
        public abstract Cells.Cell FactoryMethod(string Type, Coordinates coords);
    }
}

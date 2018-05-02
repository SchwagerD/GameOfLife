using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Cells
{
    public struct Coordinates
    {
        #region Fields
        public int x;
        public int y;

        private int lastRow;
        private int lastLine;
        #endregion

        #region Properties
        public int X
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
        }

        public int LastRow
        {
            get
            {
                return lastRow;
            }
        }

        public int LastLine
        {
            get
            {
                return lastLine;
            }
        }
        #endregion



        public Coordinates(int X, int Y, int LastRow, int LastLine)
        {
            x = X;
            y = Y;
            lastRow = LastRow;
            lastLine = LastLine;
        }
    }
}

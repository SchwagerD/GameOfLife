using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Cells
{
    public abstract class CellViewModelBase : INotifyPropertyChanged
    {
        public IChangeGenerationStrategy ChangeGenerationStrategy;
        public ObservableCollection<ObservableCollection<Cell>> cellGrid;

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        #endregion
    }
}

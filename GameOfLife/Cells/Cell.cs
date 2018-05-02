using GameOfLife.ChangeGenerationStrategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GameOfLife.Cells
{
    public class Cell : INotifyPropertyChanged
    {
        #region Fields
        bool alive;
        Coordinates coordinates;
        public CellState state;
        public ICellChangeGenerationStrategy ChangeGenerationStrategy;
        private ICommand toggleAliveCommand;
        #endregion

        #region Properties
        public ICommand ToggleAliveCommand
        {
            get
            {
                return toggleAliveCommand ?? (toggleAliveCommand = new RelayCommand.RelayCommand(x => { ToggleAlive(); }));
            }
        }

        public List<Coordinates> Neighbours { get; set; }

        public Coordinates Coordinates
        {
            get
            {
                return coordinates;
            }
            private set
            {
                coordinates = value;
            }
        }

        public bool Alive
        {
            get
            {
                return alive;
            }
            set
            {
                if (value != alive)
                {
                    alive = value;
                    OnPropertyRaised("Alive");
                }

            }
        }
        #endregion

        public Cell(bool living, Coordinates coords)
        {
            alive = living;
            coordinates = coords;
            state = CellState.None;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public void ToggleAlive()
        {
            Alive = !alive;
        }
    }

    public enum CellState
    {
        None,
        Dying,
        Growing
    }
}

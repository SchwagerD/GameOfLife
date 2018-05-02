using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace GameOfLife.Cells
{
    public class CellViewModel : CellViewModelBase, INotifyPropertyChanged
    {
        #region Fields
        private Timer gameTimer;
        private ICommand toggleTimerCommand;
        #endregion

        #region Properties
        public double Interval
        {
            get
            {
                return gameTimer.Interval;
            }
            set
            {
                if (value != gameTimer.Interval)
                {
                    if (value < 500)
                        value = 500;
                    gameTimer.Interval = value;
                    OnPropertyRaised("Interval");
                }
                
            }
        }

        public ICommand ToggleTimerCommand
        {
            get
            {
                return toggleTimerCommand ?? (toggleTimerCommand = new RelayCommand.RelayCommand(x => { ToggleTimer(); }));
            }
        }

        public ObservableCollection<ObservableCollection<Cell>> CellGrid
        {
            get
            {
                return cellGrid;
            }
            set
            {
                if (value != cellGrid)
                {
                    cellGrid = value;
                    OnPropertyRaised("CellGrid");
                }
            }
        }
        #endregion


        public CellViewModel(int x, int y, double interval)
        {
            gameTimer = new Timer(interval);
            gameTimer.Elapsed += new ElapsedEventHandler(GenerationChange);
            CellGrid = new ObservableCollection<ObservableCollection<Cell>>();

            CellFactory.ConcreteCellCreator cellFactory = new CellFactory.ConcreteCellCreator();
            for (int i = 0; i < y; i++)
            {
                ObservableCollection<Cell> Row = new ObservableCollection<Cell>();
                for (int j = 0; j < x; j++)
                {
                    Cell cell = cellFactory.FactoryMethod("Connway", new Coordinates(j, i, x - 1, y - 1));                    
                    Row.Add(cell);
                }
                CellGrid.Add(Row);
            }
        }

        private void GenerationChange(object sender, ElapsedEventArgs e)
        {
            ChangeGenerationStrategy.ChangeGeneration(cellGrid); 
        }

        public void ToggleTimer()
        {
            this.gameTimer.Enabled = !this.gameTimer.Enabled;
        }
    }
}

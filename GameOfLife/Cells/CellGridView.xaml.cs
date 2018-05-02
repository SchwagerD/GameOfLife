using GameOfLife.ChangeGenerationStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameOfLife.Cells
{
    /// <summary>
    /// Interaktionslogik für CellGridView.xaml
    /// </summary>
    public partial class CellGridView : UserControl
    {
        public CellGridView()
        {
            InitializeComponent();
            CellViewModel vm = new CellViewModel(25, 25, 1000);
            vm.ChangeGenerationStrategy = new ConnwayChangeGenerationStrategy();
            DataContext = vm;
            lst.ItemsSource = vm.CellGrid;
        }
    }
}

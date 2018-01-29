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
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AllChilds.xaml
    /// </summary>
    public partial class AllChilds : Window
    {
        BL.IBL bl;
        public AllChilds()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            this.ChildsDataGrid.ItemsSource = bl.GetAllChilds();
        }
    }
}

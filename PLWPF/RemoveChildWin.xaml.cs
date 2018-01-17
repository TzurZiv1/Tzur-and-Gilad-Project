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
    /// Interaction logic for RemoveChildWin.xaml
    /// </summary>
    public partial class RemoveChildWin : Window
    {
        BE.Child child;
        BL.IBL bl;
        public RemoveChildWin()
        {
            InitializeComponent();
            child = new BE.Child();
            this.DataContext = child;
            bl = BL.FactoryBL.GetBL();
            this.iDComboBox.ItemsSource = bl.GetAllChilds();
        }

        private void RemoveChildButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

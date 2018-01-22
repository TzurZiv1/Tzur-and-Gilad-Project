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
    /// Interaction logic for RemoveContractWin.xaml
    /// </summary>
    public partial class RemoveContractWin : Window
    {
        class MyData
        {
            int number;
            public int Number { get => number; set => number = value; }
        }
        BL.IBL bl;
        MyData myData = new MyData() { Number = 0 };

        public RemoveContractWin()
        {
            InitializeComponent();
        }

        private void RemoveContractButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

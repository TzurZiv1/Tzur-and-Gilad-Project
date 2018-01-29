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
    /// Interaction logic for ChildsOfMotherWin.xaml
    /// </summary>
    public partial class ChildsOfMotherWin : Window
    {
        BL.IBL bl;
        class MyData
        {
            int id;
            public int Id { get => id; set => id = value; }
        }
        MyData myData = new MyData() { Id = 0 };
        public ChildsOfMotherWin()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            this.iDComboBox.DataContext = myData;
            this.iDComboBox.ItemsSource = bl.GetAllMothers();
            iDComboBox.DisplayMemberPath = "MainDetails";
            iDComboBox.SelectedValuePath = "ID";
        }

        private void iDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChildsDataGrid.ItemsSource = (from childs in bl.GetAllChildsByMother()
                                          where childs.Key == myData.Id
                                          select childs).FirstOrDefault();
        }
    }
}

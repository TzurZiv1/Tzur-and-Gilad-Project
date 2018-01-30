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
    /// Interaction logic for NanniesByDisFromMother.xaml
    /// </summary>
    public partial class NanniesByDisFromMother : Window
    {
        BL.IBL bl;
        class MyData
        {
            int id;
            int distance;
            public int Id { get => id; set => id = value; }
            public int Distance { get => distance; set => distance = value; }
        }
        MyData myData = new MyData() { Id = 0 };
        public NanniesByDisFromMother()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            this.iDComboBox.ItemsSource = bl.GetAllMothers();
            iDComboBox.DisplayMemberPath = "MainDetails";
            iDComboBox.SelectedValuePath = "ID";
            DataContext = myData;
        }

        private void DisTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            BE.Mother m = bl.GetMother(myData.Id);
            if (m != null)
                NanniesDataGrid.ItemsSource = bl.DistanseFromMotherInKM(bl.GetMother(myData.Id), myData.Distance);
        }
    }
}
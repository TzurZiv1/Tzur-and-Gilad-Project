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
    /// Interaction logic for GoodNanniesToMother.xaml
    /// </summary>
    public partial class GoodNanniesToMother : Window
    {
        BL.IBL bl;
        class MyData
        {
            int id;
            public int Id { get => id; set => id = value; }
        }
        MyData myData = new MyData() { Id = 0 };
        /// <summary>
        /// constructor of GoodNanniesToMother
        /// </summary>
        public GoodNanniesToMother()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            this.iDComboBox.DataContext = myData;
            this.iDComboBox.ItemsSource = bl.GetAllMothers();
            iDComboBox.DisplayMemberPath = "MainDetails";
            iDComboBox.SelectedValuePath = "ID";
        }
        /// <summary>
        /// update NanniesDataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NanniesDataGrid.ItemsSource = bl.MatchNannies(bl.GetMother((int)iDComboBox.SelectedValue));
        }
    }
}

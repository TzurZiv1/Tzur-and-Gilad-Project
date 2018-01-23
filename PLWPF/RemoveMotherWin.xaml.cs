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
    /// Interaction logic for RemoveMotherWin.xaml
    /// </summary>
    public partial class RemoveMotherWin : Window
    {
        class MyData
        {
            int id;
            public int Id { get => id; set => id = value; }
        }
        BL.IBL bl;
        MyData myData = new MyData() { Id = 0 };
        public RemoveMotherWin()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            this.iDComboBox.ItemsSource = bl.GetAllMothers();
            iDComboBox.DisplayMemberPath = "MainDetails";
            iDComboBox.SelectedValuePath = "ID";
            iDComboBox.DataContext = myData;
        }

        private void RemoveMotherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.RemoveMother(myData.Id);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}

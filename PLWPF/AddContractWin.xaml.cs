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
    /// Interaction logic for AddContractWin.xaml
    /// </summary>
    public partial class AddContractWin : Window
    {
        BE.Contract contract;
        BL.IBL bl;
        public AddContractWin()
        {
            InitializeComponent();

            contract = new BE.Contract();
            this.DataContext = contract;
            bl = BL.FactoryBL.GetBL();
            this.motherIDComboBox.ItemsSource = bl.GetAllMothers();
            motherIDComboBox.DisplayMemberPath = "ID";
            this.childIDComboBox.ItemsSource = bl.GetAllChilds();
            childIDComboBox.DisplayMemberPath = "ID";
            this.nunnyIDComboBox.ItemsSource = bl.GetAllNannies();
            nunnyIDComboBox.DisplayMemberPath = "ID";
        }
        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddContract(contract);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            this.Close();
        }

    }

}


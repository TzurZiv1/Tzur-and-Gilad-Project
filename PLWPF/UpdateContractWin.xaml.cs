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
    /// Interaction logic for UpdateContractWin.xaml
    /// </summary>
    public partial class UpdateContractWin : Window
    {
        BE.Contract contract;
        BL.IBL bl;
        public UpdateContractWin()
        {
            InitializeComponent();
            contract = new BE.Contract();
            this.DataContext = contract;
            bl = BL.FactoryBL.GetBL();

            this.numberComboBox.ItemsSource = bl.GetAllContracts();
            numberComboBox.DisplayMemberPath = "MainDetails";
            numberComboBox.SelectedValuePath = "Number";
        }

        private void UpdateContractButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                contract.MotherID = bl.GetChild(contract.ChildID).MotherID;
                bl.UpdateContract(contract);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void numberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nannyIDTextBlock.Text = bl.GetContract((int)numberComboBox.SelectedValue).NannyID.ToString();
            childIDTextBlock.Text = bl.GetContract((int)numberComboBox.SelectedValue).ChildID.ToString();
        }
    }
}

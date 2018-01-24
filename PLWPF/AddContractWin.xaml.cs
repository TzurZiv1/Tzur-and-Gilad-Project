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
        private List<string> errorMessages = new List<string>();
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add((string)e.Error.ErrorContent);
            else
                errorMessages.Remove((string)e.Error.ErrorContent);
        }
        public AddContractWin()
        {
            InitializeComponent();

            contract = new BE.Contract();
            this.DataContext = contract;
            bl = BL.FactoryBL.GetBL();
            
            this.childIDComboBox.ItemsSource = bl.GetAllChilds();
            childIDComboBox.DisplayMemberPath = "MainDetails";
            childIDComboBox.SelectedValuePath = "ID";
            this.nannyIDComboBox.ItemsSource = bl.GetAllNannies();
            nannyIDComboBox.DisplayMemberPath = "MainDetails";
            nannyIDComboBox.SelectedValuePath = "ID";
            numberTextBlock.Text = (bl.CurrentNumber() + 1).ToString();
        }
        private void AddContractButton_Click(object sender, RoutedEventArgs e)
        {
            if (errorMessages.Any()) //errorMessages.Count > 0  
            {
                string err = "Exception:";
                foreach (var item in errorMessages)
                    err += "\n" + item;
                System.Windows.MessageBox.Show(err);
                return;
            }
            try
            {
                if (nannyIDComboBox.SelectedValue == null)
                    throw new Exception("No nanny was selected");
                if (childIDComboBox.SelectedValue == null)
                    throw new Exception("No child was selected");
                contract.MotherID = bl.GetChild(contract.ChildID).MotherID;
                bl.AddContract(contract);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return;
            }
            this.Close();
        }
    }

}


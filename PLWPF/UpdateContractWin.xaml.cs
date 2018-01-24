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
        private List<string> errorMessages = new List<string>();
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add((string)e.Error.ErrorContent);
            else
                errorMessages.Remove((string)e.Error.ErrorContent);
        }
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
                if(numberComboBox.SelectedValue == null)
                    throw new Exception("No contract was selected");

                contract.MotherID = bl.GetChild(contract.ChildID).MotherID;
                contract.IsPerMonth = bl.GetContract(contract.Number).IsPerMonth;
                contract.WagePerHour = bl.GetContract(contract.Number).WagePerHour;
                contract.WagePerMonth = bl.GetContract(contract.Number).WagePerMonth;
                contract.WasSignature = bl.GetContract(contract.Number).WasSignature;

                bl.UpdateContract(contract);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return;
            }
            this.Close();
        }

        private void numberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            nannyIDTextBlock.Text = bl.GetContract((int)numberComboBox.SelectedValue).NannyID.ToString();
            childIDTextBlock.Text = bl.GetContract((int)numberComboBox.SelectedValue).ChildID.ToString();
            startDateDatePicker.SelectedDate = bl.GetContract((int)numberComboBox.SelectedValue).StartDate;
            endDateDatePicker.SelectedDate = bl.GetContract((int)numberComboBox.SelectedValue).EndDate;
            wasMeetingCheckBox.IsChecked = bl.GetContract((int)numberComboBox.SelectedValue).WasMeeting;
        }
    }
}
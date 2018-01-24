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
    /// Interaction logic for UpdateNannyWin.xaml
    /// </summary>
    public partial class UpdateNannyWin : Window
    {
        BE.Nanny nanny;
        BL.IBL bl;

        public UpdateNannyWin()
        {
            InitializeComponent();
            nanny = new BE.Nanny();
            this.DataContext = nanny;
            bl = BL.FactoryBL.GetBL();
            this.iDComboBox.ItemsSource = bl.GetAllNannies().Select(x => x.ID);
        }

        private void UpdateNannyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (iDComboBox.SelectedValue == null)
                    throw new Exception("No nanny was selected");
                bl.UpdateNanny(nanny);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                if (ex.Message == "No nanny was selected")
                    return;
            }
            this.Close();
        }

        private void iDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addressPlaceAutoCompleteUC.Text = bl.GetNanny(nanny.ID).Address;
            allowPerHourCheckBox.IsChecked = bl.GetNanny(nanny.ID).AllowPerHour;
            birthdateDatePicker.SelectedDate = bl.GetNanny(nanny.ID).Birthdate;
            expYearsTextBox.Text = bl.GetNanny(nanny.ID).ExpYears.ToString();
            financedVacationCheckBox.IsChecked = bl.GetNanny(nanny.ID).FinancedVacation;
            firstNameTextBox.Text = bl.GetNanny(nanny.ID).FirstName;
            floorTextBox.Text = bl.GetNanny(nanny.ID).Floor.ToString();
            isElevatorCheckBox.IsChecked = bl.GetNanny(nanny.ID).IsElevator;
            lastNameTextBox.Text = bl.GetNanny(nanny.ID).LastName;
            maxAgeInMonthTextBox.Text = bl.GetNanny(nanny.ID).MaxAgeInMonth.ToString();
            maxChildsTextBox.Text = bl.GetNanny(nanny.ID).MaxChilds.ToString();
            minAgeInMonthTextBox.Text = bl.GetNanny(nanny.ID).MinAgeInMonth.ToString();
            phoneNumberTextBox.Text = bl.GetNanny(nanny.ID).PhoneNumber;
            ratePerHourTextBox.Text = bl.GetNanny(nanny.ID).RatePerHour.ToString();
            ratePerMonthTextBox.Text = bl.GetNanny(nanny.ID).RatePerMonth.ToString();
            recommendationsTextBox.Text = bl.GetNanny(nanny.ID).Recommendations;
            addressPlaceAutoCompleteUC.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            expYearsTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            firstNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            floorTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            lastNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            maxAgeInMonthTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            maxChildsTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            minAgeInMonthTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            phoneNumberTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            ratePerHourTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            ratePerMonthTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            recommendationsTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}

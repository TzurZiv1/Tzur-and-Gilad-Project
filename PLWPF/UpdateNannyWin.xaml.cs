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
        private List<string> errorMessages =new List<string>();
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add((string)e.Error.ErrorContent);
            else
                errorMessages.Remove((string)e.Error.ErrorContent);
        }
        public UpdateNannyWin()
        {
            InitializeComponent();
            nanny = new BE.Nanny();
            this.DataContext = nanny;
            bl = BL.FactoryBL.GetBL();
            this.iDComboBox.ItemsSource = bl.GetAllNannies();
            iDComboBox.DisplayMemberPath = "MainDetails";
            iDComboBox.SelectedValuePath = "ID";
        }

        private void UpdateNannyButton_Click(object sender, RoutedEventArgs e)
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
                nanny.Address = addressPlaceAutoCompleteUC.Text;

                bl.UpdateNanny(nanny);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return;
            }
            this.Close();
        }

        private void iDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BE.Nanny n = bl.GetNanny(nanny.ID);

            #region initialization
            addressPlaceAutoCompleteUC.Text = n.Address;
            allowPerHourCheckBox.IsChecked = n.AllowPerHour;
            birthdateDatePicker.SelectedDate = n.Birthdate;
            expYearsTextBox.Text = n.ExpYears.ToString();
            financedVacationCheckBox.IsChecked = n.FinancedVacation;
            firstNameTextBox.Text = n.FirstName;
            floorTextBox.Text = n.Floor.ToString();
            isElevatorCheckBox.IsChecked = n.IsElevator;
            lastNameTextBox.Text = n.LastName;
            maxAgeInMonthTextBox.Text = n.MaxAgeInMonth.ToString();
            maxChildsTextBox.Text = n.MaxChilds.ToString();
            minAgeInMonthTextBox.Text = n.MinAgeInMonth.ToString();
            phoneNumberTextBox.Text = n.PhoneNumber;
            ratePerHourTextBox.Text = n.RatePerHour.ToString();
            ratePerMonthTextBox.Text = n.RatePerMonth.ToString();
            recommendationsTextBox.Text = n.Recommendations;
            wod0.IsChecked = n.WorkOnDay[0];
            wod1.IsChecked = n.WorkOnDay[1];
            wod2.IsChecked = n.WorkOnDay[2];
            wod3.IsChecked = n.WorkOnDay[3];
            wod4.IsChecked = n.WorkOnDay[4];
            wod5.IsChecked = n.WorkOnDay[5];
            hods0.Text = n.HoursOnDay[0].Start.ToString();
            hods1.Text = n.HoursOnDay[1].Start.ToString();
            hods2.Text = n.HoursOnDay[2].Start.ToString();
            hods3.Text = n.HoursOnDay[3].Start.ToString();
            hods4.Text = n.HoursOnDay[4].Start.ToString();
            hods5.Text = n.HoursOnDay[5].Start.ToString();
            hodf0.Text = n.HoursOnDay[0].Finish.ToString();
            hodf1.Text = n.HoursOnDay[1].Finish.ToString();
            hodf2.Text = n.HoursOnDay[2].Finish.ToString();
            hodf3.Text = n.HoursOnDay[3].Finish.ToString();
            hodf4.Text = n.HoursOnDay[4].Finish.ToString();
            hodf5.Text = n.HoursOnDay[5].Finish.ToString();

            nanny.Address = n.Address;
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
            #endregion
        }
    }
}

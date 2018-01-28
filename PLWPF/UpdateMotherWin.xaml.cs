using PLWPF.UserControl;
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
    /// Interaction logic for UpdateMotherWin.xaml
    /// </summary>
    public partial class UpdateMotherWin : Window
    {
        BE.Mother mother;
        BL.IBL bl;
        private List<string> errorMessages = new List<string>();
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add((string)e.Error.ErrorContent);
            else
                errorMessages.Remove((string)e.Error.ErrorContent);
        }
        public UpdateMotherWin()
        {
            InitializeComponent();
            mother = new BE.Mother();
            this.DataContext = mother;
            bl = BL.FactoryBL.GetBL();
            iDComboBox.ItemsSource = bl.GetAllMothers();
            iDComboBox.DisplayMemberPath = "MainDetails";
            iDComboBox.SelectedValuePath = "ID";
        }

        private void UpdateMotherButton_Click(object sender, RoutedEventArgs e)
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
                if (iDComboBox.SelectedValue == null)
                    throw new Exception("No mother was selected");

                mother.Address = addressPlaceAutoCompleteUC.Text;
                mother.Area = areaPlaceAutoCompleteUC.Text;

                bl.UpdateMother(mother);
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
            BE.Mother m = bl.GetMother(mother.ID);

            addressPlaceAutoCompleteUC.Text = m.Address;
            areaPlaceAutoCompleteUC.Text = m.Area;
            firstNameTextBox.Text = m.FirstName;
            isPerMonthCheckBox.IsChecked = m.IsPerMonth;
            lastNameTextBox.Text = m.LastName;
            notesTextBox.Text = m.Notes;
            phoneNumberTextBox.Text = m.PhoneNumber;
            nnod0.IsChecked = m.NeedNannyOnDay[0];
            nnod1.IsChecked = m.NeedNannyOnDay[1];
            nnod2.IsChecked = m.NeedNannyOnDay[2];
            nnod3.IsChecked = m.NeedNannyOnDay[3];
            nnod4.IsChecked = m.NeedNannyOnDay[4];
            nnod5.IsChecked = m.NeedNannyOnDay[5];
            hods0.Text = m.HoursForDay[0].Start.ToString();
            hods1.Text = m.HoursForDay[1].Start.ToString();
            hods2.Text = m.HoursForDay[2].Start.ToString();
            hods3.Text = m.HoursForDay[3].Start.ToString();
            hods4.Text = m.HoursForDay[4].Start.ToString();
            hods5.Text = m.HoursForDay[5].Start.ToString();
            hodf0.Text = m.HoursForDay[0].Finish.ToString();
            hodf1.Text = m.HoursForDay[1].Finish.ToString();
            hodf2.Text = m.HoursForDay[2].Finish.ToString();
            hodf3.Text = m.HoursForDay[3].Finish.ToString();
            hodf4.Text = m.HoursForDay[4].Finish.ToString();
            hodf5.Text = m.HoursForDay[5].Finish.ToString();

            mother.Address = m.Address;
            mother.Area = m.Area;
            firstNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            lastNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            notesTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            phoneNumberTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
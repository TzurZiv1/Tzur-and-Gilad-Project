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
    /// Interaction logic for UpdateChildWin.xaml
    /// </summary>
    public partial class UpdateChildWin : Window
    {
        BE.Child child;
        BL.IBL bl;
        private List<string> errorMessages = new List<string>();
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add((string)e.Error.ErrorContent);
            else
                errorMessages.Remove((string)e.Error.ErrorContent);
        }
        public UpdateChildWin()
        {
            InitializeComponent();
            child = new BE.Child();
            this.DataContext = child;
            bl = BL.FactoryBL.GetBL();
            iDComboBox.ItemsSource = bl.GetAllChilds();
            iDComboBox.DisplayMemberPath = "MainDetails";
            iDComboBox.SelectedValuePath = "ID";
        }

        private void UpdateChildButton_Click(object sender, RoutedEventArgs e)
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
                    throw new Exception("No child was selected");

                child.MotherID = bl.GetChild(child.ID).MotherID;
                bl.UpdateChild(child);
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
            firstNameTextBox.Text = bl.GetChild(child.ID).FirstName;
            birthdateDatePicker.SelectedDate = bl.GetChild(child.ID).Birthdate;
            isSpecialCheckBox.IsChecked = bl.GetChild(child.ID).IsSpecial;
            specialNeedsTextBox.Text = bl.GetChild(child.ID).SpecialNeeds;
            firstNameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            specialNeedsTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
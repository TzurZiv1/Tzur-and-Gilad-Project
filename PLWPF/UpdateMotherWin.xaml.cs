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
            try
            {
                if (iDComboBox.SelectedValue == null)
                    throw new Exception("No mother was selected");

                bl.UpdateMother(mother);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                if (ex.Message == "No mother was selected")
                    return;
            }
            this.Close();
        }

        private void iDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            addressPlaceAutoCompleteUC.Text = bl.GetMother(mother.ID).Address;
            areaPlaceAutoCompleteUC.Text = bl.GetMother(mother.ID).Area;
            firstNameTextBox.Text = bl.GetMother(mother.ID).FirstName;
            // לא גמור!!!!!!!!
        }
    }
}
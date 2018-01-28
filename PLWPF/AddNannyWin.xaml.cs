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
using Xceed.Wpf.Toolkit;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddNannyWin.xaml
    /// </summary>
    public partial class AddNannyWin : Window
    {
        BE.Nanny nanny;
        BL.IBL bl;
        private List<string> errorMessages = new List<string>();
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add((string)e.Error.ErrorContent);
            else
                errorMessages.Remove((string)e.Error.ErrorContent);
        }
        public AddNannyWin()
        {
            InitializeComponent();
            nanny = new BE.Nanny();
            this.DataContext = nanny;
            bl = BL.FactoryBL.GetBL();
        }

        private void AddNannyButton_Click(object sender, RoutedEventArgs e)
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
                
                bl.AddNanny(nanny);
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

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
                #region initialization
                nanny.Address = addressPlaceAutoCompleteUC.Text;
                nanny.HoursOnDay = new BE.WorkHours[6];
                nanny.HoursOnDay[0] = new BE.WorkHours();
                nanny.HoursOnDay[1] = new BE.WorkHours();
                nanny.HoursOnDay[2] = new BE.WorkHours();
                nanny.HoursOnDay[3] = new BE.WorkHours();
                nanny.HoursOnDay[4] = new BE.WorkHours();
                nanny.HoursOnDay[5] = new BE.WorkHours();
                nanny.HoursOnDay[0].Start = int.Parse(hods0.Text);
                nanny.HoursOnDay[1].Start = int.Parse(hods1.Text);
                nanny.HoursOnDay[2].Start = int.Parse(hods2.Text);
                nanny.HoursOnDay[3].Start = int.Parse(hods3.Text);
                nanny.HoursOnDay[4].Start = int.Parse(hods4.Text);
                nanny.HoursOnDay[5].Start = int.Parse(hods5.Text);
                nanny.HoursOnDay[0].Finish = int.Parse(hodf0.Text);
                nanny.HoursOnDay[1].Finish = int.Parse(hodf1.Text);
                nanny.HoursOnDay[2].Finish = int.Parse(hodf2.Text);
                nanny.HoursOnDay[3].Finish = int.Parse(hodf3.Text);
                nanny.HoursOnDay[4].Finish = int.Parse(hodf4.Text);
                nanny.HoursOnDay[5].Finish = int.Parse(hodf5.Text);
                #endregion
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

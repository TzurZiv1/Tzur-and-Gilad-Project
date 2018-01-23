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
    }
}

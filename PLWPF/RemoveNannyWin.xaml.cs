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
    /// Interaction logic for RemoveNannyWin.xaml
    /// </summary>
    public partial class RemoveNannyWin : Window
    {
        BE.Nanny nanny;
        BL.IBL bl;
        public RemoveNannyWin()
        {
            InitializeComponent();
            nanny = new BE.Nanny();
            this.DataContext = nanny;
            bl = BL.FactoryBL.GetBL();
            this.iDComboBox.ItemsSource = bl.GetAllNannies()/*.Select(x => x.ID)*/;
        }

        private void RemoveNanny_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.RemoveNanny(nanny);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}

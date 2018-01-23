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
            this.iDComboBox.ItemsSource = bl.GetAllMothers().Select(x => x.ID);
        }

        private void UpdatemotherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.UpdateMother(mother);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}

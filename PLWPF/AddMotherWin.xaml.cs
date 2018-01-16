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
    /// Interaction logic for AddMotherWin.xaml
    /// </summary>
    public partial class AddMotherWin : Window
    {
        BE.Mother mother;
        BL.IBL bl;
        public AddMotherWin()
        {
            InitializeComponent();

            mother = new BE.Mother();
            this.DataContext = mother;
            bl = BL.FactoryBL.GetBL();
        }

        private void AddmotherButton_Click(object sender, RoutedEventArgs e)
        {
            try  {
                bl.AddMother(mother);
                mother = new BE.Mother();
                this.DataContext = mother;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            this.Close();
        }

    }
}

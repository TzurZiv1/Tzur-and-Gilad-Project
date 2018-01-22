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
    /// Interaction logic for AddChildWin.xaml
    /// </summary>
    public partial class AddChildWin : Window
    {
        BE.Child child;
        BL.IBL bl;
        public AddChildWin()
        {
            InitializeComponent();
            child = new BE.Child();
            this.DataContext = child;
            bl = BL.FactoryBL.GetBL();
            this.motherIDComboBox.ItemsSource = bl.GetAllMothers().Select(x => x.ID);
        }

        private void AddChildButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddChild(child);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
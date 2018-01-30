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
    /// Interaction logic for NanniesByExp.xaml
    /// </summary>
    public partial class NanniesByExp : Window
    {
        BL.IBL bl;
        class MyData
        {
            int years;
            public int Years { get => years; set => years = value; }
        }
        MyData myData = new MyData() { Years = 0 };
        public NanniesByExp()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            InitComboBox();
            yearsComboBox.DataContext = myData;
        }
        private void InitComboBox()
        {
            //foreach (var group in bl.NanniesByExpYears())
            //{
            //    yearsComboBox.Items.Add(new ComboBoxItem() { Content = group.Key.ToString() });
            //}
            List<int> keys = new List<int>();
            foreach (var group in bl.NanniesByExpYears())
            {
                keys.Add(group.Key);
            }
            yearsComboBox.ItemsSource = keys;
        }

        private void yearsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NanniesDataGrid.ItemsSource = (from Group in bl.NanniesByExpYears()
                                           where Group.Key == myData.Years
                                           select Group).FirstOrDefault();
        }
    }
}

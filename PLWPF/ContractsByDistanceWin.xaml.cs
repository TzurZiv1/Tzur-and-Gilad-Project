using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for ContractsByDistanceWin.xaml
    /// </summary>
    public partial class ContractsByDistanceWin : Window
    {
        BL.IBL bl;
        /// <summary>
        /// constructor of ContractsByDistanceWin
        /// </summary>
        public ContractsByDistanceWin()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            Thread thread = new Thread(InitComboBox);
            thread.Start();
        }
        /// <summary>
        /// update the data grid in a thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void distanceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Thread t = new Thread(UpdateDataDrid);
            t.Start();
        }
        /// <summary>
        /// intialization for distanceComboBox
        /// </summary>
        private void InitComboBox()
        {
            foreach (var items in bl.ContractsByDistance())
            {
                Action action = () => distanceComboBox.Items.Add(new ComboBoxItem() { Content = items.Key });
                Dispatcher.BeginInvoke(action);
            }
        }
        /// <summary>
        /// update the data grid of contracts
        /// </summary>
        private void UpdateDataDrid()
        {
            Action action = () => ContractsDataGrid.ItemsSource = (from dis in bl.ContractsByDistance()
                                            where dis.Key == (int)distanceComboBox.SelectedItem
                                            select dis).ToList();
            Dispatcher.BeginInvoke(action);
        }
    }
}
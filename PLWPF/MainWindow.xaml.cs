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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.IBL bl;
        public MainWindow()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
        }
        private void AddNanny_Click(object sender, RoutedEventArgs e)
        {
            AddNannyWin add = new AddNannyWin();
            add.ShowDialog();
        }

        private void AddMother_Click(object sender, RoutedEventArgs e)
        {
            AddMotherWin add = new AddMotherWin();
            add.ShowDialog();
        }

        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
            AddChildWin add = new AddChildWin();
            add.ShowDialog();
        }

        private void AddContract_Click(object sender, RoutedEventArgs e)
        {
            AddContractWin add = new AddContractWin();
            add.ShowDialog();
        }


        private void RemoveNanny_Click(object sender, RoutedEventArgs e)
        {
            RemoveNannyWin remove = new RemoveNannyWin();
            remove.ShowDialog();
        }

        private void RemoveMother_Click(object sender, RoutedEventArgs e)
        {
            RemoveMotherWin remove = new RemoveMotherWin();
            remove.ShowDialog();
        }

        private void RemoveChild_Click(object sender, RoutedEventArgs e)
        {
            RemoveChildWin remove = new RemoveChildWin();
            remove.ShowDialog();
        }

        private void RemoveContract_Click(object sender, RoutedEventArgs e)
        {
            RemoveContractWin remove = new RemoveContractWin();
            remove.ShowDialog();
        }


        private void UpdateNanny_Click(object sender, RoutedEventArgs e)
        {
            UpdateNannyWin update = new UpdateNannyWin();
            update.ShowDialog();
        }

        private void UpdateMother_Click(object sender, RoutedEventArgs e)
        {
            UpdateMotherWin update = new UpdateMotherWin();
            update.ShowDialog();
        }

        private void UpdateChild_Click(object sender, RoutedEventArgs e)
        {
            UpdateChildWin update = new UpdateChildWin();
            update.ShowDialog();
        }

        private void UpdateContract_Click(object sender, RoutedEventArgs e)
        {
            UpdateContractWin update = new UpdateContractWin();
            update.ShowDialog();
        }
    }
}

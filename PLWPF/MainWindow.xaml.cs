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
            if (bl.GetAllMothers().Count == 0)
            {
                AddChild.IsEnabled = false;
                AddContract.IsEnabled = false;
                RemoveMother.IsEnabled = false;
                UpdateMother.IsEnabled = false;
            }
            if (bl.GetAllNannies().Count == 0)
            {
                AddContract.IsEnabled = false;
                RemoveNanny.IsEnabled = false;
                UpdateNanny.IsEnabled = false;
            }
            if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
            if (bl.GetAllChilds().Count == 0)
            {
                RemoveChild.IsEnabled = false;
                UpdateChild.IsEnabled = false;
                AddContract.IsEnabled = false;
            }

        }
        private void AddNanny_Click(object sender, RoutedEventArgs e)
        {
            AddNannyWin add = new AddNannyWin();
            add.ShowDialog();
            if (bl.GetAllNannies().Count != 0)
            {
                AddContract.IsEnabled = true;
                RemoveNanny.IsEnabled = true;
                UpdateNanny.IsEnabled = true;
            }
        }

        private void AddMother_Click(object sender, RoutedEventArgs e)
        {
            AddMotherWin add = new AddMotherWin();
            add.ShowDialog();
            if (bl.GetAllMothers().Count != 0)
            {
                AddChild.IsEnabled = true;
                AddContract.IsEnabled = true;
                RemoveMother.IsEnabled = true;
                UpdateMother.IsEnabled = true;
            }
        }

        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
            AddChildWin add = new AddChildWin();
            add.ShowDialog();
            if (bl.GetAllChilds().Count != 0)
            {
                RemoveChild.IsEnabled = true;
                UpdateChild.IsEnabled = true;
                AddContract.IsEnabled = true;
            }
        }

        private void AddContract_Click(object sender, RoutedEventArgs e)
        {
            AddContractWin add = new AddContractWin();
            add.ShowDialog();
            if (bl.GetAllContracts().Count != 0)
            {
                RemoveContract.IsEnabled = true;
                UpdateContract.IsEnabled = true;
            }
        }


        private void RemoveNanny_Click(object sender, RoutedEventArgs e)
        {
            RemoveNannyWin remove = new RemoveNannyWin();
            remove.ShowDialog();
            if (bl.GetAllNannies().Count == 0)
            {
                AddContract.IsEnabled = false;
                RemoveNanny.IsEnabled = false;
                UpdateNanny.IsEnabled = false;
            }
        }

        private void RemoveMother_Click(object sender, RoutedEventArgs e)
        {
            RemoveMotherWin remove = new RemoveMotherWin();
            remove.ShowDialog();
            if (bl.GetAllMothers().Count == 0)
            {
                AddChild.IsEnabled = false;
                AddContract.IsEnabled = false;
                RemoveMother.IsEnabled = false;
                UpdateMother.IsEnabled = false;
            }
        }

        private void RemoveChild_Click(object sender, RoutedEventArgs e)
        {
            RemoveChildWin remove = new RemoveChildWin();
            remove.ShowDialog();
            if (bl.GetAllChilds().Count == 0)
            {
                RemoveChild.IsEnabled = false;
                UpdateChild.IsEnabled = false;
                AddContract.IsEnabled = false;
            }
        }

        private void RemoveContract_Click(object sender, RoutedEventArgs e)
        {
            RemoveContractWin remove = new RemoveContractWin();
            remove.ShowDialog();
            if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
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

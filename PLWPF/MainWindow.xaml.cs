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
        /// <summary>
        /// constructor of MainWindow that Initializes MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closed;
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
        /// <summary>
        /// close all program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        /// <summary>
        /// Open AddNannyWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNanny_Click(object sender, RoutedEventArgs e)
        {
            new AddNannyWin().ShowDialog();
            if (bl.GetAllNannies().Count != 0)
            {
                if (bl.GetAllMothers().Count != 0 && bl.GetAllChilds().Count != 0)
                    AddContract.IsEnabled = true;
                RemoveNanny.IsEnabled = true;
                UpdateNanny.IsEnabled = true;
            }
        }
        /// <summary>
        /// open AddMotherWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMother_Click(object sender, RoutedEventArgs e)
        {
            new AddMotherWin().ShowDialog();
            if (bl.GetAllMothers().Count != 0)
            {
                AddChild.IsEnabled = true;
                RemoveMother.IsEnabled = true;
                UpdateMother.IsEnabled = true;
            }
        }

        /// <summary>
        /// open AddChildWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddChild_Click(object sender, RoutedEventArgs e)
        {
            new AddChildWin().ShowDialog();
            if (bl.GetAllChilds().Count != 0)
            {
                if (bl.GetAllNannies().Count != 0 && bl.GetAllNannies().Count != 0)
                    AddContract.IsEnabled = true;
                RemoveChild.IsEnabled = true;
                UpdateChild.IsEnabled = true;

            }
        }

        /// <summary>
        /// open AddContractWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddContract_Click(object sender, RoutedEventArgs e)
        {
            new AddContractWin().ShowDialog();

            if (bl.GetAllContracts().Count != 0)
            {
                RemoveContract.IsEnabled = true;
                UpdateContract.IsEnabled = true;
            }
        }


        /// <summary>
        /// open RemoveNannyWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveNanny_Click(object sender, RoutedEventArgs e)
        {
            new RemoveNannyWin().ShowDialog();
            if (bl.GetAllNannies().Count == 0)
            {
                AddContract.IsEnabled = false;
                RemoveNanny.IsEnabled = false;
                RemoveContract.IsEnabled = false;
                UpdateNanny.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
            else if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
        }

        /// <summary>
        /// open RemoveMotherWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveMother_Click(object sender, RoutedEventArgs e)
        {
            new RemoveMotherWin().ShowDialog();
            if (bl.GetAllMothers().Count == 0)
            {
                AddChild.IsEnabled = false;
                AddContract.IsEnabled = false;
                RemoveMother.IsEnabled = false;
                RemoveContract.IsEnabled = false;
                RemoveChild.IsEnabled = false;
                UpdateMother.IsEnabled = false;
                UpdateChild.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
            else if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
            if (bl.GetAllChilds().Count == 0)
            {
                UpdateChild.IsEnabled = false;
                RemoveChild.IsEnabled = false;
            }
        }

        /// <summary>
        /// open RemoveChildWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveChild_Click(object sender, RoutedEventArgs e)
        {
            new RemoveChildWin().ShowDialog();
            if (bl.GetAllChilds().Count == 0)
            {
                RemoveChild.IsEnabled = false;
                RemoveContract.IsEnabled = false;
                UpdateChild.IsEnabled = false;
                UpdateContract.IsEnabled = false;
                AddContract.IsEnabled = false;
            }
            else if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
        }

        /// <summary>
        /// open RemoveContractWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveContract_Click(object sender, RoutedEventArgs e)
        {
            new RemoveContractWin().ShowDialog();
            if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
        }


        /// <summary>
        /// open UpdateNannyWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateNanny_Click(object sender, RoutedEventArgs e)
        {
            new UpdateNannyWin().ShowDialog();
            if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
        }

        /// <summary>
        /// open UpdateMotherWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateMother_Click(object sender, RoutedEventArgs e)
        {
            new UpdateMotherWin().ShowDialog();
            if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
            if (bl.GetAllChilds().Count == 0)
            {
                RemoveChild.IsEnabled = false;
                UpdateChild.IsEnabled = false;
            }
        }

        /// <summary>
        /// open UpdateChildWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateChild_Click(object sender, RoutedEventArgs e)
        {
            new UpdateChildWin().ShowDialog();
            if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
        }

        /// <summary>
        /// open UpdateContractWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateContract_Click(object sender, RoutedEventArgs e)
        {
            new UpdateContractWin().ShowDialog();
        }

        /// <summary>
        /// open AllNannies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetAllNannies_Click(object sender, RoutedEventArgs e)
        {
            new AllNannies().ShowDialog();
        }

        /// <summary>
        /// open AllNannies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetAllMothers_Click(object sender, RoutedEventArgs e)
        {
            new AllNannies().ShowDialog();
        }

        /// <summary>
        /// open AllChilds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetAllChilds_Click(object sender, RoutedEventArgs e)
        {
            new AllChilds().ShowDialog();
        }

        /// <summary>
        /// open AllContracts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetAllContracts_Click(object sender, RoutedEventArgs e)
        {
            new AllContracts().ShowDialog();
        }

        /// <summary>
        /// open ChildsOfMotherWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChildsOfMother_Click(object sender, RoutedEventArgs e)
        {
            new ChildsOfMotherWin().ShowDialog();
        }

        /// <summary>
        /// open ContractsByDistanceWin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContractsByDistance_Click(object sender, RoutedEventArgs e)
        {
            new ContractsByDistanceWin().ShowDialog();
        }

        /// <summary>
        /// open NanniesByDisFromMother
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NanniesByDisFromMother_Click(object sender, RoutedEventArgs e)
        {
            new NanniesByDisFromMother().ShowDialog();
        }

        /// <summary>
        /// open GoodNanniesToMother
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodNanniesToMother_Click(object sender, RoutedEventArgs e)
        {
            new GoodNanniesToMother().ShowDialog();
        }

        /// <summary>
        /// open NanniesByExp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NanniesByExp_Click(object sender, RoutedEventArgs e)
        {
            new NanniesByExp().ShowDialog();
        }
    }
}
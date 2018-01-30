﻿using System;
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
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
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

        private void AddContract_Click(object sender, RoutedEventArgs e)
        {
            new AddContractWin().ShowDialog();

            if (bl.GetAllContracts().Count != 0)
            {
                RemoveContract.IsEnabled = true;
                UpdateContract.IsEnabled = true;
            }
        }


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
            if(bl.GetAllChilds().Count == 0)
            {
                UpdateChild.IsEnabled = false;
                RemoveChild.IsEnabled = false;
            }
        }

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

        private void RemoveContract_Click(object sender, RoutedEventArgs e)
        {
            new RemoveContractWin().ShowDialog();
            if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
        }


        private void UpdateNanny_Click(object sender, RoutedEventArgs e)
        {
            new UpdateNannyWin().ShowDialog();
            if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
        }

        private void UpdateMother_Click(object sender, RoutedEventArgs e)
        {
            new UpdateMotherWin().ShowDialog();
            if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
            if(bl.GetAllChilds().Count == 0)
            {
                RemoveChild.IsEnabled = false;
                UpdateChild.IsEnabled = false;
            }
        }

        private void UpdateChild_Click(object sender, RoutedEventArgs e)
        {
            new UpdateChildWin().ShowDialog();
            if (bl.GetAllContracts().Count == 0)
            {
                RemoveContract.IsEnabled = false;
                UpdateContract.IsEnabled = false;
            }
        }

        private void UpdateContract_Click(object sender, RoutedEventArgs e)
        {
            new UpdateContractWin().ShowDialog();
        }

        private void GetAllNannies_Click(object sender, RoutedEventArgs e)
        {
            new AllNannies().ShowDialog();
        }

        private void GetAllMothers_Click(object sender, RoutedEventArgs e)
        {
            new AllMothers().ShowDialog();
        }

        private void GetAllChilds_Click(object sender, RoutedEventArgs e)
        {
            new AllChilds().ShowDialog();
        }

        private void GetAllContracts_Click(object sender, RoutedEventArgs e)
        {
            new AllContracts().ShowDialog();
        }

        private void ChildsOfMother_Click(object sender, RoutedEventArgs e)
        {
            new ChildsOfMotherWin().ShowDialog();
        }

        private void ContractsByDistance_Click(object sender, RoutedEventArgs e)
        {
            new ContractsByDistanceWin().ShowDialog();
        }

        private void NanniesByDisFromMother_Click(object sender, RoutedEventArgs e)
        {
            new NanniesByDisFromMother().ShowDialog();
        }
    }
}

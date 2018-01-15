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
            bl = BL.FactoryBL.GetBL();
        }
		private void Hid()
		{
			AddNanny.Visibility = Visibility.Hidden;
			RemoveNanny.Visibility = Visibility.Hidden;
			UpdateNanny.Visibility = Visibility.Hidden;

			AddMother.Visibility = Visibility.Hidden;
			RemoveMother.Visibility = Visibility.Hidden;
			UpdateMother.Visibility = Visibility.Hidden;

			AddChild.Visibility = Visibility.Hidden;
			RemoveChild.Visibility = Visibility.Hidden;
			UpdateChild.Visibility = Visibility.Hidden;

			AddContract.Visibility = Visibility.Hidden;
			RemoveContract.Visibility = Visibility.Hidden;
			UpdateContract.Visibility = Visibility.Hidden;
		}
		private void Nanny_Click(object sender, RoutedEventArgs e)
		{
			Hid();
			AddNanny.Visibility = Visibility.Visible;
			RemoveNanny.Visibility = Visibility.Visible;
			UpdateNanny.Visibility = Visibility.Visible;
		}

		private void Mother_Click(object sender, RoutedEventArgs e)
		{
			Hid();
			AddMother.Visibility = Visibility.Visible;
			RemoveMother.Visibility = Visibility.Visible;
			UpdateMother.Visibility = Visibility.Visible;
		}

		private void Child_Click(object sender, RoutedEventArgs e)
		{
			Hid();
			AddChild.Visibility = Visibility.Visible;
			RemoveChild.Visibility = Visibility.Visible;
			UpdateChild.Visibility = Visibility.Visible;
		}

		private void Contract_Click(object sender, RoutedEventArgs e)
		{
			Hid();
			AddContract.Visibility = Visibility.Visible;
			RemoveContract.Visibility = Visibility.Visible;
			UpdateContract.Visibility = Visibility.Visible;
		}
	}
}
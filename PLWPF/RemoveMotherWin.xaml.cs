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
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for RemoveMotherWin.xaml
    /// </summary>
    public partial class RemoveMotherWin : Window
    {
        BL.IBL bl;
        public RemoveMotherWin()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            this.iDComboBox.ItemsSource = bl.GetAllMothers();
        }

        private void RemoveMotherButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

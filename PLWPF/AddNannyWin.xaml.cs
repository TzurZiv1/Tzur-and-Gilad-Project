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
    /// Interaction logic for AddNannyWin.xaml
    /// </summary>
    public partial class AddNannyWin : Window
    {
        BE.Nanny nanny;
        BL.IBL bl;
        public AddNannyWin()
        {
            InitializeComponent();

            nanny = new BE.Nanny();
            this.DataContext = nanny;
            bl = BL.FactoryBL.GetBL();

        }

        private void AddNannyButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                bl.AddNanny(nanny);
                nanny = new BE.Nanny();
                this.DataContext = nanny;
            }
            catch (Exception ex)
            {
               System.Windows.MessageBox.Show(ex.Message);
            }
            this.Close();
        }

    }
}

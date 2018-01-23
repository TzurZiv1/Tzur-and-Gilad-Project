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
    /// Interaction logic for RemoveNannyWin.xaml
    /// </summary>
    public partial class RemoveNannyWin : Window
    {
        class MyData
        {
            int id;
            public int Id { get => id; set => id = value; }
        }
        BL.IBL bl;
        MyData myData = new MyData() { Id = 0 };

        public RemoveNannyWin()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            this.iDComboBox.ItemsSource = bl.GetAllNannies();
            //iDComboBox.DisplayMemberPath = "MainDetails";
            iDComboBox.SelectedValuePath = "ID";
            iDComboBox.DataContext = myData;
        }

        private void RemoveNannyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (iDComboBox.SelectedValue == null)
                    throw new Exception("No nanny was selected");
                bl.RemoveNanny(myData.Id);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                if (ex.Message == "No nanny was selected")
                    return;
            }
            this.Close();
        }
    }
}

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
    /// Interaction logic for RemoveContractWin.xaml
    /// </summary>
    public partial class RemoveContractWin : Window
    {
        class MyData
        {
            int number;
            public int Number { get => number; set => number = value; }
        }
        BL.IBL bl;
        MyData myData = new MyData() { Number = 0 };
        private List<string> errorMessages = new List<string>();
        /// <summary>
        /// Manages Binding errors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add((string)e.Error.ErrorContent);
            else
                errorMessages.Remove((string)e.Error.ErrorContent);
        }

        /// <summary>
        /// constructor for RemoveContractWin
        /// </summary>
        public RemoveContractWin()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            numberComboBox.DataContext = myData;
            this.numberComboBox.ItemsSource = bl.GetAllContracts();
            numberComboBox.DisplayMemberPath = "MainDetails";
            numberComboBox.SelectedValuePath = "Number";
        }

        /// <summary>
        /// Remove the contract that has enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveContractButton_Click(object sender, RoutedEventArgs e)
        {
            if (errorMessages.Any()) //errorMessages.Count > 0  
            {
                string err = "Exception:";
                foreach (var item in errorMessages)
                    err += "\n" + item;
                System.Windows.MessageBox.Show(err);
                return;
            }
            try
            {
                if (numberComboBox.SelectedValue == null)
                    throw new Exception("No contract was selected");
                bl.RemoveContract(myData.Number);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return;
            }
            Close();
        }
    }
}

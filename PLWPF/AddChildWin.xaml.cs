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
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AddChildWin.xaml
    /// </summary>
    public partial class AddChildWin : Window
    {
        BE.Child child;
        BL.IBL bl;
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
        /// constructor of AddChildWin
        /// </summary>
        public AddChildWin()
        {
            InitializeComponent();
            child = new BE.Child();
            this.DataContext = child;
            bl = BL.FactoryBL.GetBL();
            this.motherIDComboBox.ItemsSource = bl.GetAllMothers();
            motherIDComboBox.DisplayMemberPath = "MainDetails";
            motherIDComboBox.SelectedValuePath = "ID";
        }
        /// <summary>
        /// add the child that have enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddChildButton_Click(object sender, RoutedEventArgs e)
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
                if (motherIDComboBox.SelectedValue == null)
                    throw new Exception("No mother was selected");

                bl.AddChild(child);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                    return;
            }
            this.Close();
        }
    }
}
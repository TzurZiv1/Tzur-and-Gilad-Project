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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for RemoveChildWin.xaml
    /// </summary>
    public partial class RemoveChildWin : Window
    {
        class MyData
        {
            int id;
            public int Id { get => id; set => id = value; }
        }
        BL.IBL bl;
        MyData myData = new MyData() { Id = 0 };
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
        /// constructor for RemoveChildWin
        /// </summary>
        public RemoveChildWin()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();
            this.iDComboBox.ItemsSource = bl.GetAllChilds();
            iDComboBox.DisplayMemberPath = "MainDetails";
            iDComboBox.SelectedValuePath = "ID";
            iDComboBox.DataContext = myData;
        }

        /// <summary>
        /// Remove the child that has enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveChildButton_Click(object sender, RoutedEventArgs e)
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
                if (iDComboBox.SelectedValue == null)
                    throw new Exception("No child was selected");
                bl.RemoveChild(myData.Id);
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

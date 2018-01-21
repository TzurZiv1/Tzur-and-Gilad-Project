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
    /// Interaction logic for AddMotherWin.xaml
    /// </summary>
    public partial class AddMotherWin : Window
    {
        BE.Mother mother;
        BL.IBL bl;
        public AddMotherWin()
        {
            InitializeComponent();
           
            mother = new BE.Mother();
            this.DataContext = mother;
            bl = BL.FactoryBL.GetBL();
        }

        private void AddmotherButton_Click(object sender, RoutedEventArgs e)
        {
            try  {
                #region initialization
                mother.Address = addressPlaceAutoCompleteUC.Text;
                mother.HoursForDay = new BE.WorkHours[6];
                mother.HoursForDay[0] = new BE.WorkHours();
                mother.HoursForDay[1] = new BE.WorkHours();
                mother.HoursForDay[2] = new BE.WorkHours();
                mother.HoursForDay[3] = new BE.WorkHours();
                mother.HoursForDay[4] = new BE.WorkHours();
                mother.HoursForDay[5] = new BE.WorkHours();
                mother.HoursForDay[0].Start = int.Parse(hods0.Text);
                mother.HoursForDay[1].Start = int.Parse(hods1.Text);
                mother.HoursForDay[2].Start = int.Parse(hods2.Text);
                mother.HoursForDay[3].Start = int.Parse(hods3.Text);
                mother.HoursForDay[4].Start = int.Parse(hods4.Text);
                mother.HoursForDay[5].Start = int.Parse(hods5.Text);
                mother.HoursForDay[0].Finish = int.Parse(hodf0.Text);
                mother.HoursForDay[1].Finish = int.Parse(hodf1.Text);
                mother.HoursForDay[2].Finish = int.Parse(hodf2.Text);
                mother.HoursForDay[3].Finish = int.Parse(hodf3.Text);
                mother.HoursForDay[4].Finish = int.Parse(hodf4.Text);
                mother.HoursForDay[5].Finish = int.Parse(hodf5.Text);
                #endregion
                bl.AddMother(mother);
                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            this.Close();
        }

    }
}

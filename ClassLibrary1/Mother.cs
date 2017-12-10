using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        private string MotherID;
        private string MotherLastName;
        private string MotherFirstName;
        private string MotherPhonenumber;
        private string MotherAdress;
        private string MotherArea;
        private bool[] Week = new bool[7];
        private int[,] HoursForWeek = new int[2, 6];
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

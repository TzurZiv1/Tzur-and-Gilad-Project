using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        private string motherID;
        private string motherLastName;
        private string motherFirstName;
        private string motherPhonenumber;
        private string motherAdress;
        private string motherArea;
        private bool[] week = new bool[7];
        private int[,] hoursForWeek = new int[2, 6];

        public string MotherID { get => motherID; set => motherID = value; }
        public string MotherLastName { get => motherLastName; set => motherLastName = value; }
        public string MotherFirstName { get => motherFirstName; set => motherFirstName = value; }
        public string MotherPhonenumber { get => motherPhonenumber; set => motherPhonenumber = value; }
        public string MotherAdress { get => motherAdress; set => motherAdress = value; }
        public string MotherArea { get => motherArea; set => motherArea = value; }
        public bool[] Week { get => week; set => week = value; }
        public int[,] HoursForWeek { get => hoursForWeek; set => hoursForWeek = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

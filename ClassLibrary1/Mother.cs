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

        public string MotherID1 { get => MotherID; set => MotherID = value; }
        public string MotherLastName1 { get => MotherLastName; set => MotherLastName = value; }
        public string MotherFirstName1 { get => MotherFirstName; set => MotherFirstName = value; }
        public string MotherPhonenumber1 { get => MotherPhonenumber; set => MotherPhonenumber = value; }
        public string MotherAdress1 { get => MotherAdress; set => MotherAdress = value; }
        public string MotherArea1 { get => MotherArea; set => MotherArea = value; }
        public bool[] Week1 { get => Week; set => Week = value; }
        public int[,] HoursForWeek1 { get => HoursForWeek; set => HoursForWeek = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        private string nannyID;
        private string nannyLastName;
        private string nannyName;
        private DateTime nannyBorthDate;
        private string nannyPhoneNumber;
        private string nannyAdress;
        private bool isElevator;
        private int nannyFloor;
        private int nannyYears;
        private int nannyNumChilds;
        private int nannyMaxChilds;
        private int nannyMaxAgeChilds;
        private bool isPerHour;
        private int nannyRatePerHour;
        private int nannyRatePerMonth;
        private bool [] week = new bool [7];
        private int[,] hoursForWeek = new int[2, 6];
        private bool financedVacation;
        private string nannyRecommendations;

        public string NannyID { get => nannyID; set => nannyID = value; }
        public string NannyLastName { get => nannyLastName; set => nannyLastName = value; }
        public string NannyName { get => nannyName; set => nannyName = value; }
        public DateTime NannyBorthDate { get => nannyBorthDate; set => nannyBorthDate = value; }
        public string NannyPhoneNumber { get => nannyPhoneNumber; set => nannyPhoneNumber = value; }
        public string NannyAdress { get => nannyAdress; set => nannyAdress = value; }
        public bool IsElevator { get => isElevator; set => isElevator = value; }
        public int NannyFloor { get => nannyFloor; set => nannyFloor = value; }
        public int NannyYears { get => nannyYears; set => nannyYears = value; }
        public int NannyNumChilds { get => nannyNumChilds; set => nannyNumChilds = value; }
        public int NannyMaxChilds { get => nannyMaxChilds; set => nannyMaxChilds = value; }
        public int NannyMaxAgeChilds { get => nannyMaxAgeChilds; set => nannyMaxAgeChilds = value; }
        public bool IsPerHour { get => isPerHour; set => isPerHour = value; }
        public int NannyRatePerHour { get => nannyRatePerHour; set => nannyRatePerHour = value; }
        public int NannyRatePerMonth { get => nannyRatePerMonth; set => nannyRatePerMonth = value; }
        public bool[] Week { get => week; set => week = value; }
        public int[,] HoursForWeek { get => hoursForWeek; set => hoursForWeek = value; }
        public bool FinancedVacation { get => financedVacation; set => financedVacation = value; }
        public string NannyRecommendations { get => nannyRecommendations; set => nannyRecommendations = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Nanny
    {
        private string NannyID;
        private string NannyLastName;
        private string NannyName;
        private DateTime NannyBorthDate;
        private string NannyPhoneNumber;
        private string NannyAdress;
        private bool IsElevator;
        private int NannyFloor;
        private int NannyYears;
        private int NannyNumChilds;
        private int NannyMaxChilds;
        private int NannyMaxAgeChilds;
        private bool IsPerHour;
        private int NannyRatePerHour;
        private int NannyRatePerMonth;
        private bool [] Week = new bool [7];
        private int[,] HoursForWeek = new int[2, 6];
        private bool FinancedVacation;
        private string NannyRecommendations;

        public string NannyID1 { get => NannyID; set => NannyID = value; }
        public string NannyLastName1 { get => NannyLastName; set => NannyLastName = value; }
        public string NannyName1 { get => NannyName; set => NannyName = value; }
        public DateTime NannyBorthDate1 { get => NannyBorthDate; set => NannyBorthDate = value; }
        public string NannyPhoneNumber1 { get => NannyPhoneNumber; set => NannyPhoneNumber = value; }
        public string NannyAdress1 { get => NannyAdress; set => NannyAdress = value; }
        public bool IsElevator1 { get => IsElevator; set => IsElevator = value; }
        public int NannyFloor1 { get => NannyFloor; set => NannyFloor = value; }
        public int NannyYears1 { get => NannyYears; set => NannyYears = value; }
        public int NannyNumChilds1 { get => NannyNumChilds; set => NannyNumChilds = value; }
        public int NannyMaxChilds1 { get => NannyMaxChilds; set => NannyMaxChilds = value; }
        public int NannyMaxAgeChilds1 { get => NannyMaxAgeChilds; set => NannyMaxAgeChilds = value; }
        public bool IsPerHour1 { get => IsPerHour; set => IsPerHour = value; }
        public int NannyRatePerHour1 { get => NannyRatePerHour; set => NannyRatePerHour = value; }
        public int NannyRatePerMonth1 { get => NannyRatePerMonth; set => NannyRatePerMonth = value; }
        public bool[] Week1 { get => Week; set => Week = value; }
        public int[,] HoursForWeek1 { get => HoursForWeek; set => HoursForWeek = value; }
        public bool FinancedVacation1 { get => FinancedVacation; set => FinancedVacation = value; }
        public string NannyRecommendations1 { get => NannyRecommendations; set => NannyRecommendations = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

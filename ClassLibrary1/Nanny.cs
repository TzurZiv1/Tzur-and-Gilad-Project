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
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

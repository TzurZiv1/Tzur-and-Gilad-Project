using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        private static int contractNumber = 0;
        private int numberOfcontract;
        private string nunnyID;
        private string childID;
        private bool wasMeeting;
        private bool signature;
        private int wagePerHour;
        private int wagePerMonth;
        private string perMonthOrHour;
        private DateTime beginOfContractDate;
        private DateTime endOfContractDate;
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

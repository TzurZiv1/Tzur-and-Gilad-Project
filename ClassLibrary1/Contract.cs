using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public static int contractNumber = 0;
        //private int numberOfcontract;
        private string nunnyID;
        private string childID;
        private bool wasMeeting;
        private bool signature;
        private int wagePerHour;
        private int wagePerMonth;
        private string perMonthOrHour;
        private DateTime beginOfContractDate;
        private DateTime endOfContractDate;

        public static int ContractNumber { get => contractNumber; set => contractNumber = value; }
        //public int NumberOfcontract { get => numberOfcontract; set => numberOfcontract = value; }
        public string NunnyID { get => nunnyID; set => nunnyID = value; }
        public string ChildID { get => childID; set => childID = value; }
        public bool WasMeeting { get => wasMeeting; set => wasMeeting = value; }
        public bool Signature { get => signature; set => signature = value; }
        public int WagePerHour { get => wagePerHour; set => wagePerHour = value; }
        public int WagePerMonth { get => wagePerMonth; set => wagePerMonth = value; }
        public string PerMonthOrHour { get => perMonthOrHour; set => perMonthOrHour = value; }
        public DateTime BeginOfContractDate { get => beginOfContractDate; set => beginOfContractDate = value; }
        public DateTime EndOfContractDate { get => endOfContractDate; set => endOfContractDate = value; }

        public override string ToString()
        {
            
            return base.ToString();
        }
    }
}

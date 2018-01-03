using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        private int number;
        private string nunnyID;
        private string childID;
        private bool wasMeeting;
        private bool wasSignature;
        private int wagePerHour;
        private int wagePerMonth;
        private bool perMonth;// true = per month. false = per hour
        private DateTime startDate = new DateTime();
        private DateTime endDate = new DateTime();

        public int Number { get => number; set => number = value; }
        public string NunnyID { get => nunnyID; set => nunnyID = value; }
        public string ChildID { get => childID; set => childID = value; }
        public bool WasMeeting { get => wasMeeting; set => wasMeeting = value; }
        public bool Signature { get => wasSignature; set => wasSignature = value; }
        public int WagePerHour { get => wagePerHour; set => wagePerHour = value; }
        public int WagePerMonth { get => wagePerMonth; set => wagePerMonth = value; }
        public bool PerMonth { get => perMonth; set => perMonth = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

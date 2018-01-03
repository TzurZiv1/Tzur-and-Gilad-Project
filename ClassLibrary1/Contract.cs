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
        private string motherID;
        private bool wasMeeting;
        private bool wasSignature;
        private double wagePerHour;
        private double wagePerMonth;
        private bool isPerMonth;// true = per month. false = per hour
        private DateTime startDate = new DateTime();
        private DateTime endDate = new DateTime();

        public int Number { get => number; set => number = value; }
        public string NunnyID { get => nunnyID; set => nunnyID = value; }
        public string ChildID { get => childID; set => childID = value; }
        public string MotherID { get => motherID; set => motherID = value; }
        public bool WasMeeting { get => wasMeeting; set => wasMeeting = value; }
        public bool WasSignature { get => wasSignature; set => wasSignature = value; }
        public double WagePerHour { get => wagePerHour; set => wagePerHour = value; }
        public double WagePerMonth { get => wagePerMonth; set => wagePerMonth = value; }
        public bool IsPerMonth { get => isPerMonth; set => isPerMonth = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

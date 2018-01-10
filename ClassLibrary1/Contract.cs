using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// Represents a contract, expressed as details and information about him.
    /// </summary>
    public class Contract
    {
        private int number;
        private int nunnyID;
        private int childID;
        private int motherID;
        private bool wasMeeting;
        private bool wasSignature;
        private double wagePerHour;
        private double wagePerMonth;
        private bool isPerMonth;// true = per month. false = per hour
        private DateTime startDate = new DateTime();
        private DateTime endDate = new DateTime();
        
        //Properties
        public int Number { get => number; set => number = value; }
        public int NunnyID
        {
            get => nunnyID;
            set
            {
                if (value > 0)
                    nunnyID = value;
                else
                    throw new Exception("ID can't be negative");
            }
        }
        public int ChildID
        {
            get => childID;
            set
            {
                if (value > 0)
                    childID = value;
                else
                    throw new Exception("ID can't be negative");
            }
        }
        public int MotherID
        {
            get => motherID;
            set
            {
                if (value > 0)
                    motherID = value;
                else
                    throw new Exception("ID can't be negative");
            }
        }
        public bool WasMeeting { get => wasMeeting; set => wasMeeting = value; }
        public bool WasSignature { get => wasSignature; set => wasSignature = value; }
        public double WagePerHour
        {
            get => wagePerHour;
            set
            {
                if (value >= 0)
                    wagePerHour = value;
                else
                    throw new Exception("WagePerHour can't be negative");
            }
        }
        public double WagePerMonth
        {
            get => wagePerMonth;
            set
            {
                if (value >= 0)
                    wagePerMonth = value;
                else
                    throw new Exception("WagePerMonth can't be negative");
            }
        }
        public bool IsPerMonth { get => isPerMonth; set => isPerMonth = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        /// <summary>
        /// Override for ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
			return
				"Number: " + Number + "\n" +
				"Nunny's ID: " + NunnyID + "\n" +
				"Child's ID: " + ChildID + "\n" +
				"Mother's ID: " + MotherID + "\n" +
				"Was meeting: " + WasMeeting + "\n" +
				"Was signature: " + WasSignature + "\n" +
				"Wage per hour: " + WagePerHour + "\n" +
				"Wage per month: " + WagePerMonth + "\n" +
				"Payment is calculated per " + (isPerMonth ? "month" : "hour") + "\n" +
				"Start date: " + StartDate + "\n" +
				"End date: " + EndDate + "\n";
		}
    }
}

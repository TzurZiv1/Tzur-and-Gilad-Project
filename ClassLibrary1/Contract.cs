﻿using System;
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
        private int nannyID;
        private int childID;
        private int motherID;
        private bool wasMeeting;
        private bool wasSignature;
        private double wagePerHour;
        private double wagePerMonth;
        private bool isPerMonth;// true = per month. false = per hour
        private DateTime startDate;
        private DateTime endDate;
        /// <summary>
        /// Returns the main details of contract
        /// </summary>
        public string MainDetails
        {
            get => "Number: " + Number + "\n" +
                "Nanny's ID: " + NannyID + "\n" +
                "Child's ID: " + ChildID + "\n" +
                "Mother's ID: " + MotherID;
        }
        /// <summary>
        /// Default constructor for contract
        /// </summary>
        public Contract()
        {
            startDate = DateTime.Now;
            endDate = DateTime.Now;
        }

        /// <summary>
        /// Constructor for contract
        /// </summary>
        public Contract(int nannyID1, int childID1, int motherID1, DateTime startDate1 = default(DateTime),
            DateTime endDate1 = default(DateTime), bool wasMeeting1 = false, double wagePerHour1 = 0,
            double wagePerMonth1 = 0, bool isPerMonth1 = false,
            bool wasSignature1 = false)
        {
            NannyID = nannyID1;
            ChildID = childID1;
            MotherID = motherID1;
            WagePerHour = wagePerHour1;
            WagePerMonth = wagePerMonth1;
            IsPerMonth = isPerMonth1;
            WasMeeting = wasMeeting1;
            WasSignature = wasSignature1;
            StartDate = startDate1;
            EndDate = endDate1;
        }

        //Properties
        public int Number { get => number; set => number = value; }
        public int NannyID
        {
            get => nannyID;
            set
            {
                if (value > 0)
                    nannyID = value;
                else
                    throw new Exception("ID can't be negative or zero");
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
                    throw new Exception("ID can't be negative or zero");
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
                    throw new Exception("ID can't be negative or zero");
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
        public DateTime EndDate
        {
            get => endDate;
            set
            {
                if (value >= StartDate)
                    endDate = value;
                else
                    throw new Exception("EndDate must be after startDate");
            }
        }
        

        /// <summary>
        /// Override for ToString
        /// </summary>
        /// <returns>contract represented as a string</returns>
        public override string ToString()
        {
            return
                "Number: " + Number + "\n" +
                "Nunny's ID: " + NannyID + "\n" +
                "Child's ID: " + ChildID + "\n" +
                "Mother's ID: " + MotherID + "\n" +
                "Was meeting: " + WasMeeting + "\n" +
                "Was signature: " + WasSignature + "\n" +
                "Wage per hour: " + WagePerHour + "\n" +
                "Wage per month: " + WagePerMonth + "\n" +
                "Payment is calculated per " + (isPerMonth ? "month" : "hour") + "\n" +
                "Start date: " + StartDate + "\n" +
                "End date: " + EndDate;
        }
    }
}

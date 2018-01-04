using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// Class for the nanny's work hours 
    /// </summary>
    public class WorkHours
    {
        private int start;
        private int finish;

        public int Start { get => start; set => start = value; }
        public int Finish { get => finish; set => finish = value; }

        /// <summary>
        /// Converts the value of the current WorkHours object to its equivalent string representation
        /// </summary>
        /// <returns>A string representation of the value of the current WorkHours object.</returns>
        public override string ToString()
        {
            return start + ":00 - " + finish + ":00";
        }
    }
    /// <summary>
    ///  Represents a nanny, expressed as details and information about her.
    /// </summary>
    public class Nanny
    {
        private string id;
        private string lastName;
        private string firstName;
        private DateTime birthDate = new DateTime();
        private string phoneNumber;
        private string address;
        private bool isElevator;
        private int floor;
        private int expYears;
        private int maxChilds;
        private int minAge;
        private int maxAge;
        private bool enablePerHour;
        private double ratePerHour;
        private double ratePerMonth;
        private bool[] workOnDay = new bool[6];
        private WorkHours[] hoursOnDay = new WorkHours[6];
        private bool financedVacation;
        private string recommendations;

        //Properties
        public string ID { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public DateTime BorthDate { get => birthDate; set => birthDate = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public bool IsElevator { get => isElevator; set => isElevator = value; }
        public int Floor { get => floor; set => floor = value; }
        public int ExpYears { get => expYears; set => expYears = value; }
        public int MaxChilds { get => maxChilds; set => maxChilds = value; }
        public int MinAge { get => minAge; set => minAge = value; }
        public int MaxAge { get => maxAge; set => maxAge = value; }
        public bool EnablePerHour { get => enablePerHour; set => enablePerHour = value; }
        public double RatePerHour { get => ratePerHour; set => ratePerHour = value; }
        public double RatePerMonth { get => ratePerMonth; set => ratePerMonth = value; }
        public bool[] WorkOnDay { get => workOnDay; set => workOnDay = value; }
        public WorkHours[] HoursOnDay { get => hoursOnDay; set => hoursOnDay = value; }
        public bool FinancedVacation { get => financedVacation; set => financedVacation = value; }
        public string Recommendations { get => recommendations; set => recommendations = value; }
        /// <summary>
        /// Override for ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

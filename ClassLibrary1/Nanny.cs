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
        private TimeSpan start;
        private TimeSpan finish;

        //properties
        public TimeSpan Start
        {
            get => start;
            set
            {
                if (value >= new TimeSpan(0,0,0) && value <= new TimeSpan(24, 0, 0))
                    start = value;
                else
                    throw new Exception("Work hours must be between 00:00 and 24:00");
            }
        }
        public TimeSpan Finish
        {
            get => finish;
            set
            {
                if (value >= new TimeSpan(0, 0, 0) && value <= new TimeSpan(24, 0, 0) && value >= Start)
                    finish = value;
                else if (value < new TimeSpan(0, 0, 0) || value > new TimeSpan(24, 0, 0))
                    throw new Exception("Work hours must be between 00:00 and 24:00");
                else
                    throw new Exception("Finish hour must be after start hour");
            }
        }
        /// <summary>
        /// constructor to WorkHours
        /// </summary>
        /// <param name="s"></param>
        /// <param name="f"></param>
        public WorkHours(TimeSpan s = default(TimeSpan), TimeSpan f = default(TimeSpan))
        {
            Start = s;
            Finish = f;
        }

        /// <summary>
        /// Converts the value of the current WorkHours object to its equivalent string representation
        /// </summary>
        /// <returns>A string representation of the value of the current WorkHours object.</returns>
        public override string ToString()
        {
            return (start == finish ? "nothing" : start + " - " + finish );
        }
    }

    /// <summary>
    ///  Represents a nanny, expressed as details and information about her.
    /// </summary>
    public class Nanny
    {
        private int id;
        private string lastName;
        private string firstName;
        private DateTime birthdate;
        private string phoneNumber;
        private string address;
        private bool isElevator;
        private int floor;
        private int expYears;
        private int maxChilds;
        private int minAgeInMonth;
        private int maxAgeInMonth;
        private bool allowPerHour;
        private double ratePerHour;
        private double ratePerMonth;
        private bool[] workOnDay;
        private WorkHours[] hoursOnDay;
        private bool financedVacation;
        private string recommendations;
        
        public Nanny()
        {
            hoursOnDay = new WorkHours[6];
            for (int i = 0; i < 6; i++)
            {
                hoursOnDay[i] = new WorkHours();
            }
            birthdate = DateTime.Now.AddYears(-18);
            workOnDay = new bool[6];
        }

        /// <summary>
        /// Constructor of nanny
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="firstName1"></param>
        /// <param name="lastName1"></param>
        /// <param name="birthdate1"></param>
        /// <param name="address1"></param>
        /// <param name="maxChilds1"></param>
        /// <param name="minAgeInMonth1"></param>
        /// <param name="maxAgeInMonth1"></param>
        /// <param name="workOnDay1"></param>
        /// <param name="hoursOnDay1"></param>
        /// <param name="ratePerHour1"></param>
        /// <param name="ratePerMonth1"></param>
        /// <param name="phoneNumber1"></param>
        /// <param name="isElevator1"></param>
        /// <param name="floor1"></param>
        /// <param name="expYears1"></param>
        /// <param name="allowPerHour1"></param>
        /// <param name="financedVacation1"></param>
        /// <param name="recommendations1"></param>
        public Nanny(int id1, string firstName1, string lastName1, DateTime birthdate1, string address1,
        int maxChilds1, int minAgeInMonth1, int maxAgeInMonth1, bool[] workOnDay1,
        WorkHours[] hoursOnDay1, double ratePerHour1, double ratePerMonth1 = 0,
        string phoneNumber1 = "No phone number", bool isElevator1 = false, int floor1 = 0,
        int expYears1 = 0, bool allowPerHour1 = false, bool financedVacation1 = false, string recommendations1 = "Nothing")
        {
            ID = id1;
            LastName = lastName1;
            FirstName = firstName1;
            Birthdate = birthdate1;
            PhoneNumber = phoneNumber1;
            Address = address1;
            IsElevator = isElevator1;
            Floor = floor1;
            ExpYears = expYears1;
            MaxChilds = maxChilds1;
            MinAgeInMonth = minAgeInMonth1;
            MaxAgeInMonth = maxAgeInMonth1;
            AllowPerHour = allowPerHour1;
            RatePerHour = ratePerHour1;
            RatePerMonth = ratePerMonth1;
            WorkOnDay = workOnDay1;
            HoursOnDay = hoursOnDay1;
            FinancedVacation = financedVacation1;
            Recommendations = recommendations1;
        }

        //Properties
        public int ID
        {
            get => id;
            set
            {
                if (value > 0)
                    id = value;
                else
                    throw new Exception("ID can't be negative or zero");
            }
        }
        public string LastName { get => lastName ?? ""; set => lastName = value; }
        public string FirstName { get => firstName ?? ""; set => firstName = value; }
        public DateTime Birthdate
        {
            get => birthdate;
            set
            {
                if (value > DateTime.Today)
                    throw new Exception("Birthdate can't be in the future");
                else
                    birthdate = value;
            }
        }
        public string PhoneNumber { get => phoneNumber ?? ""; set => phoneNumber = value; }
        public string Address { get => address ?? ""; set => address = value; }
        public bool IsElevator { get => isElevator; set => isElevator = value; }
        public int Floor { get => floor; set => floor = value; }
        public int ExpYears
        {
            get => expYears;
            set
            {
                if (value < 0)
                    throw new Exception("expYears can't be negative");
                else
                    expYears = value;
            }
        }
        public int MaxChilds
        {
            get => maxChilds;
            set
            {
                if (value < 0)
                    throw new Exception("maxChilds can't be negative");
                else
                    maxChilds = value;
            }
        }
        public int MinAgeInMonth
        {
            get => minAgeInMonth;
            set
            {
                if (value >= 0)
                    minAgeInMonth = value;
                else
                    throw new Exception("minAge can't be negative");
            }
        }
        public int MaxAgeInMonth
        {
            get => maxAgeInMonth;
            set
            {
                if (value >= 0)
                    maxAgeInMonth = value;
                else
                    throw new Exception("maxAge can't be negative");
            }
        }
        public bool AllowPerHour { get => allowPerHour; set => allowPerHour = value; }
        public double RatePerHour
        {
            get => ratePerHour;
            set
            {
                if (value >= 0)
                    ratePerHour = value;
                else
                    throw new Exception("RatePerHour can't be negative");
            }
        }
        public double RatePerMonth
        {
            get => ratePerMonth;
            set
            {
                if (value >= 0)
                    ratePerMonth = value;
                else
                    throw new Exception("RatePerMonth can't be negative");
            }
        }
        public bool[] WorkOnDay { get => workOnDay; set => workOnDay = value; }
        public WorkHours[] HoursOnDay { get => hoursOnDay; set => hoursOnDay = value; }
        public bool FinancedVacation { get => financedVacation; set => financedVacation = value; }
        public string Recommendations { get => recommendations ?? ""; set => recommendations = value; }
        public string MainDetails
        {
            get => "ID: " + ID + "\n" +
                "Name: " + FirstName + " " + LastName;
        }
        public string Name
        {
            get =>FirstName + " " + LastName;
        }
        /// <summary>
        /// Converts the value of the current Nanny object to its equivalent string representation
        /// </summary>
        /// <returns>A string representation of the value of the current WorkHours object.</returns>
        public override string ToString()
        {
            string strWorksOnDays = "";
            if (WorkOnDay[0])
                strWorksOnDays += "\tSunday: " + HoursOnDay[0] + "\n";
            if (WorkOnDay[1])
                strWorksOnDays += "\tMonday: " + HoursOnDay[1] + "\n";
            if (WorkOnDay[2])
                strWorksOnDays += "\tTuesday: " + HoursOnDay[2] + "\n";
            if (WorkOnDay[3])
                strWorksOnDays += "\tWednesday: " + HoursOnDay[3] + "\n";
            if (WorkOnDay[4])
                strWorksOnDays += "\tThursday: " + HoursOnDay[4] + "\n";
            if (WorkOnDay[5])
                strWorksOnDays += "\tFriday: " + HoursOnDay[5] + "\n";

            return
                "ID: " + ID + "\n" +
                "Last name: " + LastName + "\n" +
                "First name: " + FirstName + "\n" +
                "Borthdate: " + Birthdate + "\n" +
                "Phone number: " + PhoneNumber + "\n" +
                "Address: " + Address + "\n" +
                "There " + (IsElevator ? "is" : "is not") + "elevator in the building\n" +
                "Floor: " + Floor + "\n" +
                "Experience years: " + ExpYears + "\n" +
                "Max childs: " + MaxChilds + "\n" +
                "Minimum age: " + MinAgeInMonth + "\n" +
                "Maximum age: " + MaxAgeInMonth + "\n" +
                (AllowPerHour ? "Allow" : "Doesn't allow") + " pay per hour\n" +
                "Rate per hour: " + RatePerHour + "\n" +
                "Rate per month: " + RatePerMonth + "\n" +
                "Work on days:\n" + (strWorksOnDays == "" ? "No day" : strWorksOnDays) + "\n" +
                "Vacations " + (FinancedVacation ? "is" : "isn't")
                + " based on the Ministry of Education or the Ministry of Industry, Trade and Labor" + "\n" +
                "Recommendations:\n" + (Recommendations == "" ? "Nothing" : Recommendations);
        }
    }
}

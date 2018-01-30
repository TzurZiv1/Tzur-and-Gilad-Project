using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace BE
{
    /// <summary>
    /// Represents a mother, expressed as details and information about her.
    /// </summary>
    public class Mother
    {
        private int id;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private string address;
        private string area;
        private bool[] needNannyOnDay;
        private string notes;
        private bool isPerMonth;// true = per month. false = per hour
        private WorkHours[] hoursForDay;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Mother()
        {
            NeedNannyOnDay = new bool[6];
            HoursForDay = new WorkHours[6];
            for (int i = 0; i < 6; i++)
            {
                HoursForDay[i] = new WorkHours();
            }
        }
        /// <summary>
        /// Constructor of Mother
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="firstName1"></param>
        /// <param name="lastName1"></param>
        /// <param name="address1"></param>
        /// <param name="area1"></param>
        /// <param name="needNannyOdDay1"></param>
        /// <param name="hoursForDay1"></param>
        /// <param name="isPerMonth1"></param>
        /// <param name="phoneNumber1"></param>
        /// <param name="notes1"></param>
        public Mother(int id1, string firstName1, string lastName1, string address1,
        string area1, bool[] needNannyOdDay1, WorkHours[] hoursForDay1, bool isPerMonth1,
        string phoneNumber1 = "No phone number", string notes1 = "Nothing")
        {
            ID = id1;
            FirstName = firstName1;
            LastName = lastName1;
            Address = address1;
            Area = area1;
            NeedNannyOnDay = needNannyOdDay1;
            HoursForDay = hoursForDay1;
            IsPerMonth = isPerMonth1;
            PhoneNumber = phoneNumber1;
            Notes = notes1;
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
        public string Name
        {
            get => FirstName + " " + LastName;
        }
        public string LastName { get => lastName ?? ""; set => lastName = value; }
        public string FirstName { get => firstName ?? ""; set => firstName = value; }
        public string PhoneNumber { get => phoneNumber ?? ""; set => phoneNumber = value; }
        public string Address { get => address ?? ""; set => address = value; }
        public string Area { get => area ?? ""; set => area = value; }
        [XmlIgnoreAttribute]
        public bool[] NeedNannyOnDay { get => needNannyOnDay; set => needNannyOnDay = value; }
        public string TempNeedNannyOnDay
        {
            get
            {

                string StrWorkDays = "";
                if (NeedNannyOnDay[0])
                    StrWorkDays += "Sunday|";
                if (NeedNannyOnDay[1])
                    StrWorkDays += "Monday|";
                if (NeedNannyOnDay[2])
                    StrWorkDays += "Tuesday|";
                if (NeedNannyOnDay[3])
                    StrWorkDays += "Wednesday|";
                if (NeedNannyOnDay[4])
                    StrWorkDays += "Thursday|";
                if (NeedNannyOnDay[5])
                    StrWorkDays += "Friday|";
                return StrWorkDays.Substring(0, StrWorkDays.Length);
            }
            set
            {
                for (int i = 0; i < 6; i++)
                {
                    NeedNannyOnDay[i] = false;
                }
                if (value.Contains("Sunday"))
                    NeedNannyOnDay[0] = true;
                if (value.Contains("Monday"))
                    NeedNannyOnDay[1] = true;
                if (value.Contains("Tuesday"))
                    NeedNannyOnDay[2] = true;
                if (value.Contains("Wednesday"))
                    NeedNannyOnDay[3] = true;
                if (value.Contains("Thursday"))
                    NeedNannyOnDay[4] = true;
                if (value.Contains("Friday"))
                    NeedNannyOnDay[5] = true;
            }
        }

        [XmlIgnoreAttribute]
        public WorkHours[] HoursForDay { get => hoursForDay; set => hoursForDay = value; }
        public string TempHoursForDay
        {
            get
            {
                string strWorksOnDays = "|";
                strWorksOnDays += " Sunday: " + HoursForDay[0] + " |";
                strWorksOnDays += " Monday: " + HoursForDay[1] + " |";
                strWorksOnDays += " Tuesday: " + HoursForDay[2] + " |";
                strWorksOnDays += " Wednesday: " + HoursForDay[3] + " |";
                strWorksOnDays += " Thursday: " + HoursForDay[4] + " |";
                strWorksOnDays += " Friday: " + HoursForDay[5] + " |";
                return strWorksOnDays;
            }
            set
            {
                int index = value.IndexOf("Sunday");
                int index2 = value.IndexOf("Monday");
                int index3 = value.IndexOf("Tuesday");
                int index4 = value.IndexOf("Wednesday");
                int index5 = value.IndexOf("Thursday");
                int index6 = value.IndexOf("Friday");
                int sunIndex = index + "Sunday".Length + 1;
                int monIndex = index2 + "Monday".Length + 1;
                int tuesIndex = index3 + "Tuesday".Length + 1;
                int wenIndex = index4 + "Wednesday".Length + 1;
                int thurIndex = index5 + "Thursday".Length + 1;
                int friIndex = index6 + "Friday".Length + 1;

                if (!value.Substring(sunIndex, 9).Contains("nothing"))
                {
                    hoursForDay[0].Start = TimeSpan.Parse(value.Substring(sunIndex, 9));
                    hoursForDay[0].Finish = TimeSpan.Parse(value.Substring(sunIndex + 12, 9));
                }
                else
                {
                    hoursForDay[0].Start = TimeSpan.Parse("00:00:00");
                    hoursForDay[0].Finish = TimeSpan.Parse("00:00:00");
                }
                if (!value.Substring(monIndex, 9).Contains("nothing"))
                {
                    hoursForDay[1].Start = TimeSpan.Parse(value.Substring(monIndex, 9));
                    hoursForDay[1].Finish = TimeSpan.Parse(value.Substring(monIndex + 12, 9));
                }
                else
                {
                    hoursForDay[1].Start = TimeSpan.Parse("00:00:00");
                    hoursForDay[1].Finish = TimeSpan.Parse("00:00:00");
                }
                if (!value.Substring(tuesIndex, 9).Contains("nothing"))
                {
                    hoursForDay[2].Start = TimeSpan.Parse(value.Substring(tuesIndex, 9));
                    hoursForDay[2].Finish = TimeSpan.Parse(value.Substring(tuesIndex + 12, 9));
                }
                else
                {
                    hoursForDay[2].Start = TimeSpan.Parse("00:00:00");
                    hoursForDay[2].Finish = TimeSpan.Parse("00:00:00");
                }
                if (!value.Substring(wenIndex, 9).Contains("nothing"))
                {
                    hoursForDay[3].Start = TimeSpan.Parse(value.Substring(wenIndex, 9));
                    hoursForDay[3].Finish = TimeSpan.Parse(value.Substring(wenIndex + 12, 9));
                }
                else
                {
                    hoursForDay[3].Start = TimeSpan.Parse("00:00:00");
                    hoursForDay[3].Finish = TimeSpan.Parse("00:00:00");
                }
                if (!value.Substring(thurIndex, 9).Contains("nothing"))
                {
                    hoursForDay[4].Start = TimeSpan.Parse(value.Substring(thurIndex, 9));
                    hoursForDay[4].Finish = TimeSpan.Parse(value.Substring(thurIndex + 12, 9));
                }
                else
                {
                    hoursForDay[4].Start = TimeSpan.Parse("00:00:00");
                    hoursForDay[4].Finish = TimeSpan.Parse("00:00:00");
                }
                if (!value.Substring(friIndex, 9).Contains("nothing"))
                {
                    hoursForDay[5].Start = TimeSpan.Parse(value.Substring(friIndex, 9));
                    hoursForDay[5].Finish = TimeSpan.Parse(value.Substring(friIndex + 12,9));
                }
                else
                {
                    hoursForDay[5].Start = TimeSpan.Parse("00:00:00");
                    hoursForDay[5].Finish = TimeSpan.Parse("00:00:00");
                }
            }
        }
        public string Notes { get => notes ?? ""; set => notes = value; }
        public bool IsPerMonth { get => isPerMonth; set => isPerMonth = value; }
        public string MainDetails
        {
            get => "ID: " + ID + "\n" +
                "Name: " + FirstName + " " + LastName;
        }

        /// <summary>
        /// Converts the value of the current Mother object to its equivalent string representation
        /// </summary>
        /// <returns>A string representation of the value of the current Mother object.</returns>
        public override string ToString()
        {
            string StrNeedNannyOnDays = "";
            if (NeedNannyOnDay[0])
                StrNeedNannyOnDays += "\tSunday: " + HoursForDay[0] + "\n";
            if (NeedNannyOnDay[1])
                StrNeedNannyOnDays += "\tMonday: " + HoursForDay[1] + "\n";
            if (NeedNannyOnDay[2])
                StrNeedNannyOnDays += "\tTuesday: " + HoursForDay[2] + "\n";
            if (NeedNannyOnDay[3])
                StrNeedNannyOnDays += "\tWednesday: " + HoursForDay[3] + "\n";
            if (NeedNannyOnDay[4])
                StrNeedNannyOnDays += "\tThursday: " + HoursForDay[4] + "\n";
            if (NeedNannyOnDay[5])
                StrNeedNannyOnDays += "\tFriday: " + HoursForDay[5] + "\n";

            return
                "ID: " + ID + "\n" +
                "Last name: " + LastName + "\n" +
                "First name: " + FirstName + "\n" +
                "Phone number: " + PhoneNumber + "\n" +
                "Address: " + Address + "\n" +
                "Area: " + Area + "\n" +
                "Need nanny on days:\n" + (StrNeedNannyOnDays == "" ? "No day" : StrNeedNannyOnDays) + "\n" +
                "Wants pay per " + (IsPerMonth ? "month" : "hour") + "\n" +
                "Notes:\n" + (Notes == "" ? "Nothing" : Notes);
        }
    }
}

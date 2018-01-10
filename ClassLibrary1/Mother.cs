using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private bool[] needNannyOnDay = new bool[6];
        private WorkHours[] hoursForDay = new WorkHours[6];
        private string notes;
        private bool isPerMonth;// true = per month. false = per hour

        //Properties
        public int ID
        {
            get => id;
            set
            {
                if (value > 0)
                    id = value;
                else
                    throw new Exception("ID can't be negative");
            }
        }
        public string LastName { get => lastName ?? ""; set => lastName = value; }
        public string FirstName { get => firstName ?? ""; set => firstName = value; }
        public string PhoneNumber { get => phoneNumber ?? ""; set => phoneNumber = value; }
        public string Address { get => address ?? ""; set => address = value; }
        public string Area { get => area ?? ""; set => area = value; }
        public bool[] NeedNannyOnDay { get => needNannyOnDay; set => needNannyOnDay = value; }
        public WorkHours[] HoursForDay { get => hoursForDay; set => hoursForDay = value; }
        public string Notes { get => notes ?? ""; set => notes = value; }
        public bool IsPerMonth { get => isPerMonth; set => isPerMonth = value; }

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
                "Notes:\n" + (Notes == ""? "Nothing" : Notes);
        }
    }
}

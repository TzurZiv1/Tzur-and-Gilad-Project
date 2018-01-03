using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Mother
    {
        private string id;
        private string lastName;
        private string firstName;
        private string phoneNumber;
        private string address;
        private string area;
        private bool[] needNannyOnDay = new bool[6];
        private WorkHours[] hoursForDay = new WorkHours[6];
        private string notes;
        private bool isPerMonth;// true = per month. false = per hour

        public string ID { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public string Area { get => area; set => area = value; }
        public bool[] NeedNannyOnDay { get => needNannyOnDay; set => needNannyOnDay = value; }
        public WorkHours[] HoursForDay { get => hoursForDay; set => hoursForDay = value; }
        public string Notes { get => notes; set => notes = value; }
        public bool IsPerMonth { get => isPerMonth; set => isPerMonth = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

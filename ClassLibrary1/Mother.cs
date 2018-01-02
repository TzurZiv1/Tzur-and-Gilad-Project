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
        private bool[] week = new bool[7];
        private WorkHours [] hoursForWeek = new WorkHours [6];

        public string ID { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public string Area { get => area; set => area = value; }
        public bool[] Week { get => week; set => week = value; }
        public WorkHours[] HoursForWeek { get => hoursForWeek; set => hoursForWeek = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

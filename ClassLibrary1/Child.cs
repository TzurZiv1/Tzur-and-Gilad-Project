using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        private string id;
        private string motherID;
        private string firstName;
        private DateTime birthdate;
        private bool isSpecial;
        private string specialNeeds;

        public string Id { get => id; set => id = value; }
        public string MotherID { get => motherID; set => motherID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public bool IsSpecial { get => isSpecial; set => isSpecial = value; }
        public string SpecialNeeds { get => specialNeeds; set => specialNeeds = value; }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}

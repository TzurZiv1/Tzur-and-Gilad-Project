using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    /// <summary>
    /// Represents a child, expressed as details and information about him.
    /// </summary>
    public class Child
    {
        private string id;
        private string motherID;
        private string firstName;
        private DateTime birthdate = new DateTime();
        private bool isSpecial;//the child is a special boy?
        private string specialNeeds;

        //Properties
        public string ID { get => id; set => id = value; }
        public string MotherID { get => motherID; set => motherID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public bool IsSpecial { get => isSpecial; set => isSpecial = value; }
        public string SpecialNeeds { get => specialNeeds; set => specialNeeds = value; }
        /// <summary>
        /// Converts the value of the current Child object to its equivalent string representation
        /// </summary>
        /// <returns>A string representation of the value of the current Child object.</returns>
        public override string ToString()
        {
            return
                "ID: " + ID + "\n" +
                "Mother's ID: " + MotherID + "\n" +
                "First name: " + FirstName + "\n" +
                "Birth date: " + Birthdate + "\n" +
                "Is the child Special: " + IsSpecial + "\n" +
                "Special needs: " + SpecialNeeds;
        }

    }
}

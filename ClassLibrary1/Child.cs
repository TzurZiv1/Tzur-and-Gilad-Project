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
        private int id;
        private int motherID;
        private string firstName;
        private DateTime birthdate = new DateTime();
        private bool isSpecial;//the child is a special boy?
        private string specialNeeds;

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
        public bool IsSpecial { get => isSpecial; set => isSpecial = value; }
        public string SpecialNeeds { get => specialNeeds ?? ""; set => specialNeeds = value; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Child() { }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="motherID1"></param>
        /// <param name="firstName1"></param>
        /// <param name="birthdate1"></param>
        /// <param name="isSpecial1"></param>
        /// <param name="specialNeeds1"></param>
        public Child(int id1, int motherID1, string firstName1, DateTime birthdate1,
            bool isSpecial1 = false, string specialNeeds1 = "Nothing")
        {
            ID = id1;
            MotherID = motherID1;
            FirstName = firstName1;
            Birthdate = birthdate1;
            IsSpecial = isSpecial1;
            SpecialNeeds = specialNeeds1;
        }
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
                "The child " + (IsSpecial ? "is" : "isn't") + " a special child\n" +
                "Special needs: " + (SpecialNeeds == "" ? "Nothing" : SpecialNeeds);
        }

    }
}

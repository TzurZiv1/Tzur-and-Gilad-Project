using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    public class DataSource
    {
        private static List<Nanny> nanniesList = new List<Nanny>();
        private static List<Mother> mothersList = new List<Mother>();
        private static List<Child> childsList = new List<Child>();
        private static List<Contract> contractslist = new List<Contract>();
        
        public static List<Nanny> NanniesList { get => new List<Nanny>(nanniesList); }
        public static List<Mother> MothersList { get => new List<Mother>(mothersList); }
        public static List<Child> ChildsList { get => new List<Child>(childsList); }
        public static List<Contract> ContractsList { get => new List<Contract>(contractslist); }

        /// <summary>
        /// Add n to nanniesList
        /// </summary>
        /// <param name="n">nanny</param>
        public static void AddNanny(Nanny n)
        {
            nanniesList.Add(n);
        }
        /// <summary>
        /// Remove n from nanniesList
        /// </summary>
        /// <param name="n">nanny</param>
        public static void RemoveNanny(Nanny n)
        {
            nanniesList.Remove(n);
        }
        /// <summary>
        /// Add m to mothersList
        /// </summary>
        /// <param name="m">mother</param>
        public static void AddMother(Mother m)
        {
            mothersList.Add(m);
        }
        /// <summary>
        /// Remove m grom mothersList
        /// </summary>
        /// <param name="m">mother</param>
        public static void RemoveMother(Mother m)
        {
            mothersList.Remove(m);
        }
        /// <summary>
        /// Add c to childsList
        /// </summary>
        /// <param name="c">child</param>
        public static void AddChild(Child c)
        {
            childsList.Add(c);
        }
        /// <summary>
        /// Remove c from childsList
        /// </summary>
        /// <param name="c">child</param>
        public static void RemoveChild(Child c)
        {
            childsList.Remove(c);
        }
        /// <summary>
        /// Add c to contractsList
        /// </summary>
        /// <param name="c">contract</param>
        public static void AddContract(Contract c)
        {
            contractslist.Add(c);
        }
        /// <summary>
        /// Remove c from contractsList
        /// </summary>
        /// <param name="c">contract</param>
        public static void RemoveContract(Contract c)
        {
            contractslist.Remove(c);
        }
    }
}

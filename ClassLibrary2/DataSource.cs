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

        public static List<Nanny> NanniesList { get => nanniesList; set => nanniesList = value; }
        public static List<Mother> MothersList { get => mothersList; set => mothersList = value; }
        public static List<Child> ChildsList { get => childsList; set => childsList = value; }
        public static List<Contract> Contractslist { get => contractslist; set => contractslist = value; }
    }
}

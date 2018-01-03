﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
namespace DAL
{
    public interface IDAL
    {
        void AddNanny(Nanny n);
        void RemoveNanny(Nanny n);
        void UpdateNanny(Nanny n);
        Nanny SearchNanny(string id);

        void AddMother(Mother m);
        void RemoveMother(Mother m);
        void UpdateMother(Mother m);
        Mother SearchMother(string id);

        void AddChild(Child c);
        void RemoveChild(Child c);
        void UpdateChild(Child c);
        Child SearchChild(string id);

        void AddContract(Contract c);
        void RemoveContract(Contract c);
        void UpdateContract(Contract c);
        Contract SearchContract(int num);

        List<Nanny> GetAllNannys();
        List<Mother> GetAllMothers();
        List<Child> GetAllChilds();
        List<Contract> GetAllContract();
    }
}

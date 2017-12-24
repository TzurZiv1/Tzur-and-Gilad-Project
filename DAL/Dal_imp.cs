using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    class Dal_imp : DataSource , IDAL
    {
        void AddNanny(Nanny nannyToAdd)
        {
            if (SearchNanny(nannyToAdd)== false)
                nannysList.Add(nannyToAdd);
            
        }
        void ReamoveNanny(Nanny nannyToRemove)
        {
            if (SearchNanny(nannyToRemove) == true)
                nannysList.Remove(nannyToRemove);
        }
        void Updating(Nanny nunnyToUpdate);
        bool SearchNanny(Nanny nunnyToSearch)
        {
            nannysList.Sort();
            if (nannysList.BinarySearch(nunnyToSearch) < 0)
                return false;
            return true;
        }

        void AddMother(Mother motherToAdd);
        void ReamoveMother(Mother motherToRemove);
        void UpdatingMother(Mother motherToUpdate);
        bool searchMother(Mother motherTosearch);

        void AddChild(Child childToAdd);
        void ReamoveChild(Child childToRemove);
        void UpdatingChild(Child childToUpdate);
        bool searchChild(Child childToSearch);

        void AddContract(Contract contractToAdd);
        void ReamoveContract(Contract contractToRemove);
        void UpdatingContract(Contract contractToUpdate);
        bool searchContract(Contract contractToSearch);

        List<Nanny> GetAllNannys()
        {
            return nannysList;
        }
        List<Mother> GetAllMothers()
        {
            return mothersList;
        }
        List<Child> GetAllChilds()
        {
            return childsList;
        }
        List<Contract> GetAllContract()
        {
            return contractslist;
        }
    }
}

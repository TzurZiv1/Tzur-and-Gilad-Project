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
        void ReamoveNanny(Nanny nunnyToRemove);
        void Updating(Nanny nunnyToUpdate);
        bool SearchNanny(Nanny nunnyToSearch);

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

        void GetAllNannys();
        void GetAllMothers();
        void GetAllChilds();
        void GetAllContract();
    }
}

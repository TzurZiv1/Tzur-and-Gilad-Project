using System;
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
        void ReamoveNanny(Nanny n);
        void Updating(Nanny n);
        bool SearchNanny(Nanny n);

        void AddMother(Mother m);
        void ReamoveMother(Mother m);
        void UpdatingMother(Mother m);
        bool searchMother(Mother m);

        void AddChild(Child c);
        void ReamoveChild(Child c);
        void UpdatingChild(Child c);
        bool searchChild(Child c);

        void AddContract(Contract c);
        void ReamoveContract(Contract c);
        void UpdatingContract(Contract c);
        bool searchContract(Contract c);

        void GetAllNannys();
        void GetAllMothers();
        void GetAllChilds();
        void GetAllContract();
    }
}

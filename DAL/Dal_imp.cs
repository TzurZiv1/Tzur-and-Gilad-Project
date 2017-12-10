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
        void AddNanny(Nanny nunnyToAdd)
        {
            if (nunnyToAdd.)
            nannysList.Add(nunnyToAdd);
        }
        void ReamoveNanny();
        void Updating();

        void AddMother();
        void ReamoveMother();
        void UpdatingMother();

        void AddChild();
        void ReamoveChild();
        void UpdatingChild();

        void AddContract();
        void ReamoveContract();
        void UpdatingContract();

        void GetAllNannys();
        void GetAllMothers();
        void GetAllChilds();
        void GetAllContract();
    }
}

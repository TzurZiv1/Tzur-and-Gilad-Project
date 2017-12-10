using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Dal_imp : IDAL
    {
        void AddNanny() { }
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

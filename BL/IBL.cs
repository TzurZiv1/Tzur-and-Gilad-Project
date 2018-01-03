using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IBL
    {
        void AddNanny(BE.Nanny n);
        void RemoveNanny(BE.Nanny n);
        void UpdateNanny(BE.Nanny n);
        BE.Nanny SearchNanny(string id);

        void AddMother(BE.Mother m);
        void RemoveMother(BE.Mother m);
        void UpdateMother(BE.Mother m);
        BE.Mother SearchMother(string id);

        void AddChild(BE.Child c);
        void RemoveChild(BE.Child c);
        void UpdateChild(BE.Child c);
        BE.Child SearchChild(string id);

        void AddContract(BE.Contract c);
        void RemoveContract(BE.Contract c);
        void UpdateContract(BE.Contract c);
        BE.Contract SearchContract(int num);

        List<BE.Nanny> GetAllNannys();
        List<BE.Mother> GetAllMothers();
        List<BE.Child> GetAllChilds();
        List<BE.Contract> GetAllContract();
    }
}

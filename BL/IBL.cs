using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public interface IBL
    {
        void AddNanny(Nanny n);
        void RemoveNanny(Nanny n);
        void UpdateNanny(Nanny n);
        Nanny GetNanny(string id);

        void AddMother(Mother m);
        void RemoveMother(Mother m);
        void UpdateMother(Mother m);
        Mother GetMother(string id);

        void AddChild(Child c);
        void RemoveChild(Child c);
        void UpdateChild(Child c);
        Child GetChild(string id);

        void AddContract(Contract c);
        void RemoveContract(Contract c);
        void UpdateContract(Contract c);
        Contract GetContract(int num);

        List<Nanny> GetAllNannies();
        List<Mother> GetAllMothers();
        List<Child> GetAllChilds();
        List<Contract> GetAllContracts();

        List<Nanny> DistanseFromMotherInKM(Mother m, int desirableDistanceInKM);
        List<Nanny> CompletelyMatchNannies(Mother m);
        List<Nanny> MatchNannies(Mother m);
        List<Child> ChildsWithoutNanny();
        List<Nanny> AllFinancedVacation();
        List<Contract> GetContractsByTerm(Predicate<Contract> cond);
        int NumOfContractsByTerm(Predicate<Contract> cond);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
/// <summary>
/// BL layer
/// </summary>
namespace BL
{
    /// <summary>
    /// Interface for the BL layer
    /// </summary>
    public interface IBL
    {
        #region NANNY
        /// <summary>
        /// Add a nanny to the nanny list
        /// </summary>
        /// <param name="n"> The nanny you want to add to the nanny list </param>
        void AddNanny(Nanny n);

        /// <summary>
        /// Remove a nanny from the nanny list
        /// </summary>
        /// <param name="id">The id of nanny you want to remove from the nanny list</param>
        void RemoveNanny(int id);

        /// <summary>
        /// Update a nanny who is in the list
        /// </summary>
        /// <param name="n">The nanny you want to update </param>
        void UpdateNanny(Nanny n);

        /// <summary>
        /// Return the nanny from the list who has this ID
        /// </summary>
        /// <param name="id">The ID you want to find in the nanny list</param>
        /// <returns>The nanny from the list who has this ID</returns>
        Nanny GetNanny(int id);
        #endregion

        #region MOTHER
        /// <summary>
        /// Add a mother to the mother list
        /// </summary>
        /// <param name="m">The mother you want to add to the mother list</param>
        void AddMother(Mother m);

        /// <summary>
        /// Remove a mother from the mother list
        /// </summary>
        /// <param name="id">The id of the mother you want to remove from the mother list</param>
        void RemoveMother(int id);

        /// <summary>
        /// Update a mother who is in the list
        /// </summary>
        /// <param name="n">The mother you want to update </param>
        void UpdateMother(Mother m);

        /// <summary>
        /// Return the mother from the list who has this ID
        /// </summary>
        /// <param name="id">The ID you want to find in the mother list</param>
        /// <returns>The mother from the list who has this ID</returns>
        Mother GetMother(int id);
        #endregion

        #region CHILD
        /// <summary>
        /// Add a child to the child list
        /// </summary>
        /// <param name="m">The child you want to add to the child list</param>
        void AddChild(Child c);

        /// <summary>
        /// Remove a child from the child list
        /// </summary>
        /// <param name="id">The id of the child you want to remove from the child list</param>
        void RemoveChild(int id);

        /// <summary>
        /// Update a child who is in the list
        /// </summary>
        /// <param name="n">The child you want to update </param>
        void UpdateChild(Child c);

        /// <summary>
        /// Return the child from the list who has this ID
        /// </summary>
        /// <param name="id">The ID you want to find in the child list</param>
        /// <returns>The child from the list who has this ID</returns>
        Child GetChild(int id);
        #endregion

        #region CONTRACT
        int CurrentNumber();

        /// <summary>
        /// Add a contract to the contract list
        /// </summary>
        /// <param name="m">The contract you want to add to the contract list</param>
        void AddContract(Contract c);

        /// <summary>
        /// Remove a contract from the contract list
        /// </summary>
        /// <param name="num">The number of the contract you want to remove from the contract list</param>
        void RemoveContract(int num);

        /// <summary>
        /// Update a contract who is in the list
        /// </summary>
        /// <param name="n">The contract you want to update </param>
        void UpdateContract(Contract c);

        /// <summary>
        /// Return the contract from the list who has this number
        /// </summary>
        /// <param name="id">The number you want to find in the contract list</param>
        /// <returns>The contract from the list who has this number</returns>
        Contract GetContract(int num);
        #endregion

        #region GetAll
        /// <summary>
        /// Returns the all nannys who are in the nannys list 
        /// </summary>
        /// <returns>all nannys who in the nannys list</returns>
        List<Nanny> GetAllNannies();
        /// <summary>
        /// Returns the all mothers who are in the mothers list 
        /// </summary>
        /// <returns>all mothers who in the mothers list</returns>
        List<Mother> GetAllMothers();

        /// <summary>
        /// Returns the all childs who are in the childs list 
        /// </summary>
        /// <returns>all childs who in the childs list</returns>
        List<Child> GetAllChilds();
        IEnumerable<IGrouping<int, Child>> GetAllChildsByMother();

        /// <summary>
        /// Returns the all contracts who in the contracts list 
        /// </summary>
        /// <returns>all contracts who in the contracts list</returns>
        List<Contract> GetAllContracts();
        #endregion

        int CalculateDistance(string source, string dest);
        List<Nanny> DistanseFromMotherInKM(Mother m, int desirableDistanceInKM);

        List<Nanny> CompletelyMatchNannies(Mother m);
        List<Nanny> MatchNannies(Mother m);

        List<Child> ChildsWithoutNanny();
        List<Nanny> AllFinancedVacation();

        List<Contract> GetContractsByTerm(Predicate<Contract> cond);
        List<Mother> GetMothersByTerm(Predicate<Mother> cond);
        List<Child> GetChildsByTerm(Predicate<Child> cond);
        List<Nanny> GetNanniesByTerm(Predicate<Nanny> cond);
        int NumOfContractsByTerm(Predicate<Contract> cond);

        IEnumerable<IGrouping<int, Nanny>> NanniesByChildsAge(bool byMax, bool order = false);
        IEnumerable<IGrouping<int, Nanny>> NanniesByExpYears(bool order = false);
        IEnumerable<IGrouping<int, Contract>> ContractsByDistance(bool order = false);
        IEnumerable<IGrouping<int, Contract>> GetAllContractsByNanny();
        IEnumerable<IGrouping<int, Contract>> GetAllContractsByMother();
    }
}
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
        /// <summary>
        /// returns the current number of contract
        /// </summary>
        /// <returns>the current number of contract</returns>
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
        /// <summary>
        /// Returns all childs grouped by MotherID
        /// </summary>
        /// <returns>all childs grouped by MotherID</returns>
        IEnumerable<IGrouping<int, Child>> GetAllChildsByMother();

        /// <summary>
        /// Returns the all contracts who in the contracts list 
        /// </summary>
        /// <returns>all contracts who in the contracts list</returns>
        List<Contract> GetAllContracts();
        #endregion

        #region Distance
        /// <summary>
        /// Returns the distance between source and dest
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns>The distance between source and dest</returns>
        int CalculateDistance(string source, string dest);
        /// <summary>
        /// Returns list of nannies who close to area of m
        /// </summary>
        /// <param name="m">the mother</param>
        /// <param name="desirableDistanceInKM">maximum distance from m, </param>
        /// <returns>List of nannies who close to area of m</returns>
        List<Nanny> DistanseFromMotherInKM(Mother m, int desirableDistanceInKM);
        #endregion

        #region Match nannies to mother
        /// <summary>
        /// Returns list just of nannies who can work for m at any hour needed
        /// </summary>
        /// <param name="m">mother</param>
        /// <returns>list just of nannies who can work for m at any hour needed</returns>
        List<Nanny> CompletelyMatchNannies(Mother m);
        /// <summary>
        /// Returns list of nannies who can work for m
        /// If there is no one, return the five with the best match
        /// </summary>
        /// <param name="m">The mother we want match nannies to her</param>
        /// <returns>list of nannies who can work for m
        /// If there is no one, return the five with the best match</returns>
        List<Nanny> MatchNannies(Mother m);
        #endregion

        #region Other functions
        /// <summary>
        /// Returns list of childs who haven't yet any nanny.
        /// </summary>
        /// <returns>List of childs who haven't yet any nanny.</returns>
        List<Child> ChildsWithoutNanny();
        /// <summary>
        /// Returns list of nannies with financed vacation by ministry of Industry, Trade and Labor
        /// </summary>
        /// <returns>list of nannies with financed vacation</returns>
        List<Nanny> AllFinancedVacation();
        /// <summary>
        /// Return list of contracts that match a certain condition
        /// </summary>
        /// <param name="cond">condition</param>
        /// <returns>List of contracts that match cond</returns>
        List<Contract> GetContractsByTerm(Predicate<Contract> cond);
        /// <summary>
        /// Return list of Mothers that match a certain condition
        /// </summary>
        /// <param name="cond">condition</param>
        /// <returns>List of Mothers that match cond</returns>
        List<Mother> GetMothersByTerm(Predicate<Mother> cond);
        /// <summary>
        /// Return list of Childs that match a certain condition
        /// </summary>
        /// <param name="cond">condition</param>
        /// <returns>List of Childs that match cond</returns>
        List<Child> GetChildsByTerm(Predicate<Child> cond);
        /// <summary>
        /// Return list of Nannies that match a certain condition
        /// </summary>
        /// <param name="cond">condition</param>
        /// <returns>List of Nannies that match cond</returns>
        List<Nanny> GetNanniesByTerm(Predicate<Nanny> cond);
        /// <summary>
        /// Return the number of the contracts that match a certain condition
        /// </summary>
        /// <param name="cond">condition</param>
        /// <returns>Number of the contracts that match a certain condition</returns>
        int NumOfContractsByTerm(Predicate<Contract> cond);
        /// <summary>
        /// Returns nannies grouped by age, minimum or maximum by choice
        /// </summary>
        /// <param name="byMax">true = group by max, false = group by min</param>
        /// <param name="order">true = order the nannies, false = don't order</param>
        /// <returns>nannies grouped by age</returns>
        IEnumerable<IGrouping<int, Nanny>> NanniesByChildsAge(bool byMax, bool order = false);
        /// <summary>
        /// Returns nannies grouped by ExpYears
        /// </summary>
        /// <param name="order">true = order the nannies, false = don't order</param>
        /// <returns>nannies grouped by ExpYears</returns>
        IEnumerable<IGrouping<int, Nanny>> NanniesByExpYears(bool order = false);
        /// <summary>
        /// Returns all contracts grouped by distance between mother's area and nanny's address
        /// </summary>
        /// <param name="order">true = order the contracts, false = don't order</param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, Contract>> ContractsByDistance(bool order = false);
        /// <summary>
        /// Returns all contracts grouped by nanny
        /// </summary>
        /// <param name="order">true = order the contracts, false = don't order</param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, Contract>> GetAllContractsByNanny();
        /// <summary>
        /// Returns all contracts grouped by Mother
        /// </summary>
        /// <param name="order">true = order the contracts, false = don't order</param>
        /// <returns></returns>
        IEnumerable<IGrouping<int, Contract>> GetAllContractsByMother();
        #endregion
    }
}
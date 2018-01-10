using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

/// <summary>
/// DAL layer
/// </summary>
namespace DAL
{
    /// <summary>
    /// Implementaion of the IDAL interface
    /// </summary>
    public class DAL_imp : IDAL
    {
        #region NANNY

        /// <summary>
        /// Add a nanny to the nanny list
        /// </summary>
        /// <param name="n"> The nanny you want to add to the nanny list </param>
        public void AddNanny(Nanny nannyToAdd)
        {
            if (GetNanny(nannyToAdd.ID) != null)
                throw new Exception("The nanny already exist");
            else
                GetAllNannies().Add(nannyToAdd);
        }

        /// <summary>
        /// Remove a nanny from the nanny list
        /// </summary>
        /// <param name="n">The nanny you want to remove from the nanny list</param>
        public void RemoveNanny(Nanny nannyToRemove)
        {
            if (GetNanny(nannyToRemove.ID) == null)
                throw new Exception("The nanny doesn't exist");
            else
                GetAllNannies().Remove(GetNanny(nannyToRemove.ID));
        }

        /// <summary>
        /// Update a nanny who is in the list
        /// </summary>
        /// <param name="n">The nanny you want to update </param>
        public void UpdateNanny(Nanny nannyToUpdate)
        {
            if (GetNanny(nannyToUpdate.ID) == null)
                throw new Exception("The nanny doesn't exist");
            else
            {
                GetAllNannies().Remove(GetNanny(nannyToUpdate.ID));
                GetAllNannies().Add(nannyToUpdate);
            }
        }

        /// <summary>
        /// Return the nanny from the list who has this ID
        /// </summary>
        /// <param name="id">The ID you want to find in the nanny list</param>
        /// <returns>The nanny from the list who has this ID</returns>
        public Nanny GetNanny(string id)
        {
            foreach (var nan in GetAllNannies())
            {
                if (nan.ID == id)
                    return nan;
            }
            return null;
        }
        #endregion

        #region MOTHER
        /// <summary>
        /// Add a mother to the mother list
        /// </summary>
        /// <param name="m">The mother you want to add to the mother list</param>
        public void AddMother(Mother motherToAdd)
        {
            if (GetMother(motherToAdd.ID) != null)
                throw new Exception("The mother already exist");
            else
                GetAllMothers().Add(motherToAdd);
        }

        /// <summary>
        /// Remove a mother from the mother list
        /// </summary>
        /// <param name="m">The mother you want to remove from the mother list</param>
        public void RemoveMother(Mother motherToRemove)
        {
            if (GetMother(motherToRemove.ID) == null)
                throw new Exception("The mother doesn't exist");
            else
                GetAllMothers().Remove(GetMother(motherToRemove.ID));
        }

        /// <summary>
        /// Update a mother who is in the list
        /// </summary>
        /// <param name="n">The mother you want to update </param>
        public void UpdateMother(Mother motherToUpdate)
        {

            if (GetMother(motherToUpdate.ID) == null)
                throw new Exception("The mother doesn't exist");
            else
            {
                GetAllMothers().Remove(GetMother(motherToUpdate.ID));
                GetAllMothers().Add(motherToUpdate);
            }
        }

        /// <summary>
        /// Return the mother from the list who has this ID
        /// </summary>
        /// <param name="id">The ID you want to find in the mother list</param>
        /// <returns>The mother from the list who has this ID</returns>
        public Mother GetMother(string id)
        {
            foreach (var mom in GetAllMothers())
            {
                if (mom.ID == id)
                    return mom;
            }
            return null;
        }
        #endregion

        #region CHILD

        /// <summary>
        /// Add a child to the child list
        /// </summary>
        /// <param name="m">The child you want to add to the child list</param>
        public void AddChild(Child childToAdd)
        {
            if (GetChild(childToAdd.ID) != null)
                throw new Exception("The child already exist");
            else
                GetAllChilds().Add(childToAdd);
        }

        /// <summary>
        /// Remove a child from the child list
        /// </summary>
        /// <param name="m">The child you want to remove from the child list</param>
        public void RemoveChild(Child childToRemove)
        {
            if (GetChild(childToRemove.ID) == null)
                throw new Exception("The child doesn't exist");
            else
                GetAllChilds().Remove(GetChild(childToRemove.ID));
        }

        /// <summary>
        /// Update a child who is in the list
        /// </summary>
        /// <param name="n">The child you want to update </param>
        public void UpdateChild(Child childToUpdate)
        {
            if (GetChild(childToUpdate.ID) == null)
                throw new Exception("The child doesn't exist");
            else
            {
                GetAllChilds().Remove(GetChild(childToUpdate.ID));
                GetAllChilds().Add(childToUpdate);
            }
        }

        /// <summary>
        /// Return the child from the list who has this ID
        /// </summary>
        /// <param name="id">The ID you want to find in the child list</param>
        /// <returns>The child from the list who has this ID</returns>
        public Child GetChild(string id)
        {
            foreach (var chi in GetAllChilds())
            {
                if (chi.ID == id)
                    return chi;
            }
            return null;
        }
        #endregion

        #region CONTRACT
        private static int numberOfContracts = 0;

        /// <summary>
        /// Add a contract to the contract list
        /// </summary>
        /// <param name="m">The contract you want to add to the contract list</param>
        public void AddContract(Contract contractToAdd)
        {
            if (GetChild(contractToAdd.ChildID) == null)
                throw new Exception("The child doesn't exist");
            if (GetMother(GetChild(contractToAdd.ChildID).MotherID) == null)
                throw new Exception("The mother doesn't exist");
            if (GetNanny(contractToAdd.NunnyID) == null)
                throw new Exception("The nanny doesn't exist");

            contractToAdd.Number = ++numberOfContracts;
            GetAllContracts().Add(contractToAdd);
        }

        /// <summary>
        /// Remove a contract from the child list
        /// </summary>
        /// <param name="m">The contract you want to remove from the contract list</param>
        public void RemoveContract(Contract contractToRemove)
        {
            if (GetContract(contractToRemove.Number) == null)
                throw new Exception("The contract doesn't exist");

            GetAllContracts().Remove(GetContract(contractToRemove.Number));
        }

        /// <summary>
        /// Update a contract who is in the list
        /// </summary>
        /// <param name="n">The contract you want to update </param>
        public void UpdateContract(Contract contractToUpdate)
        {
            if (GetContract(contractToUpdate.Number) == null)
                throw new Exception("The contract doesn't exist");
            if (GetChild(contractToUpdate.ChildID) == null)
                throw new Exception("The child doesn't exist");
            if (GetMother(contractToUpdate.MotherID) == null)
                throw new Exception("The mother doesn't exist");
            if (GetNanny(contractToUpdate.NunnyID) == null)
                throw new Exception("The nanny doesn't exist");

            GetAllContracts().Remove(GetContract(contractToUpdate.Number));
            GetAllContracts().Add(contractToUpdate);
        }

        /// <summary>
        /// Return the contract from the list who has this number
        /// </summary>
        /// <param name="id">The number you want to find in the contract list</param>
        /// <returns>The contract from the list who has this number</returns>
        public Contract GetContract(int num)
        {
            foreach (var con in GetAllContracts())
            {
                if (con.Number == num)
                    return con;
            }
            return null;
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Returns the all nannies who are in the nannies list 
        /// </summary>
        /// <returns>all nannies who in the nannies list</returns>
        public List<Nanny> GetAllNannies()
        {
            List<Nanny> nannies = new List<Nanny>();
            foreach (var n in DataSource.NanniesList)
                nannies.Add(n);
            return (List<Nanny>)from n in nannies
                                orderby n.ID
                                select n;
        }

        /// <summary>
        /// Returns the all mothers who are in the mothers list 
        /// </summary>
        /// <returns>all mothers who in the mothers list</returns>
        public List<Mother> GetAllMothers()
        {
            List<Mother> mothers = new List<Mother>();
            foreach (var m in DataSource.MothersList)
                mothers.Add(m);

            return (List<Mother>)from m in mothers
                                 orderby m.ID
                                 select m;
        }

        /// <summary>
        /// Returns all childs who are in the childs list 
        /// </summary>
        /// <returns>all childs who in the childs list</returns>
        public List<Child> GetAllChilds()
        {
            List<Child> childs = new List<Child>();
            foreach (var c in DataSource.ChildsList)
                childs.Add(c);

            return (List<Child>)from c in childs
                                orderby c.ID
                                select c;
        }
        /// <summary>
        /// Returns all childs grouped by mother
        /// </summary>
        /// <returns>List of all childs grouped by mother</returns>
        public IEnumerable<IGrouping<string, Child>> GetAllChildsByMother()
        {
            return from c in GetAllChilds()
                   group c by c.MotherID;
        }
        /// <summary>
        /// Returns the all contracts who in the contracts list 
        /// </summary>
        /// <returns>all contracts who in the contracts list</returns>
        public List<Contract> GetAllContracts()
        {
            List<Contract> contracts = new List<Contract>();
            foreach (var c in DataSource.Contractslist)
                contracts.Add(c);

            return (List<Contract>)from c in contracts
                                   orderby c.Number
                                   select c;
        }
        /// <summary>
        /// Returns all contracts grouped by motherID
        /// </summary>
        /// <returns>all contracts grouped by motherID</returns>
        public IEnumerable<IGrouping<string, Contract>> GetAllContractsByMother()
        {
            return from c in GetAllContracts()
                   group c by c.MotherID;
        }
        /// <summary>
        /// Returns all contracts grouped by nannyID
        /// </summary>
        /// <returns>all contracts grouped by nannyID</returns>
        public IEnumerable<IGrouping<string, Contract>> GetAllContractsByNanny()
        {
            return from c in GetAllContracts()
                   group c by c.NunnyID;
        }
        #endregion
    }
}
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
    public class FactoryDAL
    {
        static IDAL dal = null;
        public static IDAL GetDAL()
        {
            if (dal == null)
                dal = new Dal_XML_imp ();
            return dal;
        }
    }
    /// <summary>
    /// Implementaion of the IDAL interface
    /// </summary>
    public class DAL_imp : IDAL
    {
        #region NANNY

        /// <summary>
        /// Add a nanny to the nanny list
        /// </summary>
        /// <param name="nannyToAdd"> The nanny you want to add to the nanny list </param>
        public void AddNanny(Nanny nannyToAdd)
        {
            IdAlreadyExist(nannyToAdd.ID);
            DataSource.AddNanny(nannyToAdd);
        }

        /// <summary>
        /// Remove a nanny from the nanny list
        /// </summary>
        /// <param name="id">The id of the nanny you want to remove from the nanny list</param>
        public void RemoveNanny(int id)
        {
            if (GetNanny(id) == null)
                throw new Exception("The nanny doesn't exist");
            else
                DataSource.RemoveNanny(id);
        }

        /// <summary>
        /// Update a nanny who is in the list
        /// </summary>
        /// <param name="nannyToUpdate">The nanny you want to update </param>
        public void UpdateNanny(Nanny nannyToUpdate)
        {
            if (GetNanny(nannyToUpdate.ID) == null)
                throw new Exception("The nanny doesn't exist");
            else
            {
                DataSource.RemoveNanny(nannyToUpdate.ID);
                DataSource.AddNanny(nannyToUpdate);
            }
        }

        /// <summary>
        /// Return the nanny from the list who has this ID
        /// </summary>
        /// <param name="id">The ID you want to find in the nanny list</param>
        /// <returns>The nanny from the list who has this ID</returns>
        public Nanny GetNanny(int id)
        {
            foreach (var nan in GetAllNannies())
                if (nan.ID == id)
                    return nan;

            return null;
        }
        #endregion

        #region MOTHER
        /// <summary>
        /// Add a mother to the mother list
        /// </summary>
        /// <param name="motherToAdd">The mother you want to add to the mother list</param>
        public void AddMother(Mother motherToAdd)
        {
            IdAlreadyExist(motherToAdd.ID);
                DataSource.AddMother(motherToAdd);
        }

        /// <summary>
        /// Remove a mother from the mother list
        /// </summary>
        /// <param name="id">The id of the mother you want to remove from the mother list</param>
        public void RemoveMother(int id)
        {
            if (GetMother(id) == null)
                throw new Exception("The mother doesn't exist");
            else
                DataSource.RemoveMother(id);
        }

        /// <summary>
        /// Update a mother who is in the list
        /// </summary>
        /// <param name="motherToUpdate">The mother you want to update </param>
        public void UpdateMother(Mother motherToUpdate)
        {
            if (GetMother(motherToUpdate.ID) == null)
                throw new Exception("The mother doesn't exist");
            else
            {
                DataSource.RemoveMother(motherToUpdate.ID);
                DataSource.AddMother(motherToUpdate);
            }
        }

        /// <summary>
        /// Return the mother from the list who has this ID
        /// </summary>
        /// <param name="id">The ID you want to find in the mother list</param>
        /// <returns>The mother from the list who has this ID</returns>
        public Mother GetMother(int id)
        {
            foreach (var mom in GetAllMothers())
                if (mom.ID == id)
                    return mom;
            
            return null;
        }
        #endregion

        #region CHILD

        /// <summary>
        /// Add a child to the child list
        /// </summary>
        /// <param name="childToAdd">The child you want to add to the child list</param>
        public void AddChild(Child childToAdd)
        {
            IdAlreadyExist(childToAdd.ID);
                DataSource.AddChild(childToAdd);
        }

        /// <summary>
        /// Remove a child from the child list
        /// </summary>
        /// <param name="id">The id of the child you want to remove from the child list</param>
        public void RemoveChild(int id)
        {
            if (GetChild(id) == null)
                throw new Exception("The child doesn't exist");
            else
                DataSource.RemoveChild(id);
        }

        /// <summary>
        /// Update a child who is in the list
        /// </summary>
        /// <param name="childToUpdate">The child you want to update </param>
        public void UpdateChild(Child childToUpdate)
        {
            if (GetChild(childToUpdate.ID) == null)
                throw new Exception("The child doesn't exist");
            else
            {
                DataSource.RemoveChild(childToUpdate.ID);
                DataSource.AddChild(childToUpdate);
            }
        }

        /// <summary>
        /// Return the child from the list who has this ID
        /// </summary>
        /// <param name="id">The ID you want to find in the child list</param>
        /// <returns>The child from the list who has this ID</returns>
        public Child GetChild(int id)
        {
            foreach (var chi in GetAllChilds())
                if (chi.ID == id)
                    return chi;
            
            return null;
        }
        #endregion

        #region CONTRACT
        private static int currentNumber = 10000000;
        public int CurrentNumber() => currentNumber;

        /// <summary>
        /// Add a contract to the contract list
        /// </summary>
        /// <param name="contractToAdd">The contract you want to add to the contract list</param>
        public void AddContract(Contract contractToAdd)
        {
            if (GetChild(contractToAdd.ChildID) == null)
                throw new Exception("The child doesn't exist");
            if (GetMother(contractToAdd.MotherID) == null)
                throw new Exception("The mother doesn't exist");
            if (GetNanny(contractToAdd.NannyID) == null)
                throw new Exception("The nanny doesn't exist");

            if(contractToAdd.Number == 0)
                contractToAdd.Number = ++currentNumber;
            
            DataSource.AddContract(contractToAdd);
        }

        /// <summary>
        /// Remove a contract from the child list
        /// </summary>
        /// <param name="num">The number of the contract you want to remove from the contract list</param>
        public void RemoveContract(int num)
        {
            if (GetContract(num) == null)
                throw new Exception("The contract doesn't exist");

            DataSource.RemoveContract(num);
        }

        /// <summary>
        /// Update a contract who is in the list
        /// </summary>
        /// <param name="contractToUpdate">The contract you want to update </param>
        public void UpdateContract(Contract contractToUpdate)
        {
            if (GetContract(contractToUpdate.Number) == null)
                throw new Exception("The contract doesn't exist");
            if (GetChild(contractToUpdate.ChildID) == null)
                throw new Exception("The child doesn't exist");
            if (GetMother(contractToUpdate.MotherID) == null)
                throw new Exception("The mother doesn't exist");
            if (GetNanny(contractToUpdate.NannyID) == null)
                throw new Exception("The nanny doesn't exist");

            DataSource.RemoveContract(contractToUpdate.Number);
            DataSource.AddContract(contractToUpdate);
        }

        /// <summary>
        /// Return the contract from the list who has this number
        /// </summary>
        /// <param name="id">The number you want to find in the contract list</param>
        /// <returns>The contract from the list who has this number</returns>
        public Contract GetContract(int num)
        {
            foreach (var con in GetAllContracts())
                if (con.Number == num)
                    return con;
            
            return null;
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Returns the all nannies who are in the nannies list 
        /// </summary>
        /// <returns>all nannies who in the nannies list</returns>
        public List<Nanny> GetAllNannies() => (from n in DataSource.NanniesList
                                               orderby n.ID
                                               select n).ToList();
        /// <summary>
        /// Returns the all mothers who are in the mothers list 
        /// </summary>
        /// <returns>all mothers who in the mothers list</returns>
        public List<Mother> GetAllMothers() => (from m in DataSource.MothersList
                                                orderby m.ID
                                                select m).ToList();
        /// <summary>
        /// Returns all childs who are in the childs list 
        /// </summary>
        /// <returns>all childs who in the childs list</returns>
        public List<Child> GetAllChilds() => (from c in DataSource.ChildsList
                                              orderby c.ID
                                              select c).ToList();
        /// <summary>
        /// Returns all childs grouped by mother
        /// </summary>
        /// <returns>List of all childs grouped by mother</returns>
        public IEnumerable<IGrouping<int, Child>> GetAllChildsByMother() => from c in GetAllChilds()
                                                                               group c by c.MotherID;
        /// <summary>
        /// Returns the all contracts who in the contracts list 
        /// </summary>
        /// <returns>all contracts who in the contracts list</returns>
        public List<Contract> GetAllContracts() => (from c in DataSource.ContractsList
                                                    orderby c.Number
                                                    select c).ToList();
        /// <summary>
        /// Returns all contracts grouped by motherID
        /// </summary>
        /// <returns>all contracts grouped by motherID</returns>
        public IEnumerable<IGrouping<int, Contract>> GetAllContractsByMother() => from c in GetAllContracts()
                                                                                     group c by c.MotherID;
        /// <summary>
        /// Returns all contracts grouped by nannyID
        /// </summary>
        /// <returns>all contracts grouped by nannyID</returns>
        public IEnumerable<IGrouping<int, Contract>> GetAllContractsByNanny() => from c in GetAllContracts()
                                                                                    group c by c.NannyID;
        #endregion

        private void IdAlreadyExist(int id)
        {
            if (GetChild(id) != null || GetMother(id) != null || GetNanny(id) != null)
                throw new Exception("This ID already exist");
        }
    }
}
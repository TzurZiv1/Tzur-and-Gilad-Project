﻿using System;
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
    /// Interface for the DAL layer 
    /// </summary>
    public interface IDAL
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
        /// <param name="n">The nanny you want to remove from the nanny list</param>
        void RemoveNanny(Nanny n);

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
        Nanny GetNanny(string id);
        #endregion NANNY

        #region MOTHER
        /// <summary>
        /// Add a mother to the mother list
        /// </summary>
        /// <param name="m">The mother you want to add to the child list</param>
        void AddMother(Mother m);

        /// <summary>
        /// Remove a mother from the mother list
        /// </summary>
        /// <param name="m">The mother you want to remove from the mother list</param>
        void RemoveMother(Mother m);

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
        Mother GetMother(string id);
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
        /// <param name="m">The child you want to remove from the child list</param>
        void RemoveChild(Child c);

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
        Child GetChild(string id);
        #endregion

        #region
        /// <summary>
        /// Add a contract to the contract list
        /// </summary>
        /// <param name="m">The contract you want to add to the mother list</param>
        void AddContract(Contract c);

        /// <summary>
        /// Remove a contract from the child list
        /// </summary>
        /// <param name="m">The contract you want to remove from the contract list</param>
        void RemoveContract(Contract c);

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
        List<Nanny> GetAllNannys();
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
        /// Returns the all contracts who in the contracts list 
        /// </summary>
        /// <returns>all contracts who in the contracts list</returns>
        List<Contract> GetAllContracts();
        #endregion
    }
}

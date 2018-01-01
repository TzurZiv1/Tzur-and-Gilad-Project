using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
   
    internal class Dal_imp : DataSource, IDAL
    {
        Dal_imp()
        {
            nannysList = new List<Nanny>();
            childsList = new List<Child>();
            mothersList = new List<Mother>();
            contractslist = new List<Contract>();
        }
        #region NANNY
        void IDAL.AddNanny(Nanny nannyToAdd)
        {
            if (SearchNannyID(nannyToAdd) == true)
                throw new Exception("The nanny is already exist");
            nannysList.Add(nannyToAdd);
        }
        void IDAL.RemoveNanny(Nanny nannyToRemove)
        {
            if (IDAL.SearchNannyID(nannyToRemove) == false)
                throw new Exception("The nanny is not exist");
            nannysList.Remove(nannyToRemove);
            
        }
        void IDAL.Updating(Nanny nunnyToUpdate)
        {

        }
        bool IDAL.SearchNannyID(Nanny nannyToSearch)
        {
            string ID = nannyToSearch.NannyID;
            foreach (Nanny nan in nannysList)
            {
                if (nan.NannyID == nannyToSearch.NannyID)
                    return false;
            }
            return true;
        }
        List<Nanny> GetAllNannys()
        {
            return nannysList;
        }
        #endregion
        #region MOTHER
        void AddMother(Mother motherToAdd)
        {
            if (searchMother(motherToAdd) == true)
                throw new Exception("The mother is already exist");
            mothersList.Add(motherToAdd);
        }
        void ReamoveMother(Mother motherToRemove)
        {
            if (searchMother(motherToRemove) == false)
                throw new Exception("The mother is not exist");
            mothersList.Remove(motherToRemove);

        }
        void UpdatingMother(Mother motherToUpdate)
        {

        }
        bool searchMother(Mother motherTosearch)
        {
            string ID = motherTosearch.MotherID;
            foreach (Mother mom in mothersList)
            {
                if (mom.MotherID == motherTosearch.MotherID)
                    return false;
            }
            return true;
        }
        List<Mother> GetAllMothers()
        {
            return mothersList;
        }
        #endregion
        #region CHILD
        void AddChild(Child childToAdd)
        {
            if (searchChild(childToAdd) == true)
                throw new Exception("The child is already exist");
            childsList.Add(childToAdd);
        }
        void ReamoveChild(Child childToRemove)
        {
            if (searchChild(childToRemove) == false)
                throw new Exception("The child is not exist");
            childsList.Remove(childToRemove);
        }
        void UpdatingChild(Child childToUpdate);
        bool searchChild(Child childToSearch)
        {
            string ID = childToSearch.Id;
            foreach (Child ch in childsList)
            {
                if (ch.Id == childToSearch.Id)
                    return false;
            }
            return true;
        }
        List<Child> GetAllChilds()
        {
            return childsList;
        }
        #endregion
        

        // הקלאס של החוזה לא טוב
        #region CONTRACT
        void AddContract(Contract contractToAdd)
        {
            if (searchContract(contractToAdd) == true)
                throw new Exception("The contract is already exist");
            contractslist.Add(contractToAdd);

        }
        void ReamoveContract(Contract contractToRemove)
        {
            if (searchContract(contractToRemove) == false)
                throw new Exception("The contract is not exist");
            contractslist.Remove(contractToRemove);
        }
        void UpdatingContract(Contract contractToUpdate) { }
        bool searchContract(Contract contractToSearch)
        {
            return true;
        }
        List<Contract> GetAllContract()
        {
            return contractslist;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public class Dal_imp : IDAL
    {
        #region NANNY
        public void AddNanny(Nanny nannyToAdd)
        {
            if (SearchNanny(nannyToAdd) != null)
                throw new Exception("The nanny is already exist");
            else
                GetAllNannys().Add(SearchNanny(nannyToAdd));
        }
        public void RemoveNanny(Nanny nannyToRemove)
        {
            if (SearchNanny(nannyToRemove) == null)
                throw new Exception("The nanny is not exist");
            else
                GetAllNannys().Remove(SearchNanny(nannyToRemove));
        }
        public void UpdateNanny(Nanny nannyToUpdate)
        {
            if (SearchNanny(nannyToUpdate) == null)
                throw new Exception("The nanny is not exist");
            else
            {
                GetAllNannys().Remove(SearchNanny(nannyToUpdate));
                GetAllNannys().Add(nannyToUpdate);
            }
        }
        public Nanny SearchNanny(Nanny nannyToSearch)
        {
            foreach (var nan in GetAllNannys())
            {
                if (nan.ID == nannyToSearch.ID)
                    return nan;
            }
            return null;
        }
        public List<Nanny> GetAllNannys()
        {
            return DataSource.nannysList;
        }
        #endregion
        #region MOTHER
        public void AddMother(Mother motherToAdd)
        {
            if (SearchMother(motherToAdd) != null)
                throw new Exception("The mother is already exist");
            else
                GetAllMothers().Add(motherToAdd);
        }
        public void RemoveMother(Mother motherToRemove)
        {
            if (SearchMother(motherToRemove) == null)
                throw new Exception("The mother is not exist");
            else
                GetAllMothers().Remove(SearchMother(motherToRemove));
        }
        public void UpdateMother(Mother motherToUpdate)
        {

            if (SearchMother(motherToUpdate) == null)
                throw new Exception("The mother is not exist");
            else
            {
                GetAllMothers().Remove(SearchMother(motherToUpdate));
                GetAllMothers().Add(motherToUpdate);
            }
        }
        public Mother SearchMother(Mother motherToSearch)
        {
            foreach (var mom in GetAllMothers())
            {
                if (mom.ID == motherToSearch.ID)
                    return mom;
            }
            return null;
        }
        public List<Mother> GetAllMothers()
        {
            return DataSource.mothersList;
        }
        #endregion
        #region CHILD
        public void AddChild(Child childToAdd)
        {
            if (SearchChild(childToAdd) != null)
                throw new Exception("The child is already exist");
            else
                GetAllChilds().Add(childToAdd);
        }
        public void RemoveChild(Child childToRemove)
        {
            if (SearchChild(childToRemove) == null)
                throw new Exception("The child is not exist");
            else
                GetAllChilds().Remove(SearchChild(childToRemove));
        }
        public void UpdateChild(Child childToUpdate)
        {
            if (SearchChild(childToUpdate) == null)
                throw new Exception("The child is not exist");
            else
            {
                GetAllChilds().Remove(SearchChild(childToUpdate));
                GetAllChilds().Add(childToUpdate);
            }
        }
        public Child SearchChild(Child childToSearch)
        {
            foreach (var chi in GetAllChilds())
            {
                if (chi.Id == childToSearch.Id)
                    return chi;
            }
            return null;
        }
        public List<Child> GetAllChilds()
        {
            return DataSource.childsList;
        }
        #endregion
        #region CONTRACT
        public void AddContract(Contract contractToAdd)
        {
            if (SearchContract(contractToAdd) != null)
                throw new Exception("The contract is already exist");
            else
                GetAllContract().Add(contractToAdd);
        }
        public void RemoveContract(Contract contractToRemove)
        {
            if (SearchContract(contractToRemove) == null)
                throw new Exception("The contract is not exist");
            else
                GetAllContract().Remove(SearchContract(contractToRemove));
        }
        public void UpdateContract(Contract contractToUpdate)
        {
            if (SearchContract(contractToUpdate) == null)
                throw new Exception("The contract is not exist");
            else
            {
                GetAllContract().Remove(SearchContract(contractToUpdate));
                GetAllContract().Add(contractToUpdate);
            }
        }
        public Contract SearchContract(Contract contractToSearch)
        {
            foreach (var con in GetAllContract())
            {
                if (con.Number == contractToSearch.Number)
                    return con;
            }
            return null;
        }
        public List<Contract> GetAllContract()
        {
            return DataSource.contractslist;
        }
        #endregion
    }
}
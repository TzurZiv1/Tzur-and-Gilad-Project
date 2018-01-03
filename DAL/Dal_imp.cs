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
            if (SearchNanny(nannyToAdd.ID) != null)
                throw new Exception("The nanny already exist");
            else
                GetAllNannys().Add(SearchNanny(nannyToAdd.ID));
        }
        public void RemoveNanny(Nanny nannyToRemove)
        {
            if (SearchNanny(nannyToRemove.ID) == null)
                throw new Exception("The nanny doesn't exist");
            else
                GetAllNannys().Remove(SearchNanny(nannyToRemove.ID));
        }
        public void UpdateNanny(Nanny nannyToUpdate)
        {
            if (SearchNanny(nannyToUpdate.ID) == null)
                throw new Exception("The nanny doesn't exist");
            else
            {
                GetAllNannys().Remove(SearchNanny(nannyToUpdate.ID));
                GetAllNannys().Add(nannyToUpdate);
            }
        }
        public Nanny SearchNanny(string id)
        {
            foreach (var nan in GetAllNannys())
            {
                if (nan.ID == id)
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
            if (SearchMother(motherToAdd.ID) != null)
                throw new Exception("The mother already exist");
            else
                GetAllMothers().Add(motherToAdd);
        }
        public void RemoveMother(Mother motherToRemove)
        {
            if (SearchMother(motherToRemove.ID) == null)
                throw new Exception("The mother doesn't exist");
            else
                GetAllMothers().Remove(SearchMother(motherToRemove.ID));
        }
        public void UpdateMother(Mother motherToUpdate)
        {

            if (SearchMother(motherToUpdate.ID) == null)
                throw new Exception("The mother doesn't exist");
            else
            {
                GetAllMothers().Remove(SearchMother(motherToUpdate.ID));
                GetAllMothers().Add(motherToUpdate);
            }
        }
        public Mother SearchMother(string id)
        {
            foreach (var mom in GetAllMothers())
            {
                if (mom.ID == id)
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
            if (SearchChild(childToAdd.ID) != null)
                throw new Exception("The child already exist");
            else
                GetAllChilds().Add(childToAdd);
        }
        public void RemoveChild(Child childToRemove)
        {
            if (SearchChild(childToRemove.ID) == null)
                throw new Exception("The child doesn't exist");
            else
                GetAllChilds().Remove(SearchChild(childToRemove.ID));
        }
        public void UpdateChild(Child childToUpdate)
        {
            if (SearchChild(childToUpdate.ID) == null)
                throw new Exception("The child doesn't exist");
            else
            {
                GetAllChilds().Remove(SearchChild(childToUpdate.ID));
                GetAllChilds().Add(childToUpdate);
            }
        }
        public Child SearchChild(string id)
        {
            foreach (var chi in GetAllChilds())
            {
                if (chi.ID == id)
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
        private static int numberOfContracts = 0;
        public void AddContract(Contract contractToAdd)
        {
            if (SearchChild(contractToAdd.ChildID) == null)
                throw new Exception("The child doesn't exist");
            if (SearchMother(SearchChild(contractToAdd.ChildID).MotherID) == null)
                throw new Exception("The mother doesn't exist");
            if (SearchNanny(contractToAdd.NunnyID) == null)
                throw new Exception("The nanny doesn't exist");

            contractToAdd.Number = ++numberOfContracts;
            GetAllContract().Add(contractToAdd);
        }
        public void RemoveContract(Contract contractToRemove)
        {
            if (SearchContract(contractToRemove.Number) == null)
                throw new Exception("The contract doesn't exist");

            GetAllContract().Remove(SearchContract(contractToRemove.Number));
        }
        public void UpdateContract(Contract contractToUpdate)
        {
            if (SearchContract(contractToUpdate.Number) == null)
                throw new Exception("The contract doesn't exist");
            if (SearchChild(contractToUpdate.ChildID) == null)
                throw new Exception("The child doesn't exist");
            if (SearchMother(SearchChild(contractToUpdate.ChildID).MotherID) == null)
                throw new Exception("The mother doesn't exist");
            if (SearchNanny(contractToUpdate.NunnyID) == null)
                throw new Exception("The nanny doesn't exist");

            GetAllContract().Remove(SearchContract(contractToUpdate.Number));
            GetAllContract().Add(contractToUpdate);
        }
        public Contract SearchContract(int num)
        {
            foreach (var con in GetAllContract())
            {
                if (con.Number == num)
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
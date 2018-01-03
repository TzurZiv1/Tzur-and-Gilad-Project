using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{
    public class DAL_imp : IDAL
    {
        #region NANNY
        public void AddNanny(Nanny nannyToAdd)
        {
            if (GetNanny(nannyToAdd.ID) != null)
                throw new Exception("The nanny already exist");
            else
                GetAllNannys().Add(nannyToAdd);
        }
        public void RemoveNanny(Nanny nannyToRemove)
        {
            if (GetNanny(nannyToRemove.ID) == null)
                throw new Exception("The nanny doesn't exist");
            else
                GetAllNannys().Remove(GetNanny(nannyToRemove.ID));
        }
        public void UpdateNanny(Nanny nannyToUpdate)
        {
            if (GetNanny(nannyToUpdate.ID) == null)
                throw new Exception("The nanny doesn't exist");
            else
            {
                GetAllNannys().Remove(GetNanny(nannyToUpdate.ID));
                GetAllNannys().Add(nannyToUpdate);
            }
        }
        public Nanny GetNanny(string id)
        {
            foreach (var nan in GetAllNannys())
            {
                if (nan.ID == id)
                    return nan;
            }
            return null;
        }
        #endregion
        #region MOTHER
        public void AddMother(Mother motherToAdd)
        {
            if (GetMother(motherToAdd.ID) != null)
                throw new Exception("The mother already exist");
            else
                GetAllMothers().Add(motherToAdd);
        }
        public void RemoveMother(Mother motherToRemove)
        {
            if (GetMother(motherToRemove.ID) == null)
                throw new Exception("The mother doesn't exist");
            else
                GetAllMothers().Remove(GetMother(motherToRemove.ID));
        }
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
        public void AddChild(Child childToAdd)
        {
            if (GetChild(childToAdd.ID) != null)
                throw new Exception("The child already exist");
            else
                GetAllChilds().Add(childToAdd);
        }
        public void RemoveChild(Child childToRemove)
        {
            if (GetChild(childToRemove.ID) == null)
                throw new Exception("The child doesn't exist");
            else
                GetAllChilds().Remove(GetChild(childToRemove.ID));
        }
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
        public void RemoveContract(Contract contractToRemove)
        {
            if (GetContract(contractToRemove.Number) == null)
                throw new Exception("The contract doesn't exist");

            GetAllContracts().Remove(GetContract(contractToRemove.Number));
        }
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
        public List<Nanny> GetAllNannys()
        {
            return DataSource.nannysList;
        }
        public List<Mother> GetAllMothers()
        {
            return DataSource.mothersList;
        }
        public List<Child> GetAllChilds()
        {
            return DataSource.childsList;
        }
        public List<Contract> GetAllContracts()
        {
            return DataSource.contractslist;
        }
        #endregion
    }
}
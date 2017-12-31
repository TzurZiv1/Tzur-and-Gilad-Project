﻿using System;
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

        void RemoveNanny(Nanny nannyToRemove)
        {
            if (SearchNannyID(nannyToRemove) == false)
                throw new Exception("The nanny is not exist");
            nannysList.Remove(nannyToRemove);

        }
        void Updating(Nanny nunnyToUpdate)
        {

        }
        bool SearchNannyID(Nanny nannyToSearch)
        {
            string ID = nannyToSearch.NannyID;
            foreach (Nanny nan in nannysList)
            {
                if (nan.NannyID == nannyToSearch.NannyID)
                    return false;
            }
            return true;
        }
        List<Nanny> IDAL.GetAllNannys()
        {
            return nannysList;
        }
        #endregion
        #region MOTHER
        void IDAL.AddMother(Mother motherToAdd)
        {
            if (searchMother(motherToAdd) == true)
                throw new Exception("The mother is already exist");
            mothersList.Add(motherToAdd);
        }
        void ReamoveMother(Mother motherToRemove);
        void UpdatingMother(Mother motherToUpdate);
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
        List<Mother> IDAL.GetAllMothers()
        {
            return mothersList;
        }
        #endregion
        #region CHILD
        void IDAL.AddChild(Child childToAdd);
        void IDAL.ReamoveChild(Child childToRemove);
        void IDAL.UpdatingChild(Child childToUpdate);
        bool IDAL.searchChild(Child childToSearch);
        List<Child> IDAL.GetAllChilds()
        {
            return childsList;
        }
        #endregion
        #region CONTRACT
        void IDAL.AddContract(Contract contractToAdd);
        void IDAL.ReamoveContract(Contract contractToRemove);
        void IDAL.UpdatingContract(Contract contractToUpdate);
        bool searchContract(Contract contractToSearch);
        List<Contract> IDAL.GetAllContract()
        {
            return contractslist;
        }
        #endregion
    }
}

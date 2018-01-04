using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public class BL_imp : IBL
    {
        DAL.IDAL dal = new DAL.DAL_imp();

        public void init()
        {
            AddChild(new BE.Child
            {
                // צריך לשים פה פרטים לילד
            });
            AddNanny(new BE.Nanny
            {
                // צריך לשים פה פרטים למטפלת
            });
            AddMother(new BE.Mother
            {
                // צריך לשים פה פרטים לאמא
            });
            AddContract(new BE.Contract
            {
                // צריך לשים פה פרטים לחוזה העסקה
            });
            // אפשר להוסיף עוד ילדים, אמהות ומטפלות
        }

        List<BE.Nanny> ProperNannys (Mother mother)
        {
            
        }
        
        #region Nanny
        public void AddNanny(Nanny n)
        {
            if (DateTime.Today < n.BorthDate.AddYears(18))
                throw new Exception("A nanny must be age 18 and over");
            dal.AddNanny(n);
        }
        public void RemoveNanny(Nanny n)
        {
            dal.RemoveNanny(n);
        }
        public void UpdateNanny(Nanny n)
        {
            if (DateTime.Today < n.BorthDate.AddYears(18))
                throw new Exception("A nanny must be age 18 and over");
            dal.UpdateNanny(n);
        }
        public Nanny GetNanny(string id)
        {
            return dal.GetNanny(id);
        }
        #endregion

        #region Mother
        public void AddMother(Mother m)
        {
            dal.AddMother(m);
        }
        public void RemoveMother(Mother m)
        {
            dal.RemoveMother(m);
        }
        public void UpdateMother(Mother m)
        {
            dal.UpdateMother(m);
        }
        public Mother GetMother(string id)
        {
            return dal.GetMother(id);
        }
        #endregion

        #region Child
        public void AddChild(Child c)
        {
            dal.AddChild(c);
        }
        public void RemoveChild(Child c)
        {
            dal.RemoveChild(c);
        }
        public void UpdateChild(Child c)
        {
            dal.UpdateChild(c);
        }
        public Child GetChild(string id)
        {
            return dal.GetChild(id);
        }
        #endregion

        #region Contract
        public void AddContract(Contract c)
        {
            if (DateTime.Today < GetChild(c.ChildID).Birthdate.AddMonths(3))
                throw new Exception("The kid is younger than 3 monthes");
            //per month
            if(GetMother(c.MotherID).IsPerMonth)
            {
                double wage = double.MaxValue;
                c.IsPerMonth = true;
                foreach(var contract in GetAllContracts())
                {
                    if (contract.NunnyID == c.NunnyID && contract.MotherID == c.MotherID)
                        wage = Math.Min(wage, contract.WagePerMonth * 0.98);
                }

                c.WagePerMonth =  Math.Min(GetNanny(c.NunnyID).RatePerMonth, wage);
            }
            else//per hour
            {
                int hoursPerWeek = 0;
                for (int i = 0; i < 6; i++)
                {
                    if(GetMother(c.MotherID).NeedNannyOnDay[i])
                        hoursPerWeek += GetMother(c.MotherID).HoursForDay[i].Finish 
                            - GetMother(c.MotherID).HoursForDay[i].Start;
                }
                double wage = 4 * hoursPerWeek;

                foreach (var contract in GetAllContracts())
                {
                    if (contract.NunnyID == c.NunnyID && contract.MotherID == c.MotherID)
                        wage = Math.Min(wage, contract.WagePerMonth * 0.98);
                }

                c.WagePerMonth = wage;
            }
            //Checks if there is a place for another child to this nanny
            int numChildsToNanny = 0;
            foreach (var contract in GetAllContracts())
            {
                if (contract.NunnyID == c.NunnyID && contract.WasSignature)
                    numChildsToNanny++;
            }
            if (numChildsToNanny < GetNanny(c.NunnyID).MaxChilds)
                c.WasSignature = true;
            else
                c.WasSignature = false;

            dal.AddContract(c);
        }
        public void RemoveContract(Contract c)
        {
            dal.RemoveContract(c);
        }
        public void UpdateContract(Contract c)
        {
            dal.UpdateContract(c);
        }
        public Contract GetContract(int num)
        {
            return dal.GetContract(num);
        }
        #endregion

        #region GetAll
        public List<BE.Nanny> GetAllNannys()
        {
            return dal.GetAllNannys();
        }
        public List<BE.Mother> GetAllMothers()
        {
            return dal.GetAllMothers();
        }
        public List<BE.Child> GetAllChilds()
        {
            return dal.GetAllChilds();
        }
        public List<BE.Contract> GetAllContracts()
        {
            return dal.GetAllContracts();
        }
        #endregion
    }
}
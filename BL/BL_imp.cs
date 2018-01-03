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

        void init()
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
        #region Nanny
        void AddNanny(Nanny n)
        {
            if (DateTime.Today < n.BorthDate.AddYears(18))
                throw new Exception("A nanny must be age 18 and over");
            dal.AddNanny(n);
        }
        void RemoveNanny(Nanny n)
        {
            dal.RemoveNanny(n);
        }
        void UpdateNanny(Nanny n)
        {
            if (DateTime.Today < n.BorthDate.AddYears(18))
                throw new Exception("A nanny must be age 18 and over");
            dal.UpdateNanny(n);
        }
        Nanny GetNanny(string id)
        {
            return dal.GetNanny(id);
        }
        #endregion
        #region Mother
        void AddMother(Mother m)
        {
            dal.AddMother(m);
        }
        void RemoveMother(Mother m)
        {
            dal.RemoveMother(m);
        }
        void UpdateMother(Mother m)
        {
            dal.UpdateMother(m);
        }
        Mother GetMother(string id)
        {
            return dal.GetMother(id);
        }
        #endregion
        #region Child
        void AddChild(Child c)
        {
            dal.AddChild(c);
        }
        void RemoveChild(Child c)
        {
            dal.RemoveChild(c);
        }
        void UpdateChild(Child c)
        {
            dal.UpdateChild(c);
        }
        Child GetChild(string id)
        {
            return dal.GetChild(id);
        }
        #endregion
        #region Contract
        void AddContract(Contract c)
        {
            if (DateTime.Today < GetChild(c.ChildID).Birthdate.AddMonths(3))
                throw new Exception("The kid is younger than 3 monthes");

            if(GetMother(GetChild(c.ChildID).MotherID).PerMonth)
            {

            }
            else
            {

            }
        }
        void RemoveContract(Contract c);
        void UpdateContract(Contract c);
        Contract GetContract(int num);
        #endregion
        #region GetAll
        List<BE.Nanny> GetAllNannys();
        List<BE.Mother> GetAllMothers();
        List<BE.Child> GetAllChilds();
        List<BE.Contract> GetAllContracts();
        #endregion
    }
}

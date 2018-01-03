using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    internal class BL_imp : IBL
    {
        DAL.IDAL dal;
        public BL_imp()
        {
            dal = DAL.FactoryDal.GetDal();
            init();
        }

        void init()
        {
            this.AddChild(new BE.Child
            {
                // צריך לשים פה פרטים לילד
            });
            this.AddNanny(new BE.Nanny
            {
                // צריך לשים פה פרטים למטפלת
            });
            this.AddMother(new BE.Mother
            {
                // צריך לשים פה פרטים לאמא
            });
            this.AddContract(new BE.Contract
            {
                // צריך לשים פה פרטים לחוזה העסקה
            });
            // אפשר להוסיף עוד ילדים, אמהות ומטפלות
        }
        #region Nanny
        void AddNanny(BE.Nanny n)
        {
            if (DateTime.Today < n.BorthDate.AddYears(18))
                throw new Exception("The nanny is younger than 18 years old");
            
        }
        void RemoveNanny(BE.Nanny n);
        void UpdateNanny(BE.Nanny n);
        BE.Nanny SearchNanny(string id);
        #endregion
        #region Mother
        void AddMother(BE.Mother m);
        void RemoveMother(BE.Mother m);
        void UpdateMother(BE.Mother m);
        BE.Mother SearchMother(string id);
        #endregion
        #region Child
        void AddChild(BE.Child c);
        void RemoveChild(BE.Child c);
        void UpdateChild(BE.Child c);
        BE.Child SearchChild(string id);
        #endregion
        #region Contract
        void AddContract(BE.Contract c);
        void RemoveContract(BE.Contract c);
        void UpdateContract(BE.Contract c);
        BE.Contract SearchContract(int num);
        #endregion
        #region GetAll
        List<BE.Nanny> GetAllNannys();
        List<BE.Mother> GetAllMothers();
        List<BE.Child> GetAllChilds();
        List<BE.Contract> GetAllContract();
        #endregion
    }
}

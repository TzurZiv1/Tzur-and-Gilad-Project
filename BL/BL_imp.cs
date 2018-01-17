﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using GoogleMapsApi;
using GoogleMapsApi.Entities.Directions.Request;
using GoogleMapsApi.Entities.Directions.Response;

namespace BL
{
    public class FactoryBL
    {
        static IBL bl = null;
        public static IBL GetBL()
        {
            if (bl == null)
                bl = new BL_imp();
            return bl;
        }
    }
    public class BL_imp : IBL
    {
        DAL.IDAL dal = new DAL.DAL_imp();

        /*
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

    }*/

        #region Nanny
        public void AddNanny(Nanny n)
        {
            if (DateTime.Today < n.Birthdate.AddYears(18))
                throw new Exception("A nanny must be age 18 and over");
            dal.AddNanny(n);
        }
        public void RemoveNanny(Nanny n)
        {
            foreach (var c in GetContractsByTerm(c => c.NunnyID == n.ID))
                RemoveContract(c);

            dal.RemoveNanny(n);
        }
        public void UpdateNanny(Nanny n)
        {
            if (DateTime.Today < n.Birthdate.AddYears(18))
                throw new Exception("A nanny must be age 18 and over");
            dal.UpdateNanny(n);

            foreach (var c in GetContractsByTerm(c => c.NunnyID == n.ID))
            {
                Mother m = GetMother(c.MotherID);
                RemoveContract(c);
                if (NannyToMother(m, n))
                    AddContract(c);
            }
        }
        public Nanny GetNanny(int id)
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
            foreach (var c in GetContractsByTerm(c => c.MotherID == m.ID))
                RemoveContract(c);

            foreach (var c in GetChildsByTerm(c => c.MotherID == m.ID))
                RemoveChild(c);

            dal.RemoveMother(m);
        }
        public void UpdateMother(Mother m)
        {
            dal.UpdateMother(m);
            foreach (var c in GetAllContracts())
            {
                if (c.MotherID == m.ID)
                {
                    Nanny n = GetNanny(c.NunnyID);
                    RemoveContract(c);
                    if (NannyToMother(m, n))
                        AddContract(c);
                }
            }
        }
        public Mother GetMother(int id)
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
            foreach (var con in GetContractsByTerm(con => c.ID == con.ChildID))
                RemoveContract(con);

            dal.RemoveChild(c);
        }
        public void UpdateChild(Child c)
        {
            dal.UpdateChild(c);
        }
        public Child GetChild(int id)
        {
            return dal.GetChild(id);
        }
        #endregion

        #region Contract
        public void AddContract(Contract c)
        {
            if (DateTime.Today < GetChild(c.ChildID).Birthdate.AddMonths(3))
                throw new Exception("The kid is younger than 3 monthes");

            //Checks if there is a place for another child to this nanny
            int numChildsToNanny = 0;
            foreach (var con in GetContractsByTerm(con => con.NunnyID == c.NunnyID && con.WasSignature))
                numChildsToNanny++;

            if (numChildsToNanny < GetNanny(c.NunnyID).MaxChilds)
                c.WasSignature = true;
            else
                c.WasSignature = false;

            dal.AddContract(c);
            RepairWageForMotherAndNanny(GetMother(c.MotherID), GetNanny(c.NunnyID));
        }
        public void RemoveContract(Contract c)
        {
            dal.RemoveContract(c);
            RepairWageForMotherAndNanny(GetMother(c.MotherID), GetNanny(c.NunnyID));
        }
        public void UpdateContract(Contract c)
        {
            dal.UpdateContract(c);
            RepairWageForMotherAndNanny(GetMother(c.MotherID), GetNanny(c.NunnyID));
        }
        public Contract GetContract(int num)
        {
            return dal.GetContract(num);
        }
        #endregion

        #region GetAll
        public List<BE.Nanny> GetAllNannies() => dal.GetAllNannies();
        public List<BE.Mother> GetAllMothers() => dal.GetAllMothers();
        public List<BE.Child> GetAllChilds() => dal.GetAllChilds();
        public IEnumerable<IGrouping<int, Child>> GetAllChildsByMother() => dal.GetAllChildsByMother();
        public List<BE.Contract> GetAllContracts() => dal.GetAllContracts();
        #endregion

        #region Distance
        /// <summary>
        /// Returns the distance between source and dest
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns>The distance between source and dest</returns>
        public int CalculateDistance(string source, string dest)
        {
            try
            {
                var drivingDirectionRequest = new DirectionsRequest
                {
                    TravelMode = TravelMode.Walking,
                    Origin = source,
                    Destination = dest,
                };
                DirectionsResponse drivingDirections = GoogleMaps.Directions.Query(drivingDirectionRequest);
                Route route = drivingDirections.Routes.First();
                Leg leg = route.Legs.First();
                return leg.Distance.Value;
            }
            catch(Exception)
            {
                return -1;
            }
        }
        /// <summary>
        /// Returns list of nannies who close to area of m
        /// </summary>
        /// <param name="m">the mother</param>
        /// <param name="desirableDistanceInKM">maximum distance from m, </param>
        /// <returns>List of nannies who close to area of m</returns>
        public List<Nanny> DistanseFromMotherInKM(Mother m, int desirableDistanceInKM)
        {
            List<Nanny> nannies = new List<Nanny>();
            string area;
            if (m.Area != null && m.Area != "")
                area = m.Area;
            else // if there is no area to mother
                area = m.Address;

            foreach (var n in GetNanniesByTerm(n => CalculateDistance(n.Address, area) <= 1000 * desirableDistanceInKM))
                nannies.Add(n);

            return nannies;
        }
        #endregion

        #region Match nannies to mother
        /// <summary>
        /// Returns list just of nannies who can work for m at any hour needed
        /// </summary>
        /// <param name="m">mother</param>
        /// <returns>list just of nannies who can work for m at any hour needed</returns>
        public List<Nanny> CompletelyMatchNannies(Mother m)
        {
            List<Nanny> nannies = new List<Nanny>();

            foreach (var n in GetNanniesByTerm(n => NannyToMother(m, n)))//if n completely match to m
                nannies.Add(n);

            return nannies;
        }
        /// <summary>
        /// Returns list of nannies who can work for m
        /// If there is no one, return the five with the best match
        /// </summary>
        /// <param name="m">The mother we want match nannies to her</param>
        /// <returns>list of nannies who can work for m
        /// If there is no one, return the five with the best match</returns>
        public List<Nanny> MatchNannies(Mother m)
        {
            List<Nanny> nannies = CompletelyMatchNannies(m);

            if (nannies.Count != 0)
                return nannies;

            //When no one completely match to m
            nannies = GetAllNannies();

            while (nannies.Count > 5)
            {
                nannies.Remove(WorstNanny(m, nannies));
            }

            return nannies;
        }
        /// <summary>
        /// Check if n can work at every hour when m needs a nanny
        /// </summary>
        /// <param name="m">mother</param>
        /// <param name="n">nanny</param>
        /// <returns>true if n can work at every hour when m needs a nanny, otherwise false</returns>
        private bool NannyToMother(Mother m, Nanny n)
        {
            for (int i = 0; i < 6; i++)
            {
                if ((m.NeedNannyOnDay[i])
                    && (!n.WorkOnDay[i]
                        || m.HoursForDay[i].Start < n.HoursOnDay[i].Start
                        || m.HoursForDay[i].Finish > n.HoursOnDay[i].Finish))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Returns the grade of n according to her match to m
        /// The grade equal to the number of hours when n can work for m
        /// </summary>
        /// <param name="m">mother</param>
        /// <param name="n">nanny</param>
        /// <returns>the grade of n according to number of hours when n can work for m </returns>
        private int GradeNannyToMother(Mother m, Nanny n)
        {
            int grade = 0;
            int start, finish;
            for (int i = 0; i < 6; i++)
            {
                if (m.NeedNannyOnDay[i] && n.WorkOnDay[i])
                {
                    start = Math.Max(m.HoursForDay[i].Start, n.HoursOnDay[i].Start);
                    finish = Math.Min(m.HoursForDay[i].Finish, n.HoursOnDay[i].Finish);
                    if (start < finish)
                        grade += finish - start;
                }
            }
            return grade;
        }
        /// <summary>
        /// Returns the least suitable Nanny to m from, 2 nunnies
        /// </summary>
        /// <param name="m">The Mother who we want to check match to her</param>
        /// <param name="n1">first nanny</param>
        /// <param name="n2">second nanny</param>
        /// <returns>The least suitable Nanny to m, from 2 nunnies</returns>
        private Nanny MinGrade(Mother m, Nanny n1, Nanny n2)
        {
            int min = Math.Min(GradeNannyToMother(m, n1), GradeNannyToMother(m, n2));
            if (min == GradeNannyToMother(m, n1))
                return n1;

            return n2;
        }
        /// <summary>
        /// Returns the least suitable Nanny to m, from list of nannies
        /// </summary>
        /// <param name="m">The Mother who we want to check match to her</param>
        /// <param name="nannies">List of The Nannies</param>
        /// <returns>The least suitable Nanny to m, from list of nannies</returns>
        private Nanny WorstNanny(Mother m, List<Nanny> nannies)
        {
            if (nannies.Count != 0)
            {
                Nanny worst = nannies[0];
                for (int i = 1; i < nannies.Count; i++)
                {
                    worst = MinGrade(m, worst, nannies[i]);
                }
                return worst;
            }
            else
                return null;
        }
        #endregion

        /// <summary>
        /// repairs the wage of every contract that is shared with m and n
        /// </summary>
        /// <param name="m">mother</param>
        /// <param name="n">nanny</param>
        private void RepairWageForMotherAndNanny(Mother m, Nanny n)
        {
            double discount = 1;
            foreach (var c in GetContractsByTerm(c => m.ID == c.MotherID && n.ID == c.NunnyID))
                discount *= 0.98;
            discount /= 0.98;
            foreach (var c in GetAllContracts())
            {
                if (m.IsPerMonth)
                {
                    c.IsPerMonth = true;
                    c.WagePerMonth = n.RatePerMonth * discount;
                }
                else
                {
                    c.IsPerMonth = false;
                    c.WagePerMonth = n.RatePerHour * GradeNannyToMother(m, n) * 4 * discount;
                }
            }
        }

        /// <summary>
        /// Returns list of childs who haven't yet any nanny.
        /// </summary>
        /// <returns>List of childs who haven't yet any nanny.</returns>
        public List<Child> ChildsWithoutNanny()
        {
            List<Child> childs = GetAllChilds();
            foreach (var con in GetAllContracts())
                childs.Remove(GetChild(con.ChildID));

            return childs;
        }
        /// <summary>
        /// Returns list of nannies with financed vacation by ministry of Industry, Trade and Labor
        /// </summary>
        /// <returns>list of nannies with financed vacation</returns>
        public List<Nanny> AllFinancedVacation() => GetNanniesByTerm(n => n.FinancedVacation);

        /// <summary>
        /// Return list of Mothers that match a certain condition
        /// </summary>
        /// <param name="cond">condition</param>
        /// <returns>List of Mothers that match cond</returns>
        public List<Mother> GetMothersByTerm(Predicate<Mother> cond) => GetAllMothers().FindAll(cond);
        /// <summary>
        /// Return list of Childs that match a certain condition
        /// </summary>
        /// <param name="cond">condition</param>
        /// <returns>List of Childs that match cond</returns>
        public List<Child> GetChildsByTerm(Predicate<Child> cond) => GetAllChilds().FindAll(cond);
        /// <summary>
        /// Return list of Nannies that match a certain condition
        /// </summary>
        /// <param name="cond">condition</param>
        /// <returns>List of Nannies that match cond</returns>
        public List<Nanny> GetNanniesByTerm(Predicate<Nanny> cond) => GetAllNannies().FindAll(cond);
        /// <summary>
        /// Return list of contracts that match a certain condition
        /// </summary>
        /// <param name="cond">condition</param>
        /// <returns>List of contracts that match cond</returns>
        public List<Contract> GetContractsByTerm(Predicate<Contract> cond) => GetAllContracts().FindAll(cond);
        /// <summary>
        /// Return the number of the contracts that match a certain condition
        /// </summary>
        /// <param name="cond">condition</param>
        /// <returns>Number of the contracts that match a certain condition</returns>
        public int NumOfContractsByTerm(Predicate<Contract> cond) => GetContractsByTerm(cond).Count;

        /// <summary>
        /// Returns nannies grouped by age, minimum or maximum by choice
        /// </summary>
        /// <param name="byMax">true = group by max, false = group by min</param>
        /// <param name="order">true = order the nannies, false = don't order</param>
        /// <returns>nannies grouped by age</returns>
        public IEnumerable<IGrouping<int, Nanny>> NanniesByChildsAge(bool byMax, bool order = false)
        {
            if (byMax)//group by max age
            {
                if (order)//order nannies by name
                    return from n in GetAllNannies()
                           orderby n.ID
                           group n by n.MaxAgeInMonth / 3;
                //Don't order nannies
                return from n in GetAllNannies()
                       group n by n.MaxAgeInMonth / 3;
            }
            //group by min age
            if (order)//order nannies by name
                return from n in GetAllNannies()
                       orderby n.FirstName, n.LastName
                       group n by n.MinAgeInMonth / 3;
            //Don't order nannies
            return from n in GetAllNannies()
                   group n by n.MinAgeInMonth / 3;
        }
        /// <summary>
        /// Returns nannies grouped by ExpYears
        /// </summary>
        /// <param name="order">true = order the nannies, false = don't order</param>
        /// <returns>nannies grouped by ExpYears</returns>
        public IEnumerable<IGrouping<int, Nanny>> NanniesByExpYears(bool order = false)
        {
            if (order)//order nannies by name
                return from n in GetAllNannies()
                       orderby n.FirstName, n.LastName
                       group n by n.ExpYears;
            //Don't order nannies
            return from n in GetAllNannies()
                   group n by n.ExpYears;
            
        }

        /// <summary>
        /// Returns all contracts grouped by distance between mother's area and nanny's address
        /// </summary>
        /// <param name="order">true = order the contracts, false = don't order</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, Contract>> ContractsByDistance(bool order = false)
        {
            if (order)//order contracts by number
                return from c in GetAllContracts()
                       orderby c.Number
                       let tempArea = GetMother(c.MotherID).Area
                       let area = (tempArea != null && tempArea != "") ? tempArea : GetMother(c.MotherID).Address
                       group c by (CalculateDistance(area, GetNanny(c.NunnyID).Address) / 5000);
            //Don't order contracts
            return from c in GetAllContracts()
                   let tempArea = GetMother(c.MotherID).Area
                   let area = (tempArea != null && tempArea != "") ? tempArea : GetMother(c.MotherID).Address
                   group c by (CalculateDistance(area, GetNanny(c.NunnyID).Address) / 5000);
        }
        /// <summary>
        /// Returns all contracts grouped by nanny
        /// </summary>
        /// <param name="order">true = order the contracts, false = don't order</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, Contract>> GetAllContractsByNanny() => dal.GetAllContractsByNanny();
        /// <summary>
        /// Returns all contracts grouped by Mother
        /// </summary>
        /// <param name="order">true = order the contracts, false = don't order</param>
        /// <returns></returns>
        public IEnumerable<IGrouping<int, Contract>> GetAllContractsByMother() => dal.GetAllContractsByMother();
    }
}
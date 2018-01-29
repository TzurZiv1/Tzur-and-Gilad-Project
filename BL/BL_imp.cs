using System;
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
        DAL.IDAL dal;
        public BL_imp()
        {
            dal = DAL.FactoryDAL.GetDAL();
            Init();
        }

        public void Init()
        {
			WorkHours z = new WorkHours(TimeSpan.Zero, TimeSpan.Zero);
            AddNanny(new Nanny(123451234, "Mor", "Cohen", new DateTime(1994, 12, 2), "Jerusalem, Israel", 8, 24, 100, new bool[] { true, false, false, true, false, false },
                new WorkHours[6] { new WorkHours(TimeSpan.Zero, new TimeSpan(23, 0, 0)), z, z, new WorkHours(new TimeSpan(1, 0, 0), new TimeSpan(23, 0, 0)), z, z },
                27, 1500, "054-1231234", true, 2, 2, true, true, "Very good nanny"));
            AddNanny(new Nanny(398734128, "Miri", "Factor", new DateTime(1995, 3, 23), "Ben Zakai 25, Rishon LeTsiyon, Israel", 1, 3, 36, new bool[] { false, false, true, false, false, true },
                new WorkHours[6] {z,z, new WorkHours(new TimeSpan(12, 0, 0), new TimeSpan(20, 0, 0)),z,z, new WorkHours(new TimeSpan(10, 0, 0), new TimeSpan(15, 0, 0)) },
                29, 2300, "057-3453535", true, 5, 3, true, false));
            AddMother(new Mother(274857123, "Galia", "Nagar", "pinkhas zekharya 24, rishon lezion, israel", "rishon lezion, israel", new bool[] { true, false, false, true, false, false },
                new WorkHours[6] { new WorkHours(new TimeSpan(15, 0, 0), new TimeSpan(20, 0, 0)),z,z, new WorkHours(new TimeSpan(15, 0, 0), new TimeSpan(18, 0, 0)),z,z },
                false, "032-2345674"));
            AddMother(new Mother(123123123, "Shoshy", "Smith", "Rabbi Meir Street 12, Tel Aviv-Yafo, Israel", null, new bool[] { false, false, true, false, true, true },
                new WorkHours[6] {z,z, new WorkHours(new TimeSpan(10, 0, 0), new TimeSpan(15, 0, 0)),z, new WorkHours(new TimeSpan(18, 0, 0), new TimeSpan(22, 0, 0)), new WorkHours(new TimeSpan(10, 0, 0), new TimeSpan(15, 0, 0)) },
                true, "03-9582615"));
            AddChild(new Child(234875912, 274857123, "Gili", new DateTime(2012, 4, 15), true, "Need a lot of tzumy"));
            AddChild(new Child(829347234, 123123123, "RL", new DateTime(2017, 2, 24)));
            AddChild(new Child(546987244, 123123123, "BD", new DateTime(2017, 9, 29)));
            AddContract(new Contract(123451234, 234875912, 274857123, new DateTime(2018, 2, 1), new DateTime(2018, 6, 1), true));
        }

        #region Nanny
        public void AddNanny(Nanny n)
        {
            if (DateTime.Today < n.Birthdate.AddYears(18))
                throw new Exception("A nanny must be age 18 and over");
            dal.AddNanny(n);
        }
        public void RemoveNanny(int id)
        {
            foreach (var c in GetContractsByTerm(c => c.NannyID == id))
                RemoveContract(c.Number);

            dal.RemoveNanny(id);
        }
        public void UpdateNanny(Nanny n)
        {
            if (DateTime.Today < n.Birthdate.AddYears(18))
                throw new Exception("A nanny must be age 18 and over");
            dal.UpdateNanny(n);

            foreach (var c in GetContractsByTerm(c => c.NannyID == n.ID))
            {
                Mother m = GetMother(c.MotherID);
                RemoveContract(c.Number);
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
        public void RemoveMother(int id)
        {
            foreach (var c in GetContractsByTerm(c => c.MotherID == id))
                RemoveContract(c.Number);

            foreach (var c in GetChildsByTerm(c => c.MotherID == id))
                RemoveChild(c.ID);

            dal.RemoveMother(id);
        }
        public void UpdateMother(Mother m)
        {
            dal.UpdateMother(m);
            foreach (var c in GetAllContracts())
            {
                if (c.MotherID == m.ID)
                {
                    Nanny n = GetNanny(c.NannyID);
                    RemoveContract(c.Number);
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
        public void RemoveChild(int id)
        {
            foreach (var c in GetContractsByTerm(con => id == con.ChildID))
                RemoveContract(c.Number);

            dal.RemoveChild(id);
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
        public int CurrentNumber() => dal.CurrentNumber();

        public void AddContract(Contract c)
        {
            if (DateTime.Today < GetChild(c.ChildID).Birthdate.AddMonths(3))
                throw new Exception("The kid is younger than 3 monthes");

            //Checks if there is a place for another child to this nanny
            int numChildsToNanny = 0;
            foreach (var con in GetContractsByTerm(con => con.NannyID == c.NannyID && con.WasSignature))
                numChildsToNanny++;

            if (numChildsToNanny < GetNanny(c.NannyID).MaxChilds)
                c.WasSignature = true;
            else
                c.WasSignature = false;

            dal.AddContract(c);
            RepairWageForMotherAndNanny(GetMother(c.MotherID), GetNanny(c.NannyID));
        }
        public void RemoveContract(int num)
        {
            Contract c = GetContract(num);
            dal.RemoveContract(num);
            RepairWageForMotherAndNanny(GetMother(c.MotherID), GetNanny(c.NannyID));
        }
        public void UpdateContract(Contract c)
        {
            dal.UpdateContract(c);
            RepairWageForMotherAndNanny(GetMother(c.MotherID), GetNanny(c.NannyID));
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
            catch (Exception)
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
        private TimeSpan GradeNannyToMother(Mother m, Nanny n)
        {
            TimeSpan grade = new TimeSpan(0,0,0);
            TimeSpan start, finish;
            for (int i = 0; i < 6; i++)
            {
                if (m.NeedNannyOnDay[i] && n.WorkOnDay[i])
                {
                    start = (m.HoursForDay[i].Start > n.HoursOnDay[i].Start)?m.HoursForDay[i].Start: n.HoursOnDay[i].Start;
                    finish = (m.HoursForDay[i].Finish < n.HoursOnDay[i].Finish)? m.HoursForDay[i].Finish: n.HoursOnDay[i].Finish;
                    if (start < finish)
                        grade += finish - start;
                }
            }
            return grade;
        }
        /// <summary>
        /// Returns the least suitable Nanny to m from, 2 nannies
        /// </summary>
        /// <param name="m">The Mother who we want to check match to her</param>
        /// <param name="n1">first nanny</param>
        /// <param name="n2">second nanny</param>
        /// <returns>The least suitable Nanny to m, from 2 nannies</returns>
        private Nanny MinGrade(Mother m, Nanny n1, Nanny n2)
        {
			TimeSpan GradeN1 = GradeNannyToMother(m, n1);
			TimeSpan GradeN2 = GradeNannyToMother(m, n2);
			TimeSpan min = (GradeN1 < GradeN2)? GradeN1: GradeN2;
			if (min == GradeN1)
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

        #region Other functions

        /// <summary>
        /// repairs the wage of every contract that is shared with m and n
        /// </summary>
        /// <param name="m">mother</param>
        /// <param name="n">nanny</param>
        private void RepairWageForMotherAndNanny(Mother m, Nanny n)
        {
            double discount = 1;
            foreach (var c in GetContractsByTerm(c => m.ID == c.MotherID && n.ID == c.NannyID))
                discount *= 0.98;
            discount /= 0.98;
            foreach (var c in GetContractsByTerm(c => m.ID == c.MotherID && n.ID == c.NannyID))
            {
                if (m.IsPerMonth)
                {
                    c.IsPerMonth = true;
                    c.WagePerMonth = n.RatePerMonth * discount;
                }
                else
                {
                    c.IsPerMonth = false;
                    c.WagePerMonth = n.RatePerHour * GradeNannyToMother(m, n).TotalHours * 4 * discount;
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
                       group c by (CalculateDistance(area, GetNanny(c.NannyID).Address) / 5000);
            //Don't order contracts
            return from c in GetAllContracts()
                   let tempArea = GetMother(c.MotherID).Area
                   let area = (tempArea != null && tempArea != "") ? tempArea : GetMother(c.MotherID).Address
                   group c by CalculateDistance(area, GetNanny(c.NannyID).Address) / 5000 * 5;
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
        #endregion
    }
}
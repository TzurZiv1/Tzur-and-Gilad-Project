using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using DS;
using System.Xml.Serialization;


namespace DAL
{

    public class Dal_XML_imp : IDAL
    {
        public XElement childRoot;
        public readonly string childPath = @"ChildXml.xml";

        public readonly string nannyPath = @"NannyXml.xml";

        public readonly string motherPath = @"MotherXml.xml";

        public readonly string contractPath = @"ContractXml.xml";



        public Dal_XML_imp()
        {
            CreateFiles();
            if (!File.Exists(nannyPath))
                SaveToXML(new List<Nanny>(), nannyPath);
            if (!File.Exists(motherPath))
                SaveToXML(new List<Mother>(), motherPath);
            if (!File.Exists(contractPath))
                SaveToXML(new List<Contract>(), contractPath);
        }
        private void LoadData()
        {
            try
            {
                childRoot = XElement.Load(childPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        private void CreateFiles()
        {
            childRoot = new XElement("child");
            AddChild(new Child(234875912, 274857123, "Gili", new DateTime(2012, 4, 15), true, "Need a lot of tzumy"));
            AddChild(new Child(829347234, 123123123, "RL", new DateTime(2017, 2, 24)));
            AddChild(new Child(546987244, 123123123, "BD", new DateTime(2017, 9, 29)));
            AddContract(new Contract(123451234, 234875912, 274857123, new DateTime(2018, 2, 1), new DateTime(2018, 6, 1), true));
            childRoot.Save(childPath);
        }
        public List<Child> LoadChildListLinq(string childFile)
        {
            LoadData();
            List<Child> children;
            //try
            //{
                string v = (from c in childRoot.Elements()
                            select c.Element("firstName").Value).FirstOrDefault();
                bool v1 = (from c in childRoot.Elements()
                           select bool.Parse(((c.Element("isSpecial").Value)))).FirstOrDefault();


                children = (from c in childRoot.Elements()
                            select new Child()
                            {
                                ID = int.Parse(c.Element("id").Value),
                                MotherID = int.Parse(c.Element("motherID").Value),
                                FirstName = c.Element("firstName").Value,
                                Birthdate = DateTime.Parse(c.Element("birthdate").Value),
                                IsSpecial = bool.Parse(c.Element("isSpecial").Value),
                                SpecialNeeds = c.Element("specialNeeds").Value
                            }).ToList();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return children;
        }
        public void SaveChildList(List<Child> childlist)
        {
            childRoot = new XElement("childs",
                            from ch in childlist
                            select new XElement("child",
                                new XElement("id", ch.ID),
                               new XElement("motherID", ch.MotherID),
                               new XElement("firstName", ch.FirstName),
                               new XElement("birthdate", ch.Birthdate),
                               new XElement("isSpecial", ch.IsSpecial),
                               new XElement("specialNeeds", ch.SpecialNeeds)
                                )
                            );
            childRoot.Save(childPath);
        }
        public static void SaveToXML<T>(T source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(source.GetType());
            xmlSerializer.Serialize(file, source);
            file.Close();
        }
        public static T LoadFromXML<T>(string path)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T result = (T)xmlSerializer.Deserialize(file);
            file.Close();
            return result;

        }

        public void AddChild(Child child)
        {
            IdAlreadyExist(child.ID);

            List<Child> list = LoadChildListLinq(childPath);

            childRoot.Add(new XElement("child",
                             new XElement("id", child.ID),
                             new XElement("motherID", child.MotherID),
                             new XElement("firstName", child.FirstName),
                             new XElement("birthdate", child.Birthdate),
                             new XElement("isSpecial", child.IsSpecial),
                             new XElement("specialNeeds", child.SpecialNeeds)
            ));
            childRoot.Save(childPath);

        }

        public void AddContract(Contract c)
        {
            if (GetChild(c.ChildID) == null)
                throw new Exception("The child doesn't exist");
            if (GetMother(c.MotherID) == null)
                throw new Exception("The mother doesn't exist");
            if (GetNanny(c.NannyID) == null)
                throw new Exception("The nanny doesn't exist");
            List<Contract> list = LoadFromXML<List<Contract>>(contractPath);

            if (c.Number == 0)
                c.Number = ++currentNumber;
            list.Add(c);
            
            SaveToXML(list, contractPath);
        }
        public void AddMother(Mother m)
        {
            IdAlreadyExist(m.ID);
            List<Mother> list = LoadFromXML<List<Mother>>(motherPath);
            list.Add(m);
            SaveToXML<List<Mother>>(list, motherPath);
        }

        public void AddNanny(Nanny n)
        {
            IdAlreadyExist(n.ID);
            List<Nanny> list = LoadFromXML<List<Nanny>>(nannyPath);
            list.Add(n);
            SaveToXML<List<Nanny>>(list, nannyPath);

        }

        private static int currentNumber = 10000000;
        public int CurrentNumber() => currentNumber;

        public List<Child> GetAllChilds()
        {
            return LoadChildListLinq(childPath);
        }

        public IEnumerable<IGrouping<int, Child>> GetAllChildsByMother() => from c in GetAllChilds()
                                                                            group c by c.MotherID;
        public List<Contract> GetAllContracts()
        {
            return LoadFromXML<List<Contract>>(contractPath);
        }

        public IEnumerable<IGrouping<int, Contract>> GetAllContractsByMother() => from c in GetAllContracts()
                                                                                  group c by c.MotherID;

        public IEnumerable<IGrouping<int, Contract>> GetAllContractsByNanny() => from c in GetAllContracts()
                                                                                 group c by c.NannyID;

        public List<Mother> GetAllMothers()
        {
            return LoadFromXML<List<Mother>>(motherPath);
        }

        public List<Nanny> GetAllNannies()
        {
            return LoadFromXML<List<Nanny>>(nannyPath);
        }

        public Child GetChild(int id)
        {
            List<Child> list = LoadChildListLinq(childPath);
            foreach (var item in list)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;

        }
        public Contract GetContract(int num)
        {
            List<Contract> list = LoadFromXML<List<Contract>>(contractPath);
            return (from contract in list
                    where contract.Number == num
                    select contract).FirstOrDefault();
        }

        public Mother GetMother(int id)
        {
            List<Mother> list = LoadFromXML<List<Mother>>(motherPath);
            return (from mother in list
                    where mother.ID == id
                    select mother).FirstOrDefault();
        }

        public Nanny GetNanny(int id)
        {
            List<Nanny> list = LoadFromXML<List<Nanny>>(nannyPath);
            return (from nanny in list
                    where nanny.ID == id
                    select nanny).FirstOrDefault();

        }

        public void RemoveChild(int id)
        {
            XElement childElement;
            childElement = (from ch in childRoot.Elements()
                            where int.Parse(ch.Element("id").Value) == id
                            select ch).FirstOrDefault();
            childElement.Remove();
            childRoot.Save(childPath);



        }

        public void RemoveContract(int num)
        {
            if (GetContract(num) == null)
                throw new Exception("The contract doesn't exist");
            List<Contract> list = LoadFromXML<List<Contract>>(contractPath);
            Contract con = (from contract in list
                            where contract.Number == num
                            select contract).FirstOrDefault();
            list.Remove(con);
            SaveToXML(list, contractPath);
        }

        public void RemoveMother(int id)
        {
            List<Mother> list = LoadFromXML<List<Mother>>(motherPath);
            Mother mom = (from mother in list
                          where mother.ID == id
                          select mother).FirstOrDefault();
            list.Remove(mom);
            SaveToXML<List<Mother>>(list, motherPath);


        }

        public void RemoveNanny(int id)
        {
            List<Nanny> list = LoadFromXML<List<Nanny>>(nannyPath);
            Nanny nan = (from nanny in list
                         where nanny.ID == id
                         select nanny).FirstOrDefault();
            list.Remove(nan);
            SaveToXML<List<Nanny>>(list, nannyPath);

        }

        public void UpdateChild(Child c)
        {
            XElement childElement = (from ch in childRoot.Elements()
                                     where int.Parse(ch.Element("id").Value) == c.ID
                                     select ch).FirstOrDefault();
            childElement.Element("firstName").Value = c.FirstName;
            childElement.Element("birthdate").Value = c.Birthdate.ToString();
            childElement.Element("isSpecial").Value = c.IsSpecial.ToString();
            childElement.Element("specialNeeds").Value = c.SpecialNeeds;


            childRoot.Save(childPath);
        }

        public void UpdateContract(Contract c)
        {
            if (GetContract(c.Number) == null)
                throw new Exception("The contract doesn't exist");
            if (GetChild(c.ChildID) == null)
                throw new Exception("The child doesn't exist");
            if (GetMother(c.MotherID) == null)
                throw new Exception("The mother doesn't exist");
            if (GetNanny(c.NannyID) == null)
                throw new Exception("The nanny doesn't exist");
            RemoveContract(c.Number);
            AddContract(c);
        }

        public void UpdateMother(Mother m)
        {
            if (GetMother(m.ID) == null)
                throw new Exception("The mother doesn't exist");
            RemoveMother(m.ID);
            AddMother(m);

        }

        public void UpdateNanny(Nanny n)
        {
            if (GetNanny(n.ID) == null)
                throw new Exception("The nanny doesn't exist");
            RemoveNanny(n.ID);
            AddNanny(n);
        }

        private void IdAlreadyExist(int id)
        {
            if ((GetChild(id) != null && GetChild(id).ID != 0) || GetMother(id) != null || GetNanny(id) != null)
                throw new Exception("This ID already exist");
        }
        void Reset()
        {
            List<Nanny> nannies = null;
            SaveToXML(nannies, nannyPath);
            List<Mother> mothers = null;
            SaveToXML(mothers, motherPath);
            List<Child> children = null;
            SaveToXML(children, childPath);
            List<Contract> contracts = null;
            SaveToXML(contracts, contractPath);
        }
    }
}

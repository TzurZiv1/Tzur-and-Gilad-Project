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
        public string childPath = @"ChildXml.xml";
        public XElement nannyRoot;
        public string nannyPath = @"NannyXml.xml";
        public XElement motherRoot;
        public string motherPath = @"MotherXml.xml";
        public XElement contractRoot;
        public string contractPath = @"ContractXml.xml";
        public XElement configRoot;
        public string configPath = @"configXml.xml";


        
        public Dal_XML_imp()
        {
            if (!File.Exists(childPath) || !File.Exists(nannyPath) || !File.Exists(motherPath) || !File.Exists(contractPath) || !File.Exists(configPath))
                CreateFiles();
            else
                LoadData();
        }
        private void LoadData()
        {
            try
            {
                childRoot = XElement.Load(childPath);
                nannyRoot = XElement.Load(nannyPath);
                motherRoot = XElement.Load(motherPath);
                contractRoot = XElement.Load(contractPath);
                configRoot = XElement.Load(configPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
        private void CreateFiles()
        {
            childRoot = new XElement("child");
            childRoot.Save(childPath);
            nannyRoot = new XElement("nanny");
            nannyRoot.Save(nannyPath);
            motherRoot = new XElement("mother");
            motherRoot.Save(motherPath);
            contractRoot = new XElement("contract");
            contractRoot.Save(contractPath);
            configRoot = new XElement("config");
            configRoot.Save(configPath);
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
            XElement id = new XElement("id", child.ID);
            XElement motherID = new XElement("motherID", child.MotherID);
            XElement firstName = new XElement("firstName", child.FirstName);
            XElement birthdate = new XElement("birthdate", firstName, child.Birthdate);
            XElement isSpecial = new XElement("isSpecial", firstName, child.IsSpecial);
            XElement specialNeeds = new XElement("specialNeeds", firstName, child.SpecialNeeds);

            childRoot.Add(new XElement("child", id, motherID, firstName, birthdate, isSpecial, specialNeeds));
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
            int num = LoadFromXML<int>(configPath);
            if (c.Number == 0)
                c.Number = ++num;
            
            list.Add(c);
            //if (c.Number == 0)
            //    c.Number = ++currentNumber;
            //list.Add(c);
            SaveToXML<List<Contract>>(list, contractPath);
            SaveToXML<int>(++num, configPath);
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

        public int CurrentNumber()
        {
            throw new NotImplementedException();
        }

        public List<Child> GetAllChilds()
        {
            return (from ch in childRoot.Elements()
                    select new Child()
                    {
                        ID = int.Parse(ch.Element("id").Value),
                        MotherID = int.Parse(ch.Element("motherID").Value),
                        FirstName = ch.Element("firstName").Value,
                        Birthdate = DateTime.Parse(ch.Element("birthdate").Value),
                        IsSpecial = bool.Parse(ch.Element("isSpecial").Value),
                        SpecialNeeds = ch.Element("specialNeeds").Value
                    }
                   ).ToList();
        }

        public IEnumerable<IGrouping<int, Child>> GetAllChildsByMother() => from c in GetAllChilds()
                                                                            group c by c.MotherID;
        public List<Contract> GetAllContracts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGrouping<int, Contract>> GetAllContractsByMother()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGrouping<int, Contract>> GetAllContractsByNanny()
        {
            throw new NotImplementedException();
        }

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
            XElement childElement;
            Child child = new Child();
            try
            {
                childElement = (from ch in childRoot.Elements()
                                where int.Parse(ch.Element("id").Value) == id
                                select ch).FirstOrDefault();
                child.ID = int.Parse(childElement.Element("id").Value);
                child.MotherID = int.Parse(childElement.Element("motherID").Value);
                child.FirstName = childElement.Element("firstName").Value;
                child.Birthdate = DateTime.Parse(childElement.Element("birthdate").Value);
                child.IsSpecial = bool.Parse(childElement.Element("isSpecial").Value);
                child.SpecialNeeds = childElement.Element("specialNeeds").Value;
                return child;
            }
            catch { return null; }
        }

        public Contract GetContract(int num)
        {
            throw new NotImplementedException();
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
            try
            {
                childElement = (from ch in childRoot.Elements()
                                where int.Parse(ch.Element("id").Value) == id
                                select ch).FirstOrDefault();
                childElement.Remove();
                childRoot.Save(childPath);

            }
            catch
            {
                return;
            }
        }

        public void RemoveContract(int num)
        {

        }

        public void RemoveMother(int id)
        {
            try
            {
                List<Mother> list = LoadFromXML<List<Mother>>(motherPath);
                Mother mom = (from mother in list
                              where mother.ID == id
                              select mother).FirstOrDefault();
                list.Remove(mom);
                SaveToXML<List<Mother>>(list, motherPath);
            }
            catch
            {

                return;
            }

        }

        public void RemoveNanny(int id)
        {
            try
            {
                List<Nanny> list = LoadFromXML<List<Nanny>>(nannyPath);
                Nanny nan = (from nanny in list
                             where nanny.ID == id
                             select nanny).FirstOrDefault();
                list.Remove(nan);
                SaveToXML<List<Nanny>>(list, nannyPath);
            }
            catch
            {
                return;
            }

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
            throw new NotImplementedException();
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
            if (GetChild(id) != null || GetMother(id) != null || GetNanny(id) != null)
                throw new Exception("This ID already exist");
        }
    }
}

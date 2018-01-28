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
    public class XmlSample
    {
        public XElement childRoot;
        public string childPath = @"ChildXml.xml";
        public XElement nannyRoot;
        public string nannyPath = @"NannyXml.xml";
        public XElement motherRoot;
        public string motherPath = @"MotherXml.xml";
        public XElement contractRoot;
        public string contractPath = @"ContractXml.xml";

        public XmlSample()
        {
            if (!File.Exists(childPath))
                CreateFiles();
            else
                LoadData();
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
          private void CreateFiles()
        {
            childRoot = new XElement("child");
            childRoot.Save(childPath);
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
    }



    public class Dal_XML_imp : XmlSample, IDAL
    {
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
            throw new NotImplementedException();
        }

        public void AddMother(Mother m)
        {
            throw new NotImplementedException();
        }

        public void AddNanny(Nanny n)
        {
            
            
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
            throw new NotImplementedException();
        }

        public List<Nanny> GetAllNannies()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Nanny GetNanny(int id)
        {
            throw new NotImplementedException();
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

            }
        }

        public void RemoveContract(int num)
        {
            throw new NotImplementedException();
        }

        public void RemoveMother(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveNanny(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateNanny(Nanny n)
        {
            throw new NotImplementedException();
        }
        private void IdAlreadyExist(int id)
        {
            if (GetChild(id) != null || GetMother(id) != null || GetNanny(id) != null)
                throw new Exception("This ID already exist");
        }
    }
}

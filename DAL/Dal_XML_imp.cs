using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using DS;

namespace DAL
{
    public class XmlSampleNanny
    {
        public XElement childRoot;
        public string childPath = @"ChildXml.xml";

        public XmlSampleNanny()
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



    public class Dal_XML_imp : XmlSampleNanny, IDAL 
    {
        public void AddChild(Child child)
        {
            XElement id = new XElement("id", child.ID);
            XElement motherID = new XElement("motherID", child.MotherID);
            XElement firstName = new XElement("firstName", child.FirstName);
            XElement birthdate = new XElement("birthdate", firstName, child.Birthdate);
            XElement isSpecial = new XElement("isSpecial", firstName, child.IsSpecial);
            XElement specialNeeds = new XElement("specialNeeds", firstName, child.SpecialNeeds);

            childRoot.Add(new XElement("student", id, motherID, firstName, birthdate, isSpecial, specialNeeds));
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
            throw new NotImplementedException();
        }

        public int CurrentNumber()
        {
            throw new NotImplementedException();
        }

        public List<Child> GetAllChilds()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGrouping<int, Child>> GetAllChildsByMother()
        {
            throw new NotImplementedException();
        }

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
            throw new NotImplementedException();
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
            //childElement.Element("name").Element("firstName").Value = child.FirstName;
            //childElement.Element("name").Element("lastName").Value = child.LastName;

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
    }
}

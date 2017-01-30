using Domain.Entities.Contingent;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic.Implementations
{
    public class GroupRepository : EntityXmlRepository<Group>
    {
        public GroupRepository()
            : base(typeof(Group).Name)
        {
            XDocumentProvider.Default = XDocumentProvider.Default == null ? new XDocumentProvider() : XDocumentProvider.Default;
        }

        protected override Func<XElement, Group> Selector
        {
            get
            {
                return x => new Group
                {
                    Id = Guid.Parse(x.Attribute("Id").Value),
                    Name = x.Attribute("Name").Value,
                    Language = x.Attribute("Language").Value,
                    Profession = x.Attribute("Profession").Value,
                    StudyPeriod = x.Attribute("StudyPeriod").Value
                };
            }
        }

        

        protected override XElement GetParentElement()
        {
            return XDocumentProvider.Default.GetDocument().Root.Elements(typeof(Group).Name + "s").First();
        }

        protected override void SetXElementValue(Group obj, XElement element)
        {
            element.Attribute("Name").SetValue(obj.Name);
            element.Attribute("Language").SetValue(obj.Language);
            element.Attribute("Profession").SetValue(obj.Profession);
            element.Attribute("StudyPeriod").SetValue(obj.StudyPeriod);
        }

        protected override XElement CreateXElement(Group obj)
        {
            return new XElement(
                ElementName,
                new XAttribute("Id", obj.Id),
                new XAttribute("Name", obj.Name),
                new XAttribute("Language", obj.Language),
                new XAttribute("Profession", obj.Profession),
                new XAttribute("StudyPeriod", obj.StudyPeriod));
        }
        protected override object GetEntityId(Group obj)
        {
            return obj.Id;
        }
    }
}

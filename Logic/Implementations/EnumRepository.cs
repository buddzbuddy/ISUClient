using Domain.Entities.Contingent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementations
{
    public class EnumRepository:EntityXmlRepository<EnumDef>
    {
        public EnumRepository()
            : base(typeof(EnumDef).Name)
        {

        }
        protected override System.Xml.Linq.XElement GetParentElement()
        {
            return XDocumentProvider.Default.GetDocument().Descendants("EnumDef").First();
        }

        protected override Func<System.Xml.Linq.XElement, EnumDef> Selector
        {
            get
            {
                return x => new EnumDef
                {
                    Id = Guid.Parse(x.Attribute("Id").Value),
                    FullName = x.Attribute("FullName").Value
                };
            }
        }

        protected override void SetXElementValue(EnumDef obj, System.Xml.Linq.XElement element)
        {
            throw new NotImplementedException();
        }

        protected override System.Xml.Linq.XElement CreateXElement(EnumDef obj)
        {
            throw new NotImplementedException();
        }

        protected override object GetEntityId(EnumDef obj)
        {
            return obj.Id;
        }
    }
}

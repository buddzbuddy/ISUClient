using Domain;
using Domain.Entities.Contingent;
using Domain.StaticReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic.Implementations
{
    public class GroupRepository:XRepository
    {
        private XContext context;
        public GroupRepository()
        {
            context = new XContext(OrgStructures.FileName);
        }

        public Group Get(Guid Id)
        {
            var xObj = context.GetElements(typeof(Group).Name + "s").FirstOrDefault(x => Guid.Parse(x.Element("Id").Value) == Id);
            if (xObj != null)
                return ParseTo<Group>(xObj);
            return null;
        }

        public IEnumerable<Group> GetAll()
        {
            var xList = context.GetElements(typeof(Group).Name + "s");
            if (xList != null && xList.Count() > 0)
                return ParseList<Group>(xList);
            return null;
        }

        public void Save(Group obj)
        {
            context.AddElement(WrapFrom(obj), typeof(Group).Name + "s");
        }
    }
}
using Domain;
using Domain.StaticReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic.Repositories
{
    public class EnumRepository : XRepository
    {
        private XEnumContext enumContext;
        public EnumRepository()
        {
            if (Enums.EnumDefs.Count == 0)
            {
                enumContext = new XEnumContext();
                IEnumerable<XElement> xList = enumContext.GetAllElements();
                if (xList != null && xList.Count() > 0)
                {
                    foreach (var xObj in xList.ToList())
                    {
                        var enumDef = ParseTo<Enums.EnumDef>(xObj, true);
                        var xSubList = xObj.Elements();
                        if (xSubList != null && xSubList.Count() > 0)
                            enumDef.Items.AddRange(from xSubObj in xSubList
                                                   select ParseTo<Enums.EnumItem>(xSubObj, true));
                        Enums.EnumDefs.Add(enumDef);
                    }
                }
                else
                    throw new ApplicationException("Справочники не загружены!");
            }
        }

        public Enums.EnumDef GetEnum(Guid Id)
        {
            return Enums.EnumDefs.FirstOrDefault(x => x.Id == Id);
        }

        public Enums.EnumItem GetEnumItem(Guid Id)
        {
            return Enums.EnumDefs.SelectMany(x => x.Items).FirstOrDefault(x => x.Id == Id);
        }
    }
}

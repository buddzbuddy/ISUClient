using Domain;
using Domain.StaticReferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementations
{
    public class EnumRepository : XRepository
    {
        private XEnumContext context;
        public EnumRepository()
        {
            if (Enums.EnumDefs.Count == 0)
            {
                context = new XEnumContext();
                var xList = context.GetAllElements();
                if (xList != null && xList.Count() > 0)
                {
                    foreach (var xObj in xList)
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

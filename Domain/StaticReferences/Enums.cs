using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.StaticReferences
{
    public static class Enums
    {
        public static Guid LanguageEnumDefId = new Guid("{78D15DE5-17CC-4CAE-8D0C-9CBB7D23CBD6}");
        public static Guid StudyPeriodEnumDefId = new Guid("{D877560E-9272-4C85-A185-F19DAC53DE44}");
        public static Guid NationalityEnumDefId = new Guid("{E6AF3BB2-E1AD-4330-AAE7-5579440C2A02}");
        public static Guid GenderEnumDefId = new Guid("{90D4DDA7-2B39-4DB6-BA05-8D64DFF7AA34}");
        public static Guid PersonalDocumentTypeEnumDefId = new Guid("{D4F39AB9-5FCC-49AE-A2E9-013F43C88DFA}");
        private static Dictionary<string, Guid> EnumDefIds = new Dictionary<string, Guid>
        {
            {"Language", LanguageEnumDefId},
            {"StudyPeriod", StudyPeriodEnumDefId},
            {"Nationality", NationalityEnumDefId},
            {"Gender", GenderEnumDefId},
            {"PersonalDocumentType", PersonalDocumentTypeEnumDefId}
        };

        public static List<EnumDef> EnumDefs = new List<EnumDef>();
        public class EnumDef
        {
            public Guid Id { get; set; }
            public string FullName { get; set; }
            [Skip]
            public List<EnumItem> Items = new List<EnumItem>();
        }
        public class EnumItem
        {
            public Guid Id { get; set; }
            public string FullName { get; set; }
        }

        public static Guid GetEnumDefId(string defName)
        {
            if (EnumDefIds.ContainsKey(defName))
            {
                return EnumDefIds[defName];
            }
            else
                throw new ApplicationException("\"EnumDefId\" для выпадающего списка \"" + defName + "\" не найден");
        }
    }
}

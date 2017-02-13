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
        private static Guid LanguageEnumDefId = new Guid("{78D15DE5-17CC-4CAE-8D0C-9CBB7D23CBD6}");
        private static Guid StudyPeriodEnumDefId = new Guid("{D877560E-9272-4C85-A185-F19DAC53DE44}");
        private static Guid NationalityEnumDefId = new Guid("{E6AF3BB2-E1AD-4330-AAE7-5579440C2A02}");
        private static Guid GenderEnumDefId = new Guid("{90D4DDA7-2B39-4DB6-BA05-8D64DFF7AA34}");
        private static Guid PersonalDocumentTypeEnumDefId = new Guid("{D4F39AB9-5FCC-49AE-A2E9-013F43C88DFA}");
        private static Guid CitizenshipEnumDefId = new Guid("{ADAA9BBD-1A7D-495F-9140-9BE7B3CC508F}");
        private static Guid SocialStatusEnumDefId = new Guid("{2E6A19CC-0D5C-4A07-9C41-1081EE65A2E4}");
        private static Guid MilitaryStatusEnumDefId = new Guid("{F424BFAB-E354-49E0-816A-78E536B7F34B}");
        private static Guid EducationTypeEnumDefId = new Guid("{95CAE993-9DC6-4A91-B0C0-D243429E7565}");
        private static Guid EducationDocumentTypeEnumDefId = new Guid("{B1892A2A-664E-4796-8071-3EFC968DFC29}");
        private static Guid EducationDocumentStatusEnumDefId = new Guid("{8EF8DD24-5BA9-4790-8C5C-A1E80E8DA910}");
        private static Guid SchoolTypeEnumDefId = new Guid("{1C17065E-6F72-4508-AC4A-62DF96B54C5E}");
        private static Guid ReceiptTypeEnumDefId = new Guid("{C970366A-3B48-411E-8638-E76FE07FA47D}");
        private static Guid StudyModeEnumDefId = new Guid("{068B20B7-D4B0-41CB-99AC-FFEE6ACB853F}");
        private static Guid PayTypeEnumDefId = new Guid("{5F713283-CCBF-4587-B6F9-218E72FD2C95}");
        private static Guid EducationDirectionEnumDefId = new Guid("{4AFD3B1E-CC03-45A3-9797-690B5B41A9B4}");
        private static Dictionary<string, Guid> EnumDefIds = new Dictionary<string, Guid>
        {
            {"Language", LanguageEnumDefId},
            {"StudyPeriod", StudyPeriodEnumDefId},
            {"Nationality", NationalityEnumDefId},
            {"Gender", GenderEnumDefId},
            {"PersonalDocumentType", PersonalDocumentTypeEnumDefId},
            {"Citizenship", CitizenshipEnumDefId},
            {"SocialStatus", SocialStatusEnumDefId},
            {"MilitaryStatus", MilitaryStatusEnumDefId},
            {"EducationType", EducationTypeEnumDefId},
            {"EducationDocumentType", EducationDocumentTypeEnumDefId},
            {"EducationDocumentStatus", EducationDocumentStatusEnumDefId},
            {"SchoolType", SchoolTypeEnumDefId},
            {"ReceiptType", ReceiptTypeEnumDefId},
            {"StudyMode", StudyModeEnumDefId},
            {"PayType", PayTypeEnumDefId},
            {"EducationDirection", EducationDirectionEnumDefId}
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

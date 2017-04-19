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
        private static Guid EducationEndTypeEnumDefId = new Guid("{AFD96E8D-BE78-4F2B-ABCC-406BB0D8B61F}");
        private static Guid YesNoEnumDefId = new Guid("{1319CBBB-9B89-41E5-AACF-D51A0D6CDF55}");
        private static Guid MaritalStatusEnumDefId = new Guid("{78EF1430-4AA5-4886-9AC2-A39A0BCD8863}");
        private static Guid TeacherEnumDefId = new Guid("{0558FFB1-3F84-4DFE-A103-D6B0579507C1}");
        private static Guid StaffTypeEnumDefId = new Guid("{D0862EEC-DC20-4FC9-83AC-D9A391827BEF}");
        private static Guid BuildingTypeEnumDefId = new Guid("{FDE90A23-2C64-4EA1-9E18-550D6E022C9A}");
        private static Guid BuildingPurposeEnumDefId = new Guid("{237181C6-C6AE-4475-88BD-BD93060EF2EE}");
        private static Guid RoofTypeEnumDefId = new Guid("{5EB9BF6A-1809-4245-8C05-E203CBEC4733}");
        private static Guid StateEnumDefId = new Guid("{CD2BE2E0-80DB-43E0-9014-7283FF9EA521}");
        private static Guid HeatingSystemEnumDefId = new Guid("{D96E7075-192E-4C2C-99D1-C7F820EBE4D4}");
        private static Guid EquipmentCategoryEnumDefId = new Guid("{14B78641-5ADD-42F9-B422-F4E3BFDFCCC3}");
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
            {"EducationDirection", EducationDirectionEnumDefId},
            {"EducationEndType", EducationEndTypeEnumDefId},
            {"YesNo", YesNoEnumDefId},
            {"MaritalStatus", MaritalStatusEnumDefId},
            {"Teacher", TeacherEnumDefId},
            {"StaffType", StaffTypeEnumDefId},
            {"BuildingType", BuildingTypeEnumDefId},
            {"BuildingPurpose", BuildingPurposeEnumDefId},
            {"RoofType", RoofTypeEnumDefId},
            {"State", StateEnumDefId},
            {"HeatingSystem", HeatingSystemEnumDefId},
            {"EquipmentCategory", EquipmentCategoryEnumDefId}
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

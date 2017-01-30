using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISUClient.StaticReferences
{
    public static class OrgStructures
    {
        public static Guid StudentEntryPositionId = new Guid("{0E8530EA-D6FE-4A87-8BB5-CB28AB1A9CD3}");
        public static Guid LedgerEntryPositionId = new Guid("{92E125CA-2DE6-4CDC-A97E-87795E476152}");
        public static Guid EmployeeEntryPositionId = new Guid("{D58FDE72-4924-4889-BAC2-12EE20D37608}");
        public static Guid AllEntryPositionId = new Guid("{4833C86B-59EE-4BDE-AB08-93BB2B71DAB4}");
        private static Dictionary<Guid, string> Positions = new Dictionary<Guid, string>
        {
            {StudentEntryPositionId, "специалист отдела УВР/УПМР"},
            {LedgerEntryPositionId, "специалист отдела МТБ"},
            {EmployeeEntryPositionId, "специалист отдела Кадров"},
            {AllEntryPositionId, "Оператор ИСУ"}
        };
        public static string GetPositionName(Guid positionId)
        {
            if (Positions.ContainsKey(positionId))
                return Positions[positionId];

            return "Должность не найдена";
        }
    }
}

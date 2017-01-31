﻿using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.StaticReferences
{
    public static class Enums
    {
        public static readonly Guid LanguageEnumDefId = new Guid("{78D15DE5-17CC-4CAE-8D0C-9CBB7D23CBD6}");
        public static readonly Guid StudyPeriodEnumDefId = new Guid("{D877560E-9272-4C85-A185-F19DAC53DE44}");

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
    }
}
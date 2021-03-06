﻿using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Contingent
{
    public class Profession : LocalEntity
    {
        public string Name { get; set; }
        [DocMember(typeof(Sector))]
        public Guid Sector { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;

namespace Cigars.Models
{
    public class Strength
    {

        [PrimaryKey]
        public int StrengthId { get; set; }

        public string Name { get; set; }

    }
}

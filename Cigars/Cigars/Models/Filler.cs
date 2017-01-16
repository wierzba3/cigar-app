﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;

namespace Cigars.Models
{
    public class Filler
    {

        [PrimaryKey]
        public int FillerId { get; set; }

        public string Name { get; set; }

    }
}

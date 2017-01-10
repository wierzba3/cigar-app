﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Cigars.Models
{
    public class Smoke
    {

        [PrimaryKey]
        public int SmokeId { get; set; }
        
        public string Notes { get; set; }

        public double Rating { get; set; }

        public int Duration { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Cigars.Models
{
    public class Brand
    {

        [PrimaryKey]
        public int BrandId { get; set; }

        public string Name { get; set; }

    }
}

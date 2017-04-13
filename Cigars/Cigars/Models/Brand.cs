using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;

namespace Cigars.Models
{
    public class Brand
    {

        [PrimaryKey, AutoIncrement]
        public int BrandId { get; set; }

        public string Name { get; set; }

    }
}

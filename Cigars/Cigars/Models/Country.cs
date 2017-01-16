using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Cigars.Models
{
    public class Country
    {

        [PrimaryKey]
        public int CountryId { get; set; }

        public string Name { get; set; }

    }
}

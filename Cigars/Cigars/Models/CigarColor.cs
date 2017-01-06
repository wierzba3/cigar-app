using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Cigars.Models
{
    public class CigarColor
    {

        [PrimaryKey]
        public int CigarColorId { get; set; }

        public string Name { get; set; }

    }
}

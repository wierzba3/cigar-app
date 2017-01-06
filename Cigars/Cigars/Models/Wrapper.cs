using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Cigars.Models
{
    public class Wrapper
    {

        [PrimaryKey]
        public int WrapperId { get; set; }

        public string Name { get; set; }

    }
}

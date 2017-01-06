using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Cigars.Models
{
    public class WrapperToCigar
    {

        [PrimaryKey]
        public int WrapperToCigarId { get; set; }

        [ForeignKey(typeof(Wrapper))]
        public int WrapperId { get; set; }

        [ForeignKey(typeof(Cigar))]
        public int CigarId { get; set; }
    }
}

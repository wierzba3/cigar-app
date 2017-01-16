using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Cigars.Models
{
    public class FillerToCigar
    {

        [PrimaryKey]
        public int FillerToCigarId { get; set; }

        [ForeignKey(typeof(Filler))]
        public int FillerId { get; set; }

        [ForeignKey(typeof(Cigar))]
        public int CigarId { get; set; }

    }
}

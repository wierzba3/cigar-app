using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Cigars.Models
{
    public class PriceEntry
    {

        [PrimaryKey, AutoIncrement]
        public int PriceEntryId { get; set; }

        [ForeignKey(typeof(Cigar))]
        public int CigarId { get; set; }

        public int Price { get; set; }

        public DateTime DateCreated { get; set; }

    }
}

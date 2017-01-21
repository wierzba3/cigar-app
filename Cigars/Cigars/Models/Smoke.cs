using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Cigars.Models
{
    public class Smoke
    {

        //TODO flavor field

        [PrimaryKey, AutoIncrement]
        public int SmokeId { get; set; }

        [ForeignKey(typeof(Cigar))]
        public int CigarId { get; set; }
        
        public string Notes { get; set; }

        public double Rating { get; set; }

        public int Duration { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public Cigar Cigar { get; set; }

    }
}

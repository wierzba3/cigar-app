using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Cigars.Models
{
    public class HumidorEntry
    {

        [PrimaryKey]
        public int HumidorEntryId { get; set; }

        [ForeignKey(typeof(Humidor))]
        public int HumidorId { get; set; }
        
        public double Price { get; set; }

        public string PlaceObtained { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

    }
}

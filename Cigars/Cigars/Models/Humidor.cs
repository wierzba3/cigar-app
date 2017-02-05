using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.ViewModels;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Cigars.Models
{
    public class Humidor
    {

        [PrimaryKey]
        public int HumidorId { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<HumidorEntry> HumidorEntries { get; set; }

    }
}

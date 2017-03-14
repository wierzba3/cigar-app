using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigars.Models
{
    public class HumidorEntryGroup
    {

        public int Quantity { get; set; }

        public int OriginalQuantity { get; set; }
            
        public Cigar Cigar { get; set; }

        public int HumidorId { get; set; }

        public bool IsNew { get; set; }

    }
}

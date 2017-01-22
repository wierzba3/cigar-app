using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Models;

namespace Cigars.Common
{
    public class CigarChosenEventHandler : EventArgs
    {

        private readonly Cigar _cigar;

        public CigarChosenEventHandler(Cigar cigar)
        {
            _cigar = cigar;
        }

        public Cigar CigarObject => _cigar;


    }
}

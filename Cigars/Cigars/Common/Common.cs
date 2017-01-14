using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Models;

namespace Cigars.Common
{
    public class Common
    {

        public static ObservableCollection<Smoke> GenerateSampleSmokesData()
        {
            //TODO create cigars to associate with Smokes
            
            Cigar cigar1 = new Cigar();
            cigar1.CigarId = 1;
            cigar1.Name = "cigar1";

            Cigar cigar2 = new Cigar();
            cigar2.CigarId = 2;
            cigar2.Name = "cigar2";




            /* 
        public int SmokeId { get; set; }

        [ForeignKey(typeof(Cigar))]
        public int CigarId { get; set; }
        
        public string Notes { get; set; }

        public double Rating { get; set; }

        public int Duration { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        [OneToOne]
        public Cigar Cigar { get; set; }
             */


            ObservableCollection<Smoke> result = new ObservableCollection<Smoke>();
            for (int i = 0; i < 5; i++)
            {
                Smoke smoke = new Smoke();
                smoke.Rating = i;
                smoke.Notes = "notes" + (i+1);
                smoke.Cigar = i%2 == 0 ? cigar1 : cigar2;
                result.Add(smoke);
            }
            return result;
        }

    }
}

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
            ObservableCollection<Smoke> result = new ObservableCollection<Smoke>();
            for (int i = 0; i < 10; i++)
            {
                Smoke smoke = new Smoke();
                smoke.Rating = i;
                smoke.Notes = "notes" + (i+1);
                result.Add(smoke);
            }
            return result;
        }

    }
}

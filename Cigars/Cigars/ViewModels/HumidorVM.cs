using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Common;

namespace Cigars.ViewModels
{
    public class HumidorVM : INotifyPropertyChanged
    {
        public HumidorVM()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}

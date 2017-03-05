using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Models;

namespace Cigars.ViewModels
{
    public class AddHumidorEntryVM : INotifyPropertyChanged
    {

        public AddHumidorEntryVM()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public HumidorEntryGroup HumidorEntryGroupModel { get; set; }

    }
}

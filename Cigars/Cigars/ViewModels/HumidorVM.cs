using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Common;
using Cigars.Models;

namespace Cigars.ViewModels
{
    public class HumidorVM : INotifyPropertyChanged
    {
        public HumidorVM()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private ObservableCollection<HumidorEntry> _humidorEntryCollection;
        public ObservableCollection<HumidorEntry> HumidorEntryCollection
        {
            get
            { return _humidorEntryCollection; }
            set
            {
                if (value != _humidorEntryCollection)
                {
                    _humidorEntryCollection = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("HumidorEntryCollection"));
                }
            }
        }

    }
}

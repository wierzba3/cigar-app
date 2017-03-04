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

        private ObservableCollection<HumidorEntryGroup> _humidorEntryGroupCollection;
        public ObservableCollection<HumidorEntryGroup> HumidorEntryGroupCollection
        {
            get
            { return _humidorEntryGroupCollection; }
            set
            {
                if (value != _humidorEntryGroupCollection)
                {
                    _humidorEntryGroupCollection = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("HumidorEntryGroupCollection"));
                }
            }
        }

    }
}

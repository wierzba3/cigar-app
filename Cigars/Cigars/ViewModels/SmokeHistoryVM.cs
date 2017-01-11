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
    public class SmokeHistoryVM : INotifyPropertyChanged
    {

        public SmokeHistoryVM()
        {
            _smokeCollection = new ObservableCollection<Smoke>();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private ObservableCollection<Smoke> _smokeCollection;

        public ObservableCollection<Smoke> SmokeCollection
        {
            get { return _smokeCollection; }
            set
            {
                if (value != _smokeCollection)
                {
                    _smokeCollection = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("SmokeCollection"));
                }
            }
        }

    }
}

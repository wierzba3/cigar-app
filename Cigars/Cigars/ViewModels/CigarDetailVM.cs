using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigars.ViewModels
{
    public class CigarDetailVM : INotifyPropertyChanged
    {
        public CigarDetailVM() { }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _cigarName;

        public string CigarName
        {
            get { return _cigarName; }
            set
            {
                _cigarName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CigarName"));
            }
        }

    }
}

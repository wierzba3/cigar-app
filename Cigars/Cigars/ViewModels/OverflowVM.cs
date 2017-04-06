using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cigars.ViewModels
{
    public class OverflowVM : INotifyPropertyChanged
    {

        public OverflowVM()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private ICommand _browseCigars;

        public ICommand BrowseCigars
        {
            get
            {
                return _browseCigars = _browseCigars ?? new Command(
                    (t) =>
                    {
                        var x = 5;
                    });
            }
        }

    }


}

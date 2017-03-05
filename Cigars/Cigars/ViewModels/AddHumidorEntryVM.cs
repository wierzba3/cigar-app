using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cigars.Models;
using Xamarin.Forms;

namespace Cigars.ViewModels
{
    public class AddHumidorEntryVM : INotifyPropertyChanged
    {

        public AddHumidorEntryVM()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public HumidorEntryGroup HumidorEntryGroupModel { get; set; }

        private Cigar _chosenCigar;

        public Cigar ChosenCigar
        {
            get { return _chosenCigar; }
            set
            {
                _chosenCigar = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ChosenCigar"));
            }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                _saveCommand = new Command(async (t) =>
                {
                    var cigar = ChosenCigar;
                });
                return _saveCommand;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cigars.Common;
using Cigars.Models;
using Xamarin.Forms;

namespace Cigars.ViewModels
{
    public class ChooseCigarVM : INotifyPropertyChanged
    {

        public ChooseCigarVM()
        {
            
        }

        public EventHandler<CigarChosenEventHandler> CigarChosen;
        public EventHandler Cancel;

        public event PropertyChangedEventHandler PropertyChanged = delegate{};

        private ICommand _chooseCigarCommand;
        public ICommand ChooseCigarCommand
        {
            get
            {
                _chooseCigarCommand = new Command((t) =>
                {
                    Cigar cigar = new Cigar()
                    {
                        Name = "chosen_cigar"
                    };
                    CigarChosenEventHandler e = new CigarChosenEventHandler(cigar);
                    CigarChosen(this, e);
                });
                return _chooseCigarCommand;
                
            }
        }

    }


}

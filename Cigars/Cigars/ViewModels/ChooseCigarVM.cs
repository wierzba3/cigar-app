using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            //_cigarCollection = new ObservableCollection<Cigar>(App.Database.GetAll<Cigar>().Result);
        }

        public EventHandler<CigarChosenEventHandler> CigarChosenCallback;
        public EventHandler CancelCallback;

        public event PropertyChangedEventHandler PropertyChanged = delegate{};



        private ObservableCollection<Cigar> _cigarCollection;
        public ObservableCollection<Cigar> CigarCollection
        {
            get { return _cigarCollection; }
            set
            {
                _cigarCollection = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CigarCollection"));
            }
        }

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
                    CigarChosenCallback(this, e);
                });
                return _chooseCigarCommand;
                
            }
        }

    }


}

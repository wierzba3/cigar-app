using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cigars.Common;
using Cigars.Views;
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
                    async (t) =>
                    {
                        await App.Current.MainPage.Navigation.PushAsync(
                            new ChooseCigarPage(HandleCigarChosen, HandleChooseCigarCancel));
                    });
            }
        }

        private void HandleCigarChosen(object sender, CigarChosenEventHandler e)
        {
            if (e.CigarObject == null) return;
            App.Current.MainPage.Navigation.PushAsync(new CigarDetailPage(e.CigarObject));
        }

        private void HandleChooseCigarCancel(object sender, EventArgs e)
        {
            //do nothing
        }
    }
}

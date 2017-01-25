using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Common;
using Cigars.Models;
using Cigars.ViewModels;
using Xamarin.Forms;

namespace Cigars.Views
{
    public partial class ChooseCigarPage : ContentPage
    {

        private ChooseCigarVM _vm;

        public ChooseCigarPage(EventHandler<CigarChosenEventHandler> cigarChosenArg, EventHandler cancelArg)
        {
            InitializeComponent();
            BindingContext = _vm = App.Locator.ChooseCigar;
            _vm.CigarChosen = cigarChosenArg;
            _vm.Cancel = cancelArg;
        }

        protected void OnCigarSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //disable the ability to select items
            ((ListView)sender).SelectedItem = null;
        }

        protected async void OnCigarTapped(object sender, ItemTappedEventArgs e)
        {
            //Smoke smoke = (Smoke)e.Item;
            //App.Locator.AddSmoke.SmokeModel = smoke;
            //await Navigation.PushAsync(new AddSmokePage());
            Cigar chosenCigar = (Cigar) e.Item;
            CigarChosenEventHandler cigarEvent = new CigarChosenEventHandler(chosenCigar);
            _vm.CigarChosen(this, cigarEvent);
        }

    }
}

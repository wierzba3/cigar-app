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
            sbSearch.TextChanged += FilterContacts;
            _allCigars = App.Database.GetAll<Cigar>().Result;
            lvCigars.ItemsSource = _allCigars;
        }

        private List<Cigar> _allCigars;

        protected void OnCigarSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //disable the ability to select items
            ((ListView)sender).SelectedItem = null;
        }

        protected async void OnCigarTapped(object sender, ItemTappedEventArgs e)
        {
            Cigar chosenCigar = (Cigar) e.Item;
            CigarChosenEventHandler cigarEvent = new CigarChosenEventHandler(chosenCigar);
            _vm.CigarChosen(this, cigarEvent);
        }

        private async void FilterContacts(object sender, TextChangedEventArgs e)
        {
            string searchText = sbSearch.Text;
            if (string.IsNullOrEmpty(searchText)) lvCigars.ItemsSource = _allCigars;
            lvCigars.ItemsSource = _allCigars.Where((c) => c.Name == null ? false : c.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
        }


    }
}

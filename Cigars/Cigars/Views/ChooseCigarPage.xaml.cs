using System;
using System.Collections.Generic;
using System.Linq;
using Cigars.Common;
using Cigars.Models;
using Cigars.ViewModels;
using Xamarin.Forms;

namespace Cigars.Views
{
    public partial class ChooseCigarPage : ContentPage
    {

        private ChooseCigarVM _vm;

        public ChooseCigarPage(EventHandler<CigarChosenEventHandler> cigarChosenCallbackArg, EventHandler cancelCallbackArg)
        {
            InitializeComponent();
            Title = "Cigars";
            BindingContext = _vm = App.Locator.ChooseCigar;
            _vm.CigarChosenCallback = cigarChosenCallbackArg;
            _vm.CancelCallback = cancelCallbackArg;
            sbSearch.TextChanged += FilterContacts;
            _allCigars = App.Database.GetAllWithChildren<Cigar>().Result;
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
            if(_vm.CigarChosenCallback != null)
            {
                Cigar chosenCigar = (Cigar)e.Item;
                CigarChosenEventHandler cigarEvent = new CigarChosenEventHandler(chosenCigar);
                _vm.CigarChosenCallback(this, cigarEvent);
            }
        }

        private async void FilterContacts(object sender, TextChangedEventArgs e)
        {
            string searchText = sbSearch.Text;
            if (string.IsNullOrEmpty(searchText)) lvCigars.ItemsSource = _allCigars;
            lvCigars.ItemsSource = _allCigars.Where((c) => c.Name == null ? false : c.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}

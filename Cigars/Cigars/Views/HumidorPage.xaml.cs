using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Models;
using Cigars.ViewModels;
using Xamarin.Forms;

namespace Cigars.Views
{
    public partial class HumidorPage : ContentPage
    {

        private HumidorVM _vm;
        public HumidorPage()
        {
            BindingContext = _vm = App.Locator.Humidor;
            InitializeComponent();
            Title = "Humidor";
        }

        protected override void OnAppearing()
        {
            var groups = App.Database.GetAllWithChildren<HumidorEntry>().Result.GroupBy(entry => entry.CigarId);
            _vm.HumidorEntryGroupCollection = new ObservableCollection<HumidorEntryGroup>();
            foreach (IGrouping<int, HumidorEntry> group in groups)
            {
                if (!group.Any()) continue;
                var humidorEntryGroup = new HumidorEntryGroup();
                humidorEntryGroup.Quantity = group.Count();
                humidorEntryGroup.Cigar = group.GetEnumerator().Current.Cigar;
                _vm.HumidorEntryGroupCollection.Add(humidorEntryGroup);
            }
            
            base.OnAppearing();
        }

        protected async void AddCigarTapped(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new AddSmokePage(new Smoke()));
        }

        protected void OnCigarSelection(object sender, SelectedItemChangedEventArgs e)
        {
            //disable the ability to select items
            ((ListView)sender).SelectedItem = null;
        }

        protected async void OnCigarTapped(object sender, ItemTappedEventArgs e)
        {
            //Smoke smoke = (Smoke)e.Item;
            //await Navigation.PushAsync(new AddSmokePage(smoke));
        }

    }
}

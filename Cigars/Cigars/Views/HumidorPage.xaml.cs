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
            var humidors = App.Database.GetAll<Humidor>().Result;
            if(!humidors.Any()) throw new InvalidOperationException();

            //TODO make this page tabbed for multiple humidors
            int humidorId = humidors[0].HumidorId;
            _vm.HumidorModel = humidors[0];

            var groups = App.Database.GetAllWithChildren<HumidorEntry>(h => h.HumidorId == humidorId)
                .Result.GroupBy(entry => entry.CigarId);

            _vm.HumidorEntryGroupCollection = new ObservableCollection<HumidorEntryGroup>();
            foreach (IGrouping<int, HumidorEntry> group in groups)
            {
                if (!group.Any()) continue;
                var humidorEntryGroup = new HumidorEntryGroup();
                humidorEntryGroup.Quantity = group.Count();
                using (IEnumerator<HumidorEntry> enumerator = group.GetEnumerator())
                {
                    enumerator.MoveNext();
                    humidorEntryGroup.Cigar = enumerator.Current.Cigar;
                    _vm.HumidorEntryGroupCollection.Add(humidorEntryGroup);
                }
            }
            
            base.OnAppearing();
        }

        protected void AddCigarTapped(object sender, EventArgs args)
        {
            var humidorEntryGroup = new HumidorEntryGroup() { IsNew = true };
            humidorEntryGroup.HumidorId = _vm.HumidorModel.HumidorId;
            Navigation.PushAsync(new AddHumidorEntryPage(humidorEntryGroup));
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

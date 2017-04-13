using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cigars.Models;
using Cigars.ViewModels;
using Xamarin.Forms;

namespace Cigars.Views
{
    public partial class HumidorPage : TabbedPage
    {

        private HumidorVM _vm;
        public HumidorPage()
        {
            BindingContext = _vm = App.Locator.Humidor;
            InitializeComponent();
            Title = "Humidor";
            foreach (string sortName in SORT_PICKER_ITEMS.Keys)
            {
                pckSortBy.Items.Add(sortName);
            }
            pckSortBy.SelectedIndex = 0;
        }

        enum SortOption
        {
            QuantityAsc = 1,
            QuantityDesc = 2,
            CigarNameAsc = 3,
            CigarNameDesc = 4
        }

        private static readonly Dictionary<string, SortOption> SORT_PICKER_ITEMS
            = new Dictionary<string, SortOption>()
            {
                { "Quantity Hi -> Lo", SortOption.QuantityDesc },
                { "Quantity Lo -> Hi", SortOption.QuantityAsc },
                { "Cigar Name A -> Z", SortOption.CigarNameAsc },
                { "Cigar Name Z -> A", SortOption.CigarNameDesc }
            };

        protected override void OnAppearing()
        {
            var humidors = App.Database.GetAll<Humidor>().Result;
            if(!humidors.Any()) throw new InvalidOperationException();

            //TODO make this page tabbed for multiple humidors
            int humidorId = humidors[0].HumidorId;
            _vm.HumidorModel = humidors[0];

            var humidorEntries = App.Database.GetAllWithChildren<HumidorEntry>(h => h.HumidorId == humidorId).Result;
            AggregateHumidorEntires(humidorEntries);
            var groups = humidorEntries.GroupBy(entry => entry.CigarId);

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

        protected void OnSortOptionChanged(object sender, EventArgs e)
        {
            if (_vm.HumidorEntryGroupCollection == null || !_vm.HumidorEntryGroupCollection.Any()) return;
            SortHumidorEntries(_vm.HumidorEntryGroupCollection.ToList());
            
        }

        private void AggregateHumidorEntires(IEnumerable<HumidorEntry> humidorEntries)
        {
            var groups = humidorEntries.GroupBy(entry => entry.CigarId);

            //_vm.HumidorEntryGroupCollection = new ObservableCollection<HumidorEntryGroup>();
            var humidorEntryGroups = new List<HumidorEntryGroup>();
            foreach (IGrouping<int, HumidorEntry> group in groups)
            {
                if (!group.Any()) continue;
                var humidorEntryGroup = new HumidorEntryGroup();
                humidorEntryGroup.Quantity = group.Count();
                using (IEnumerator<HumidorEntry> enumerator = group.GetEnumerator())
                {
                    enumerator.MoveNext();
                    humidorEntryGroup.Cigar = enumerator.Current.Cigar;
                    humidorEntryGroups.Add(humidorEntryGroup);
                }
            }
            SortHumidorEntries(humidorEntryGroups);
        }

        private void SortHumidorEntries(List<HumidorEntryGroup> humidorEntryGroups)
        {
            //TODO
            string selection = pckSortBy.Items[pckSortBy.SelectedIndex];
            SortOption opt = SORT_PICKER_ITEMS[selection];
            switch (opt)
            {
                case SortOption.CigarNameAsc:
                    humidorEntryGroups.Sort(
                        (s1, s2) => s1.Cigar.Name.CompareTo(s2.Cigar.Name)
                    );
                    _vm.HumidorEntryGroupCollection = new ObservableCollection<HumidorEntryGroup>(humidorEntryGroups);
                    break;
                case SortOption.CigarNameDesc:
                    humidorEntryGroups.Sort(
                        (s1, s2) => s2.Cigar.Name.CompareTo(s1.Cigar.Name)
                    );
                    _vm.HumidorEntryGroupCollection = new ObservableCollection<HumidorEntryGroup>(humidorEntryGroups);
                    break;
                case SortOption.QuantityAsc:
                    humidorEntryGroups.Sort(
                        (s1, s2) => s1.Quantity.CompareTo(s2.Quantity)
                    );
                    _vm.HumidorEntryGroupCollection = new ObservableCollection<HumidorEntryGroup>(humidorEntryGroups);
                    break;
                case SortOption.QuantityDesc:
                    humidorEntryGroups.Sort(
                        (s1, s2) => s2.Quantity.CompareTo(s1.Quantity)
                    );
                    _vm.HumidorEntryGroupCollection = new ObservableCollection<HumidorEntryGroup>(humidorEntryGroups);
                    break;
            }
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

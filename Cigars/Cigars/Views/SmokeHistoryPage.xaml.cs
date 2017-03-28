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
    public partial class SmokeHistoryPage : ContentPage
    {
        //a copy of the reference to the VM to avoid having to cast the BindingContext

        private List<Cigar> cigars;

        private SmokeHistoryVM _vm;

        public SmokeHistoryPage()
        {
            InitializeComponent();
            Title = "Smokes";
            BindingContext = _vm = App.Locator.SmokeHistory;
            cigars = App.Database.GetAll<Cigar>().Result;

            foreach (string sortName in SORT_PICKER_ITEMS.Keys)
            {
                pckSortBy.Items.Add(sortName);
            }
            pckSortBy.SelectedIndex = 0;
        }

        enum SortOption
        {
            Latest = 1,
            Earliest = 2,
            Rating = 3,
            CigarNameAsc = 4,
            CigarNameDesc = 5
        }

        private static readonly Dictionary<string, SortOption> SORT_PICKER_ITEMS
            = new Dictionary<string, SortOption>()
            {
                { "Most Recent", SortOption.Latest },
                { "Earliest", SortOption.Earliest },
                { "Rating", SortOption.Rating },
                { "Cigar Name A -> Z", SortOption.CigarNameAsc },
                { "Cigar Name Z -> A", SortOption.CigarNameDesc }
            };

        protected void OnSortOptionChanged(object sender, EventArgs e)
        {
            if (_vm.SmokeCollection == null || !_vm.SmokeCollection.Any()) return;
            SortSmokes(_vm.SmokeCollection.ToList());
        }

        protected override void OnAppearing()
        {
            SortSmokes(App.Database.GetAllWithChildren<Smoke>().Result);
            base.OnAppearing();
        }

        private void SortSmokes(List<Smoke> smokes)
        {
            string selection = pckSortBy.Items[pckSortBy.SelectedIndex];
            SortOption opt = SORT_PICKER_ITEMS[selection];
            switch (opt)
            {
                case SortOption.CigarNameAsc:
                    smokes.Sort(
                        (s1, s2) => s1.Cigar.Name.CompareTo(s2.Cigar.Name)
                    );
                    _vm.SmokeCollection = new ObservableCollection<Smoke>(smokes);
                    break;
                case SortOption.CigarNameDesc:
                    smokes.Sort(
                        (s1, s2) => s2.Cigar.Name.CompareTo(s1.Cigar.Name)
                    );
                    _vm.SmokeCollection = new ObservableCollection<Smoke>(smokes);
                    break;
                case SortOption.Earliest:
                    smokes.Sort(
                        (s1, s2) => s1.DateCreated.CompareTo(s2.DateCreated)
                    );
                    _vm.SmokeCollection = new ObservableCollection<Smoke>(smokes);
                    break;
                case SortOption.Latest:
                    smokes.Sort(
                        (s1, s2) => s2.DateCreated.CompareTo(s1.DateCreated)
                    );
                    _vm.SmokeCollection = new ObservableCollection<Smoke>(smokes);
                    break;
                case SortOption.Rating:
                    smokes.Sort(
                        (s1, s2) => s2.Rating.CompareTo(s1.Rating)
                    );
                    _vm.SmokeCollection = new ObservableCollection<Smoke>(smokes);
                    break;
            }
        }

        protected async void AddSmokeTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddSmokePage(new Smoke()));
        }

        protected void OnSmokeSelection(object sender, SelectedItemChangedEventArgs e)
        {
            //disable the ability to select items
            ((ListView)sender).SelectedItem = null;
        }

        protected async void OnSmokeTapped(object sender, ItemTappedEventArgs e)
        {
            Smoke smoke = (Smoke)e.Item;
            await Navigation.PushAsync(new AddSmokePage(smoke));
        }
    }
}

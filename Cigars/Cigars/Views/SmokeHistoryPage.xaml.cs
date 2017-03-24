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
            string selection = pckSortBy.Items[pckSortBy.SelectedIndex];
            SortOption opt = SORT_PICKER_ITEMS[selection];

            //TODO sort based on chosen option. ObservableCollection doesn't appear to have sort functionality?
            //TODO sorting desc not working (by reversing string arguments s2.compareto(s1) instead of s1.compareto(s2)
            List<Smoke> sorted;
            switch (opt)
            {
                case SortOption.CigarNameAsc:
                    sorted = _vm.SmokeCollection.ToList();
                    sorted.Sort(
                        (s1, s2) => s1.Cigar.Name.CompareTo(s2.Cigar.Name)
                    ); 
                    _vm.SmokeCollection = new ObservableCollection<Smoke>(sorted);                   
                    break;
                case SortOption.CigarNameDesc:
                    sorted = _vm.SmokeCollection.ToList();
                    sorted.Sort(
                        (s1, s2) => s2.Cigar.Name.CompareTo(s1.Cigar.Name)
                    );
                    _vm.SmokeCollection = new ObservableCollection<Smoke>(sorted);
                    break;
            }
        }

        protected override void OnAppearing()
        {
            _vm.SmokeCollection = new ObservableCollection<Smoke>(App.Database.GetAllWithChildren<Smoke>().Result);
            base.OnAppearing();
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

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

            if (!cigars.Any())
            {
                Cigar cigar = new Cigar();
                cigar.Name = "cigar1";
                cigars.Add(cigar);
                App.Database.Insert(cigar);
            }
        }



        protected override void OnAppearing()
        {
            _vm.SmokeCollection = new ObservableCollection<Smoke>(App.Database.GetAllWithChildren<Smoke>().Result);
            base.OnAppearing();
        }

        protected async void AddSmokeTapped(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AddSmokePage());
        }

        protected void OnSmokeSelection(object sender, SelectedItemChangedEventArgs e)
        {
            //disable the ability to select items
            ((ListView) sender).SelectedItem = null;
        }

        protected async void OnSmokeTapped(object sender, ItemTappedEventArgs e)
        {
            Smoke smoke = (Smoke) e.Item;
            App.Locator.AddSmoke.SmokeModel = smoke;
            await Navigation.PushAsync(new AddSmokePage());
        }
    }
}

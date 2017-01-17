using System;
using System.Collections.Generic;
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

        private SmokeHistoryVM vm;
        public SmokeHistoryPage()
        {
            InitializeComponent();
            Title = "Smokes";
            BindingContext = vm = App.Locator.SmokeHistory;
            cigars = App.Database.GetAll<Cigar>().Result;
            
            if (!cigars.Any())
            {
                Cigar cigar = new Cigar();
                cigar.Name = "cigar1";
                cigars.Add(cigar);
                App.Database.Insert(cigar);
            }
        }

        protected async void AddSmokeTapped(object sender, EventArgs args)
        {
            //SmokeHistoryVM vm = (SmokeHistoryVM) BindingContext;
            //Smoke smoke = new Smoke();
            //smoke.Rating = DateTime.Now.Second % 10;
            //smoke.DateCreated = DateTime.Now;
            //smoke.Notes = "notes";
            //smoke.Cigar = cigars[0];

            //vm.SmokeCollection.Add(smoke);
            //await App.Database.Insert(smoke);
            await Navigation.PushAsync(new AddSmokePage());
        }

    }
}

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
            cigars = App.Database.GetAll<Cigar>();
            if(!cigars.Any()) throw new Exception("no cigars");
        }

        protected void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            //SmokeHistoryVM vm = (SmokeHistoryVM) BindingContext;
            Smoke smoke = new Smoke();
            smoke.Rating = DateTime.Now.Second % 10;
            smoke.DateCreated = DateTime.Now;
            smoke.Notes = "notes";
            smoke.Cigar = cigars[0];

            vm.SmokeCollection.Add(smoke);
            App.Database.Insert(smoke);
        }

    }
}

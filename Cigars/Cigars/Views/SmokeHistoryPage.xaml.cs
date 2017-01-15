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

        private SmokeHistoryVM vm;
        public SmokeHistoryPage()
        {
            InitializeComponent();
            Title = "Smokes";
            BindingContext = vm = App.Locator.SmokeHistory;
        }

        protected void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            //SmokeHistoryVM vm = (SmokeHistoryVM) BindingContext;
            Smoke smoke = new Smoke();
            smoke.Rating = 7.5;
            smoke.DateCreated = DateTime.Now;
            smoke.Notes = "notes";
            Cigar cigar = new Cigar();
            cigar.Name = "new cigar";
            smoke.Cigar = new Cigar();
            vm.SmokeCollection.Add(smoke);
            App.Database.Insert(smoke);
        }

    }
}

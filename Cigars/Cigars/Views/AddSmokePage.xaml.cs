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
    public partial class AddSmokePage : ContentPage
    {

        private AddSmokeVM _vm;

        public AddSmokePage(Smoke model)
        {
            BindingContext = _vm = App.Locator.AddSmoke;
            _vm.SmokeModel = model;
            InitializeComponent();
            Title = "Add Smoke";

            txtDuration.Text = "20";
            txtRating.Text = "7";
        }



    }
}

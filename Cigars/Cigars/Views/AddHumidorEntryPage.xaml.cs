using Cigars.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Models;
using Xamarin.Forms;

namespace Cigars.Views
{

    public partial class AddHumidorEntryPage : ContentPage
    {

        private AddHumidorEntryVM _vm;

        public AddHumidorEntryPage(HumidorEntryGroup model)
        {
            BindingContext = _vm = App.Locator.AddHumidorEntry;
            _vm.HumidorEntryGroupModel = model;
            InitializeComponent();
        }
    }
}

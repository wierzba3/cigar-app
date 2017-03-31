using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.ViewModels;
using Xamarin.Forms;

namespace Cigars.Views
{
    public partial class OverflowPage : ContentPage
    {

        private OverflowVM _vm;

        public OverflowPage()
        {
            BindingContext = _vm = App.Locator.Overflow;
            InitializeComponent();
            Title = "Other";
        }
    }
}

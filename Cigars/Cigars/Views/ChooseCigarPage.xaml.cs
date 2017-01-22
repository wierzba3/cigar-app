using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Common;
using Cigars.ViewModels;
using Xamarin.Forms;

namespace Cigars.Views
{
    public partial class ChooseCigarPage : ContentPage
    {

        private ChooseCigarVM _vm;

        public ChooseCigarPage(EventHandler<CigarChosenEventHandler> cigarChosenArg, EventHandler cancelArg)
        {
            InitializeComponent();
            BindingContext = _vm = App.Locator.ChooseCigar;
            _vm.CigarChosen = cigarChosenArg;
            _vm.Cancel = cancelArg;
        }
    }
}

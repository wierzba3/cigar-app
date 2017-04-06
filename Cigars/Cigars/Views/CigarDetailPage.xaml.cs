using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.ViewModels;
using Xamarin.Forms;

namespace Cigars.Views
{
    public partial class CigarDetailPage : ContentPage
    {

        private CigarDetailVM _vm;

        public CigarDetailPage()
        {
            BindingContext = _vm = App.Locator.CigarDetail;
            InitializeComponent();
        }
    }
}

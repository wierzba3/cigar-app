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
    public partial class CigarDetailPage : ContentPage
    {

        private CigarDetailVM _vm;

        public CigarDetailPage(Cigar cigar)
        {
            BindingContext = _vm = App.Locator.CigarDetail;
            InitializeComponent();
            if (cigar == null)
            {
                _vm.CigarName = "ERROR: Cigar not found.";
                return;
            }
            _vm.CigarName = cigar.Name ?? "<none>";
        }
    }
}

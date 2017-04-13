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
            _vm.CigarBrand = cigar.Brand == null ? "unknown" : cigar.Brand.Name ?? "unknown";
            _vm.ManufacturedIn = "?";
            _vm.Strength = "?";
            _vm.Length = "?";
            _vm.Color = "?";
            _vm.Shape = "?";
            _vm.RingGauge = "?";
        }
    }
}

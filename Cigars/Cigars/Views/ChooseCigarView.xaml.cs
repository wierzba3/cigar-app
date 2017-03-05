using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Common;
using Cigars.Models;
using Xamarin.Forms;

namespace Cigars.Views
{
    public partial class ChooseCigarView : ContentView
    {
        public ChooseCigarView()
        {
            InitializeComponent();
        }

        public Cigar Cigar { get; set; }

        protected void SelectCigarTapped(object sender, EventArgs args)
        {
            Navigation.PushAsync(new ChooseCigarPage(HandleCigarChosen, HandleChooseCigarCancel));
        }

        private void HandleCigarChosen(object sender, CigarChosenEventHandler e)
        {
            if (e.CigarObject == null) return;
            Cigar = e.CigarObject;
            txtChosenCigar.Text = Cigar.Name;
        }

        private void HandleChooseCigarCancel(object sender, EventArgs e)
        {
            //do nothing
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Models;
using Xamarin.Forms;

namespace Cigars.Views
{
    public partial class HumidorPage : ContentPage
    {
        public HumidorPage()
        {
            InitializeComponent();
            Title = "Humidor";
        }

        protected async void AddCigarTapped(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new AddSmokePage(new Smoke()));
        }

        protected void OnCigarSelection(object sender, SelectedItemChangedEventArgs e)
        {
            //disable the ability to select items
            ((ListView)sender).SelectedItem = null;
        }

        protected async void OnCigarTapped(object sender, ItemTappedEventArgs e)
        {
            //Smoke smoke = (Smoke)e.Item;
            //await Navigation.PushAsync(new AddSmokePage(smoke));
        }

    }
}

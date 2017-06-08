using Cigars.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cigars.Views
{
    public class TabPage : TabbedPage
    {

        public TabPage()
        {
            Children.Add(new SmokeHistoryPage());
            Children.Add(new HumidorPage());
            Children.Add(new ChooseCigarPage(HandleCigarChosen, HandleChooseCigarCancel));
        }

        private void HandleCigarChosen(object sender, CigarChosenEventHandler e)
        {
            if (e.CigarObject == null) return;
            App.Current.MainPage.Navigation.PushAsync(new CigarDetailPage(e.CigarObject));
        }

        private void HandleChooseCigarCancel(object sender, EventArgs e)
        {
            //do nothing
        }

    }
}

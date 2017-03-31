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
            Children.Add(new OverflowPage());
        }

    }
}

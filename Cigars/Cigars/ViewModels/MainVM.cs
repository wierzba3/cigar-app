using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cigars.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {

        private int clickCnt = 0;

        public MainVM()
        {
           MainText = "initial value";
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private string _mainText;

        public string MainText
        {
            get { return _mainText; }
            set
            {
                _mainText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MainText"));
            }
        }

        private void ButtonPressed()
        {
            MainText = "Clicked " + clickCnt + " times";
            clickCnt++;
        }

        private ICommand _btnCommand;
        public ICommand BtnCommand
        {
            get
            {
                _btnCommand = new Command(ButtonPressed);
                return _btnCommand;
            }
        }

    }
}

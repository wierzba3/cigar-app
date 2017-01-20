using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cigars.Models;
using Xamarin.Forms;

namespace Cigars.ViewModels
{
    public class AddSmokeVM : INotifyPropertyChanged
    {

        public AddSmokeVM()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private Smoke _smokeModel;

        public Smoke SmokeModel
        {
            get
            {
                return _smokeModel;
            }
            set
            {
                //TODO fill in input fields with Smokes values
                _smokeModel = value;
            }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                _saveCommand = new Command(async (t) =>
                {
                    List<Cigar> cigars = await App.Database.GetAll<Cigar>();
                    Cigar cigar;
                    if (!cigars.Any())
                    {
                        Cigar newCigar = new Cigar();
                        newCigar.Name = "cigar1";
                        cigars.Add(newCigar);
                        await App.Database.Insert(newCigar);
                        cigar = newCigar;
                    }
                    else cigar = cigars[0];

                    Smoke newSmoke = new Smoke()
                    {
                        Cigar = cigar,
                        Rating = 7.5,
                        Duration = 30,
                        DateCreated = DateTime.UtcNow,
                        DateModified = DateTime.UtcNow
                    };
                    
                    await App.Database.Insert(newSmoke);
                    await App.Locator.SmokeHistory.LoadSmokes();
                    await App.Current.MainPage.Navigation.PopAsync();
                });
            
                return _saveCommand;
            }
        }


        private ICommand _cancelCommand;

        public ICommand CancelCommand
        {
            get
            {
                return new Command(async (t) =>
                {
                    await App.Current.MainPage.Navigation.PopAsync();
                });
            }
        }

        private ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                return new Command(async (t) =>
                {
                    if (_smokeModel == null) return;
                    await App.Database.Delete<Smoke>(_smokeModel.SmokeId);
                    await App.Current.MainPage.Navigation.PopAsync();
                });
            }
        }
    }
}

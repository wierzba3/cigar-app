using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cigars.Common;
using Cigars.Models;
using Cigars.Views;
using Xamarin.Forms;

namespace Cigars.ViewModels
{
    public class AddSmokeVM : INotifyPropertyChanged
    {

        public AddSmokeVM()
        {
            if(SmokeModel == null) _smokeModel = new Smoke();
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
                _smokeModel = value;
                Rating = _smokeModel.Rating.ToString();
                Notes = _smokeModel.Notes;
                Duration = _smokeModel.Duration.ToString();
            }
        }

        private void HandleCigarChosen(object sender, CigarChosenEventHandler e)
        {
            Cigar cigar = e.CigarObject;
            ChosenCigarText = cigar.Name;
            _smokeModel.Cigar = cigar;
            App.Current.MainPage.Navigation.PopAsync();
        }

        private void HandleChooseCigarCancel(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        private ICommand _selectCigarCommand;

        public ICommand SelectCigarCommand
        {
            get
            {
                _selectCigarCommand = new Command(
                    async (t) =>
                    {
                        await App.Current.MainPage.Navigation.PushAsync(new ChooseCigarPage(HandleCigarChosen, HandleChooseCigarCancel));
                    });
                return _selectCigarCommand;
            }
        }

        private string _chosenCigarText;

        public string ChosenCigarText
        {
            get
            {
                return _chosenCigarText;
            }
            set
            {
                _chosenCigarText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ChosenCigarText"));
            }
        }


        private string _notes;

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Notes"));
            }
        }

        private string _duration;

        public string Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Duration"));
            }
        }

        private string _rating;

        public string Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Rating"));
            }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                _saveCommand = new Command(async (t) =>
                {
                    //List<Cigar> cigars = await App.Database.GetAll<Cigar>();
                    //Cigar cigar;
                    //if (!cigars.Any())
                    //{
                    //    Cigar newCigar = new Cigar();
                    //    newCigar.Name = "cigar1";
                    //    cigars.Add(newCigar);
                    //    await App.Database.Insert(newCigar);
                    //    cigar = newCigar;
                    //}
                    //else cigar = cigars[0];

                    double ratingValue;
                    int durationValue;
                    bool parsed = double.TryParse(Rating, out ratingValue);
                    //the input textbox is numeric only but perhaps I should report an error 
                    //in case the numeric restriction isn't recognized by some platform
                    if (!parsed) return;
                    parsed = int.TryParse(Duration, out durationValue);
                    if (!parsed) return;

                    Smoke newSmoke = new Smoke()
                    {
                        Cigar = _smokeModel.Cigar,
                        Rating = ratingValue,
                        Duration = durationValue,
                        Notes = Notes,
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

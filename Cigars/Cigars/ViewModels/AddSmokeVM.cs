using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;

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
            //if (SmokeModel == null) SmokeModel = new Smoke();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        
        public Smoke SmokeModel { get; set; }

        private void HandleCigarChosen(object sender, CigarChosenEventHandler e)
        {
            Cigar cigar = e.CigarObject;
            ChosenCigarText = cigar.Name;
            SmokeModel.Cigar = cigar;
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

        //private string _chosenCigarText;

        private string _chosenCigarText;
        public string ChosenCigarText
        {
            get { return _chosenCigarText; }
            set
            {
                _chosenCigarText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ChosenCigarText"));
            }
        }

        

        public string Notes
        {
            get { return SmokeModel.Notes; }
            set
            {
                SmokeModel.Notes = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Notes"));
            }
        }
        

        public string Duration
        {
            get { return SmokeModel.Duration == default(float) ? null : SmokeModel.Duration.ToString(); }
            set
            {
                SmokeModel.Duration = int.Parse(value);
                PropertyChanged(this, new PropertyChangedEventArgs("Duration"));
            }
        }
        

        public string Rating
        {
            get { return SmokeModel.Rating == default(float) ? null : SmokeModel.Rating.ToString(); }
            set
            {
                SmokeModel.Rating = int.Parse(value);
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

                    double ratingValue;
                    int durationValue;
                    bool parsed = double.TryParse(Rating, out ratingValue);
                    //the input textbox is numeric only but perhaps I should report an error 
                    //in case the numeric restriction isn't recognized by some platform
                    if (!parsed)
                    {
                        UserDialogs.Instance.ShowError("Enter a valid rating number.");
                        return;//TODO error
                    }

                    parsed = int.TryParse(Duration, out durationValue);
                    if (!parsed)
                    {
                        UserDialogs.Instance.ShowError("Enter a valid Duration integer.");
                        return; //TODO error
                    }
                    if (SmokeModel.Cigar == null)
                    {
                        UserDialogs.Instance.ShowError("Choose a cigar.");
                        return; //TODO error
                    }
                    Smoke newSmoke = new Smoke()
                    {
                        Rating = ratingValue,
                        Duration = durationValue,
                        Notes = Notes,
                        DateCreated = DateTime.UtcNow,
                        DateModified = DateTime.UtcNow
                    };

                    await App.Database.InsertWithChildren(newSmoke);
                    newSmoke.Cigar = SmokeModel.Cigar;
                    await App.Database.UpdateWithChildren(newSmoke);

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
                    if (SmokeModel == null) return;
                    ConfirmConfig config = new ConfirmConfig()
                    {
                        Message = "Delete this smoke record?",
                        OkText = "Delete",
                        CancelText = "Cancel"
                    };
                    bool deleteConfirmed = await UserDialogs.Instance.ConfirmAsync(config);
                    if (deleteConfirmed)
                    {
                        await App.Database.Delete<Smoke>(SmokeModel.SmokeId);
                        await App.Current.MainPage.Navigation.PopAsync();
                    }
                });
            }
        }
    }
}

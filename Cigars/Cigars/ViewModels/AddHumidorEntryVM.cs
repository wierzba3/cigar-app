using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using Cigars.Models;
using Xamarin.Forms;

namespace Cigars.ViewModels
{
    public class AddHumidorEntryVM : INotifyPropertyChanged
    {

        public AddHumidorEntryVM()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public HumidorEntryGroup HumidorEntryGroupModel { get; set; }


        public Cigar ChosenCigar
        {
            get { return HumidorEntryGroupModel.Cigar; }
            set
            {
                HumidorEntryGroupModel.Cigar = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ChosenCigar"));
            }
        }


        public string Quantity
        {
            get { return HumidorEntryGroupModel.Quantity.ToString(); }
            set
            {
                HumidorEntryGroupModel.Quantity = string.IsNullOrEmpty(value) ? 0 : int.Parse(value);
                PropertyChanged(this, new PropertyChangedEventArgs("Quantity"));
            }
        }

        private int _price;
        public string Price
        {
            get { return _price.ToString(); }
            set
            {

                _price = string.IsNullOrEmpty(value) ? 0 : int.Parse(value);
                PropertyChanged(this, new PropertyChangedEventArgs("Price"));
            }
        }

        private string _placeObtained;

        public string PlaceObtained
        {
            get { return _placeObtained; }
            set
            {
                _placeObtained = value;
                PropertyChanged(this, new PropertyChangedEventArgs("PlaceObtained"));
            }
        }

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                _saveCommand = new Command(async (t) =>
                {
                    try
                    {
                        if (ChosenCigar == null)
                        {
                            UserDialogs.Instance.ShowError("Choose a cigar.");
                            return;
                        }

                        if (HumidorEntryGroupModel.Quantity == 0)
                        {
                            UserDialogs.Instance.ShowError("Enter a quantity.");
                            return;
                        }

                        if (HumidorEntryGroupModel.IsNew)
                        {
                            for (int i = 0; i < HumidorEntryGroupModel.Quantity; i++)
                            {
                                HumidorEntry entry = new HumidorEntry();
                                entry.CigarId = HumidorEntryGroupModel.Cigar.CigarId;
                                entry.DateCreated = DateTime.UtcNow;
                                entry.DateModified = DateTime.UtcNow;
                                entry.HumidorId = HumidorEntryGroupModel.HumidorId;
                                await App.Database.Insert(entry);
                                
                                PlaceObtainedEntry placeObtainedEntry = new PlaceObtainedEntry();
                                placeObtainedEntry.CigarId = HumidorEntryGroupModel.Cigar.CigarId;
                                placeObtainedEntry.Place = PlaceObtained;
                                placeObtainedEntry.DateCreated = DateTime.UtcNow;
                                await App.Database.Insert(placeObtainedEntry);

                                PriceEntry priceEntry = new PriceEntry();
                                priceEntry.CigarId = HumidorEntryGroupModel.Cigar.CigarId;
                                priceEntry.Price = _price;
                                priceEntry.DateCreated = DateTime.UtcNow;
                                await App.Database.Insert(priceEntry);

                            }
                        }

                        var prices = await App.Database.GetAll<PriceEntry>();
                        var places = await App.Database.GetAll<PlaceObtainedEntry>();

                        await App.Current.MainPage.Navigation.PopAsync();
                    }
                    catch (Exception ex)
                    {
                        var msg = ex.Message;
                    }
                });
                return _saveCommand;
            }
        }
    }
}

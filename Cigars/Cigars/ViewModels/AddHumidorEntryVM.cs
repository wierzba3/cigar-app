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

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                _saveCommand = new Command(async (t) =>
                {
                    try
                    {
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
                            }
                        }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cigars.Database;
using Cigars.Models;
using Cigars.Views;
using GalaSoft.MvvmLight.Ioc;
using Xamarin.Forms;
/*
    TODO
    
    - AddHumidorEntryPage
        * add inputs: 
            - cigar
              created ChooseCigarView but the Cigar property won't bind to the ViewModel, throws exception
            - quantity
            - place obtained
            - price (if quantity > 1, display price/ea) 
              (hold off for now, need to decide on way to handle price for each entry)

    - SmokeHistoryPage
        * sort option
        * UI: improve item template
        * UI: improve "add smoke" layout

    - AddSmokePage
        * UI: improve it

    - HumidorPage
        * sort option
        * UI: improve item template
        * UI: improve "add cigar" template



    ISSUES
    - ACR user dialogs plugin crashes on android launch for api 23
*/
namespace Cigars
{
    public partial class App : Application
    {

        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());

        public App()
        {
            InitializeComponent();
            TabPage tabPage = new TabPage();
            NavigationPage navPage = new NavigationPage(tabPage);
            NavigationPage.SetHasNavigationBar(tabPage, false);
            MainPage = navPage;



            try
            {
                testDatabaseSetup();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static Database.Database database;

        public static Database.Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database.Database(DependencyService.Get<IFileHelper>().GetLocalFilePath("cigars.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void setupIOCContainer()
        {

        }

        private void testDatabaseSetup()
        {
            int retVal;


            retVal = Database.DeleteAll<Smoke>().Result;
            retVal = Database.DeleteAll<Cigar>().Result;
            Cigar cigar = new Cigar();
            cigar.Name = "Padron";
            Cigar cigar2 = new Cigar();
            cigar2.Name = "Churchill";
            Cigar cigar3 = new Cigar();
            cigar3.Name = "Montecristo";
            retVal = Database.Insert(cigar).Result;
            retVal = Database.Insert(cigar2).Result;
            retVal = Database.Insert(cigar3).Result;

            retVal = App.Database.DeleteAll<HumidorEntry>().Result;
            retVal = App.Database.DeleteAll<Humidor>().Result;

            Humidor humidor = new Humidor();
            humidor.DateCreated = humidor.DateModified = DateTime.UtcNow;
            humidor.Name = "Default";
            retVal = App.Database.Insert<Humidor>(humidor).Result;
            List<Humidor> humidors = App.Database.GetAll<Humidor>().Result;
            humidor = humidors[0];

            HumidorEntry entry = new HumidorEntry();
            entry.DateCreated = entry.DateModified = DateTime.UtcNow;
            entry.Price = 5.99m;
            entry.HumidorId = humidors[0].HumidorId;
            Cigar firstCigar = App.Database.GetAll<Cigar>().Result[0];
            entry.Cigar = cigar;
            App.Database.InsertWithChildren(entry);

            humidor.HumidorEntries = new List<HumidorEntry>{entry};
            App.Database.UpdateWithChildren(humidor);

            humidors = App.Database.GetAllWithChildren<Humidor>().Result;
            var humidorEntries = App.Database.GetAllWithChildren<HumidorEntry>().Result;
        }

    }
}

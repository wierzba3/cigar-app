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
    - Pre-load cigar data into db 
      (Decide on whether to store it in a normalized format with multiple types, or flat and denormalized

    - "Other" overflow page
        * add tools to it
            - browse cigars (DONE)
            - ...others?...
    
    - CigarDetailPage
        * Put cigar details on the page
        
    - HumidorPage
        * multiple humidors
        * UI: create design
        * 
    - AddHumidorEntryPage
        * UI: create design
        * 
    - SmokeHistoryPage
        * UI: create design
        * 
    - AddSmokePage
        * UI: create design
    

    MVP:
    - 

    All User Suggestions:
    - "Recommended pairings"
    - "Flavor wheel"
    - Multiple humidors
    - Online retailer integration
    - Option to suggest a cigar
    - Barcode scanner / OCR
    - Search for cigar (based on color, company, flavor)
    - Counter of how many times you've smoked a cigar (show this on the cigar detail page)
    - Online reivew/rating of cigars
    - Cloud backup

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

            Brand brand1 = new Brand();
            brand1.Name = "Brand1";
            Brand brand2 = new Brand();
            brand2.Name = "Brand2";
            retVal = Database.Insert(brand1).Result;
            retVal = Database.Insert(brand2).Result;

            retVal = Database.DeleteAll<Smoke>().Result;
            retVal = Database.DeleteAll<Cigar>().Result;
            Cigar cigar = new Cigar();
            cigar.Name = "Padron";
            cigar.Brand = brand1;
            Cigar cigar2 = new Cigar();
            cigar2.Name = "Churchill";
            cigar2.Brand = brand2;
            Cigar cigar3 = new Cigar();
            cigar3.Name = "Montecristo";
            cigar3.Brand = brand1;
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
            var cigars = App.Database.GetAll<Cigar>().Result;
            humidor.HumidorEntries = new List<HumidorEntry>();
            for (int i = 0; i < 20; i++)
            {
                HumidorEntry entry = new HumidorEntry();
                entry.DateCreated = entry.DateModified = DateTime.UtcNow.AddHours(i % 10);
                entry.Price = i % 10;
                entry.HumidorId = humidors[0].HumidorId;
                
                Cigar cigar4 = cigars[i % 3];
                entry.CigarId = cigar4.CigarId;
                App.Database.Insert(entry);
                humidor.HumidorEntries.Add(entry);
            }
            App.Database.UpdateWithChildren(humidor);


            humidors = App.Database.GetAllWithChildren<Humidor>().Result;
            var humidorEntries = App.Database.GetAllWithChildren<HumidorEntry>().Result;

            for (int i = 0; i < 10; i++)
            {
                Smoke smoke = new Smoke()
                {
                    CigarId = cigars[i % 3].CigarId,
                    DateCreated = DateTime.UtcNow.AddHours(i % 3),
                    DateModified = DateTime.UtcNow,
                    Duration = 10 * (i % 3),
                    Notes = "pretty good",
                    Rating = 5 + (i % 3)
                };
                App.Database.Insert(smoke);
            }
        }

    }
}

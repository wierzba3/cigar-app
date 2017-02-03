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
    - ACR user dialogs plugin crashes on android launch for api 23
    - start on humidor page, add a listview of humidor entries
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



            testDatabaseSetup();
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
        }

    }
}

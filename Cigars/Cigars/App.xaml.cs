﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cigars.Views;
using Xamarin.Forms;

namespace Cigars
{
    public partial class App : Application
    {

        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());

        public App()
        {
            InitializeComponent();

            MainPage = new TabPage();
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


    }
}

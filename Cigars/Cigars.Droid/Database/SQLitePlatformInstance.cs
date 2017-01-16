using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cigars.Database;
using Cigars.Droid.Database;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLitePlatformInstance))]
namespace Cigars.Droid.Database
{
    public class SQLitePlatformInstance : ISQLitePlatformInstance
    {

        public ISQLitePlatform GetSQLitePlatformInstance()
        {
            return new SQLitePlatformAndroid();
        }

    }
}
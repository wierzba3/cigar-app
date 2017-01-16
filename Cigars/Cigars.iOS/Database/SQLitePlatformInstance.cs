using Cigars.Database;
using Cigars.iOS.Database;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLitePlatformInstance))]
namespace Cigars.iOS.Database
{
    public class SQLitePlatformInstance : ISQLitePlatformInstance
    {

        public ISQLitePlatform GetSQLitePlatformInstance()
        {
            return new SQLitePlatformIOS();
        }

    }
}
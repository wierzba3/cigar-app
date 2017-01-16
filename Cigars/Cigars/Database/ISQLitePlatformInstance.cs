using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Interop;

namespace Cigars.Database
{
    public interface ISQLitePlatformInstance
    {
        ISQLitePlatform GetSQLitePlatformInstance();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Models;
using SQLite;
using SQLite.Net;
using SQLite.Net.Interop;
using Xamarin.Forms;

namespace Cigars.Database
{

    public class Database
    {
        private SQLiteConnection db;

        public Database(string path)
        {
            ISQLitePlatform platformInstance = DependencyService.Get<ISQLitePlatformInstance>().GetSQLitePlatformInstance();
            db = new SQLiteConnection(platformInstance, path);
            db.CreateTable<Cigar>();
            db.CreateTable<Smoke>();
        }

        public List<T> GetAll<T>() where T : class, new()
        {
            return db.Table<T>().ToList();
        }

        public int Insert<T>(T val) where T: class, new()
        {
            try
            {
                return db.Insert(val);
            }
            catch (Exception ex)
            {

                throw;
            }
        }



    }
}

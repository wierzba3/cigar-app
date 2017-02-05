using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Models;
using SQLite;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;
using SQLiteNetExtensionsAsync.Extensions;
using Xamarin.Forms;

namespace Cigars.Database
{

    public class Database
    {
        private SQLiteAsyncConnection db;

        public Database(string path)
        {
            ISQLitePlatform platformInstance = DependencyService.Get<ISQLitePlatformInstance>().GetSQLitePlatformInstance();
            //db = new SQLiteConnection(platformInstance, path);

            SQLiteConnectionString connectionString = new SQLiteConnectionString(path, true);
            var connectionFactory = new Func<SQLiteConnectionWithLock>(() => new SQLiteConnectionWithLock(platformInstance, connectionString));
            db = new SQLiteAsyncConnection(connectionFactory);
            db.CreateTableAsync<Cigar>();
            db.CreateTableAsync<Smoke>();
            db.CreateTableAsync<HumidorEntry>();
            db.CreateTableAsync<Humidor>();
        }

        public Task<List<T>> GetAll<T>() where T : class, new()
        {
            return db.Table<T>().ToListAsync();
        }

        public Task<List<T>> GetAllWithChildren<T>() where T : class, new()
        {
            return db.GetAllWithChildrenAsync<T>();
        }

        public Task<int> Insert<T>(T val) where T: class, new()
        {
            return db.InsertAsync(val);
        }

        public Task InsertWithChildren<T>(T val) where T : class, new()
        {
            return db.InsertWithChildrenAsync(val);
        }

        public Task<int> Delete<T>(object pk) where T: class, new()
        {
            return db.DeleteAsync<T>(pk);
        }

        public Task<int> DeleteAll<T>() where T : class, new()
        {
            return db.DeleteAllAsync<T>();
        }

        public Task UpdateWithChildren<T>(T val) where T : class, new()
        {
            return db.UpdateWithChildrenAsync(val);
        }


    }
}

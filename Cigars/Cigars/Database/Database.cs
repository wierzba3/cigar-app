using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cigars.Models;
using SQLite;

namespace Cigars.Database
{



    public class Database
    {
        private SQLiteConnection db;

        public Database(string path)
        {
            db = new SQLiteConnection(path);
            db.CreateTable<Cigar>();
            db.CreateTable<Smoke>();
        }

        public List<T> GetAll<T>() where T : class, new()
        {
            return db.Table<T>().ToList();
        }

        public void Insert<T>(T val) where T: class, new()
        {
            db.Insert(val);
        }

    }
}

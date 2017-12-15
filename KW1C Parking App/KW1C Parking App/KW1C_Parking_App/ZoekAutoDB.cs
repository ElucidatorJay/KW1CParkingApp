using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace KW1C_Parking_App
{
   public  class ZoekAutoDB
    {
        static object locker = new object();
        SQLiteConnection dbconn;

        public ZoekAutoDB()
        {
            dbconn = DependencyService.Get<ISQLite>().GetConnection();
            // create the tables
            dbconn.CreateTable<clLocatie>();
        }

        public IEnumerable<clLocatie> GetItems()
        {
            lock (locker)
            {
                return (from i in dbconn.Table<clLocatie>() select i).ToList();
            }
        }

        public clLocatie GetItem(int id)
        {
            lock (locker)
            {
                return dbconn.Table<clLocatie>().FirstOrDefault(x => x.ID == id); ;
            }
        }

        public int GetAantalTabel(string tabel)
        {
            lock (locker)
            {
                return dbconn.ExecuteScalar<int>("SELECT COUNT(*) FROM [" + tabel + "]");
            }
        }

        public int SaveItem(clLocatie item)
        {
            lock (locker)
            {   
                if (item.ID == 1 )
                {
                    dbconn.Update(item);
                    return item.ID;
                }
                else
                {
                    item.ID = 1;
                    return dbconn.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return dbconn.Delete<clLocatie>(id);
            }
        }

    }
}

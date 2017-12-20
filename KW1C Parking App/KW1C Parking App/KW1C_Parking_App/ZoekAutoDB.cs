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
            //ophalen van connectiestring
            dbconn = DependencyService.Get<ISQLite>().GetConnection();
            // aanmaken van de tabel in database
            dbconn.CreateTable<clLocatie>();
        }

        //ophalen van de GPS locatie
        public clLocatie GetItem(int id)
        {
            lock (locker)
            {
                return dbconn.Table<clLocatie>().FirstOrDefault(x => x.ID == id); ;
            }
        }


        //opslaan van de GPS locatie
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

        //verwijderen van de GPS locatie
        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return dbconn.Delete<clLocatie>(id);
            }
        }

    }
}

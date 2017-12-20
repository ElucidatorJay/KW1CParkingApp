using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace KW1C_Parking_App
{
    public interface ISQLite
    {
   
        //ophalen van de connectiestring voor de sqlite database
        SQLiteConnection GetConnection();
    }
}

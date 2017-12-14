using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace KW1C_Parking_App
{
    public interface ISQLite
    {
        //alleen deze method is specifiek per platform
        SQLiteConnection GetConnection();
    }
}

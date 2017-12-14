using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KW1C_Parking_App
{
   public class clLocatie
    {
        private int _ID;
        private string _Longitude;
        private string _Latitude;
        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get { return _ID; }

            set { _ID = value; }
        }
        public string Longitude
        {
            get { return _Longitude; }

            set { _Longitude = value; }
        }
        public string Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }

    }
}

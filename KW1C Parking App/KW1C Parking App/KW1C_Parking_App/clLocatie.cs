using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KW1C_Parking_App
{
   public class clLocatie
    {
        [PrimaryKey]

        public int ID { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}

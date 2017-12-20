using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KW1C_Parking_App
{
   public class clLocatie
    {
        //class voor de breedtegraad en lengtegraad van de GPS locatie deze wordt omgezet in een tabel met sqlite
        [PrimaryKey]

        public int ID { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}

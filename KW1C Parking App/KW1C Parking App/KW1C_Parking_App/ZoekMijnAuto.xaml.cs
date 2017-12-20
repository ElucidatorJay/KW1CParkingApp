using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator;

namespace KW1C_Parking_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ZoekMijnAuto : ContentPage
	{
       // clLocatie Location = new clLocatie();
        private string Longitude;
        private string Latitude;

        public ZoekMijnAuto ()
		{
			InitializeComponent ();
            //ophalen van een opgeslagen lcoatie
            PinLocation();


        }
        private async void btnGetLocation_Clicked(object sender, EventArgs e)
        {
            //wissen van een locatie
            App.Db.DeleteItem(1);
            MyMap.Pins.Clear();

        }

        private async void btnSavetLocation_Clicked(object sender, EventArgs e)
        {
            //opvragen huidige locatie
            await RetreiveLocation();
            //setten van locatie in de class
            var Location = new clLocatie()
            {
                Longitude = Longitude,
                Latitude = Latitude,
            };

            //opslaan van locatie
            App.Db.SaveItem(Location);

            //aanmaken van een marker op de kaart
            var pin = new Pin()
            {
                Position = new Position(Convert.ToDouble(Location.Latitude), Convert.ToDouble(Location.Longitude)),
                Label = "Geparkeerde Auto"
            };
            // toevoegen van marker
            MyMap.Pins.Add(pin);
        }


        private async Task RetreiveLocation()
        {
            //opvragen van locatie met een minimale preciesheid van 20 meter
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            TimeSpan ts = TimeSpan.FromTicks(100000);
            var position = await locator.GetPositionAsync(ts);

            txtLat.Text = "Latitude: " + position.Latitude.ToString();
            txtLong.Text = "Longitude: " + position.Longitude.ToString();

           //breedte en lengtegraad uitschrijven in variable
           Longitude = position.Longitude.ToString();
          Latitude = position.Latitude.ToString();
            

            //kaart inzoomen op huidige locatie.

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude)
                             , Distance.FromMiles(0.1)));
        }

        private void PinLocation()
        {
            //aanmaken van een nieuw object
            clLocatie locatie2 = new clLocatie();
            //ophalen van een object in de database
            locatie2 = App.Db.GetItem(1);

            //controleren of er al een locatie is opgelsagen
            if (locatie2 != null)
            {
                //maken van marker voor opgelsagen locatie
                var pin = new Pin()
                {
                    Position = new Position(Convert.ToDouble(locatie2.Latitude), Convert.ToDouble(locatie2.Longitude)),
                    Label = "Geparkeerde Auto"
                };

                //marker toevoegen aan kaart
                MyMap.Pins.Add(pin);

                //kaart inzoomen op opgeslagen locatie.
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(locatie2.Latitude), Convert.ToDouble(locatie2.Longitude))
                             , Distance.FromMiles(0.1)));

            }
            else
            {
                //kaart openen op parkeeerplaats van school.
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(51.697816, 5.303675)
                           , Distance.FromMiles(2)));

            }

        }

        


    }
}
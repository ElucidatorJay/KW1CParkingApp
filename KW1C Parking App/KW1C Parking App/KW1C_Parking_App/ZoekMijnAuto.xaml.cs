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
            PinLocation();


        }
        private async void btnGetLocation_Clicked(object sender, EventArgs e)
        {
            App.Db.DeleteItem(1);
            MyMap.Pins.Clear();

        }

        private async void btnSavetLocation_Clicked(object sender, EventArgs e)
        {
            await RetreiveLocation();

            var Location = new clLocatie()
            {
                Longitude = Longitude,
                Latitude = Latitude,
            };


            App.Db.SaveItem(Location);

            var pin = new Pin()
            {
                Position = new Position(Convert.ToDouble(Location.Latitude), Convert.ToDouble(Location.Longitude)),
                Label = "Geparkeerde Auto"
            };

            MyMap.Pins.Add(pin);
        }

        private async Task RetreiveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            TimeSpan ts = TimeSpan.FromTicks(100000);
            var position = await locator.GetPositionAsync(ts);

            txtLat.Text = "Latitude: " + position.Latitude.ToString();
            txtLong.Text = "Longitude: " + position.Longitude.ToString();

           
           Longitude = position.Longitude.ToString();
          Latitude = position.Latitude.ToString();
            



            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude)
                             , Distance.FromMiles(0.1)));
        }

        private void PinLocation()
        {

            int test = App.Db.GetAantalTabel("clLocatie");
            clLocatie locatie2 = new clLocatie();
            locatie2 = App.Db.GetItem(1);

            if (locatie2 != null)
            {
                var pin = new Pin()
                {
                    Position = new Position(Convert.ToDouble(locatie2.Latitude), Convert.ToDouble(locatie2.Longitude)),
                    Label = "Geparkeerde Auto"
                };

                MyMap.Pins.Add(pin);

                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Convert.ToDouble(locatie2.Latitude), Convert.ToDouble(locatie2.Longitude))
                             , Distance.FromMiles(0.1)));

            }
            else
            {
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(51.697816, 5.303675)
                           , Distance.FromMiles(2)));

            }

        }

        private void DeletePosition()
        {
            App.Db.DeleteItem(1);
        }


    }
}
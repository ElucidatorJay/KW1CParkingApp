using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		public ZoekMijnAuto ()
		{
			InitializeComponent ();
            RetreiveLocation();
           
        }
        private async void BtnGetLocation_Clicked(object sender, EventArgs e)
        {
            await RetreiveLocation();
        }

        private async Task RetreiveLocation()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 20;
            TimeSpan ts = TimeSpan.FromTicks(100000);
            var position = await locator.GetPositionAsync(ts);

            txtLat.Text = "Latitude: " + position.Latitude.ToString();
            txtLong.Text = "Longitude: " + position.Longitude.ToString();

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude)
                             , Distance.FromMiles(1)));
        }
    }
}
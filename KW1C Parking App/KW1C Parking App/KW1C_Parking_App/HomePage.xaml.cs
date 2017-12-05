using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KW1C_Parking_App
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
		}
        private void OpenTijden(object sender, EventArgs e)
        {
            //Resultaatscherm wordt geopend met de feedback data
            Navigation.PushModalAsync(new Openingstijden());
            
        }
        private void OpenZoekAuto(object sender, EventArgs e)
        {
            //Resultaatscherm wordt geopend met de feedback data
            Navigation.PushModalAsync(new ZoekMijnAuto());
        
        }
    }
}
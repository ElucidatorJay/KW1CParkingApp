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
			InitializeComponent();
		}
        private void OpenTijden(object sender, EventArgs e)
        {
            //navigatie naar pagina voor openingstijden
            Navigation.PushModalAsync(new Openingstijden());
            
        }
        private void OpenZoekAuto(object sender, EventArgs e)
        {
            //navigatie naar pagina voor zoek mijn auto
            Navigation.PushModalAsync(new ZoekMijnAuto());

            
        
        }
        private void OpenParkeerplaatsen(object sender, EventArgs e)
        {
            //navigatie naar pagina voor beschikbare parkeerplaatsen
            Navigation.PushModalAsync(new BeschikbarePakeerplaatsen());

        }
    }
}
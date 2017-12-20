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
	public partial class BeschikbarePakeerplaatsen : ContentPage
	{
        private string Locatie;
		public BeschikbarePakeerplaatsen ()
		{
			InitializeComponent ();
            //kleur van picker
            piLocatie.TextColor = Color.White;
            //visible van plaatje en de label
            ftAuto.IsVisible = false;
            lbText.IsVisible = false;
            
		}

        private void piLocatie_SelectedIndexChanged(object sender, EventArgs e)
        {
            //controleren wel item er is gekozen in de picker
            Locatie = piLocatie.SelectedItem.ToString();

            if(Locatie == "Onderwijsboulevard")
            {
                //aantal vaststellen en visible van plaatje en label op true zetten
                lbAantal.Text = "154";
                ftAuto.IsVisible = true;
                lbText.IsVisible = true;
            }
            if (Locatie == "Vlijmenseweg")
            {
                //aantal vaststellen en visible van plaatje en label op true zetten
                lbAantal.Text = "100";
                ftAuto.IsVisible = true;
                lbText.IsVisible = true;
            }

        }



    }
}
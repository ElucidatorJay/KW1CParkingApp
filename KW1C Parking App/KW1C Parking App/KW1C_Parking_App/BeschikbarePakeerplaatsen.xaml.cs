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
            piLocatie.TextColor = Color.White;
            ftAuto.IsVisible = false;
            lbText.IsVisible = false;
            
		}

        private void piLocatie_SelectedIndexChanged(object sender, EventArgs e)
        {
            Locatie = piLocatie.SelectedItem.ToString();

            if(Locatie == "Onderwijsboulevard")
            {
                lbAantal.Text = "154";
                ftAuto.IsVisible = true;
                lbText.IsVisible = true;
            }
            if (Locatie == "Vlijmenseweg")
            {
                lbAantal.Text = "100";
                ftAuto.IsVisible = true;
                lbText.IsVisible = true;
            }

        }



    }
}
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
	public partial class Openingstijden : ContentPage
	{
        private string Locatie;
        public Openingstijden ()
		{
			InitializeComponent ();
            piLocatie.TextColor = Color.White;
            grTijd.IsVisible = false;
        }

        private void grTijd_SelectedIndexChanged(object sender, EventArgs e)
        {
            Locatie = piLocatie.SelectedItem.ToString();

            if (Locatie == "Onderwijsboulevard")
            {
                grTijd.IsVisible = true;
                tdMaandag.Text = "08:00 tot 17:00";
                tdDinsdag.Text = "08:00 tot 16:30";
                tdWoensdag.Text = "08:00 tot 17:30";
                tdDonderdag.Text = "08:00 tot 17:00";
                tdVrijdag.Text = "08:00 tot 16:00";

            }
            if (Locatie == "Vlijmenseweg")
            {
                grTijd.IsVisible = true;
                tdMaandag.Text = "08:00 tot 17:30";
                tdDinsdag.Text = "08:00 tot 18:00";
                tdWoensdag.Text = "08:00 tot 17:00";
                tdDonderdag.Text = "08:00 tot 13:00";
                tdVrijdag.Text = "08:00 tot 17:00";
                
            }

        }
    }
}
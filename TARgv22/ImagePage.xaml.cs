using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        Switch sw;
        Image img;
        public ImagePage()
        {
            img = new Image { Source = "test.jpg" };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            tap.NumberOfTapsRequired = 2;
            img.GestureRecognizers.Add(tap);
            sw = new Switch
            {
                IsToggled = true,
                VerticalOptions=LayoutOptions.EndAndExpand,
                HorizontalOptions=LayoutOptions.Center
            };
            sw.Toggled += Sw_Toggled;
            this.Content = new StackLayout { Children = { img, sw } };
        }
        int tapid;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            tapid++;
            var imagesender = (Image)sender;
            if (tapid % 2 == 0)
            {
                img.Source = "bob.jpg";
            }
            else
            {
                img.Source = "test.jpg";
            }
        }

        private void Sw_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                img.IsVisible = true;
            }
            else
            {
                img.IsVisible = false;
            }
        }
    }
}
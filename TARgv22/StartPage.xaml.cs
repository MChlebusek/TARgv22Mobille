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
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            Button Ent_btn = new Button
            {
                Text ="Entry page",
                BackgroundColor = Color.MediumPurple
            };

            Button Time_btn = new Button
            {
                Text = "Timer page",
                BackgroundColor = Color.MediumPurple
            };
            Button BoxView_btn = new Button
            {
                Text = "BoxView page",
                BackgroundColor = Color.MediumPurple
            };

            StackLayout st = new StackLayout
            {
                Children = {Ent_btn, Time_btn, BoxView_btn },
                BackgroundColor = Color.LavenderBlush
            };
            Content = st;
            Ent_btn.Clicked += Ent_btn_Clicked;
            Time_btn.Clicked += Time_btn_Clicked;
            BoxView_btn.Clicked += BoxView_btn_Clicked;
        }
        private async void BoxView_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BoxViewPage());
        }
        private async void Time_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }
        private async void Ent_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryPage());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntryPage : ContentPage
    {
        Label label, label2;
        Editor editor;
        public EntryPage()
        {
            editor = new Editor
            {
                Placeholder = "Sisesta siia tekst",
                BackgroundColor=Color.AntiqueWhite,
                TextColor= Color.MediumPurple
            };
            //editor.TextChanged += Editor_TextChanged;
            label = new Label
            {
                Text = "Pealkiri",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.AntiqueWhite,
                BackgroundColor = Color.MediumPurple
            };
            label2 = new Label
            {
                Text = Preferences.Get("key2", "Ei ole veel"),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.AntiqueWhite,
                BackgroundColor = Color.MediumPurple
            };

            Button b = new Button
            {
                Text = "To Start Page",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            b.Clicked += B_Clicked;
            Button c = new Button
            {
                Text ="Salvesta omadus",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions= LayoutOptions.Center,
            };
            c.Clicked += Salvesta_Omadus;
            Button d = new Button
            {
                Text = "Salvesta Preferences",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            d.Clicked += Salvesta_Preferences;

            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = {label, editor, b, c, d, label2},
                BackgroundColor= Color.Lavender,
            };
            Content = st;
        }

        private void Salvesta_Preferences(object sender, EventArgs e)
        {
            string value2 = editor.Text;
            Preferences.Set("key2", value2);
            label2.Text = value2;
        }

        private void Salvesta_Omadus(object sender, EventArgs e)
        {
            string value = editor.Text;
            App.Current.Properties.Remove("key");
            App.Current.Properties.Add("key", value);
            label.Text = (string)App.Current.Properties["key"];
        }
        protected override void OnAppearing()
        {
            object key = "";
            if (App.Current.Properties.TryGetValue("key", out key))
            {
                label.Text = (string)App.Current.Properties["key"];
            }
            base.OnAppearing();
        }

        //int i = 0;
        //private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    // Получаем текст из Editor
        //    string text = e.NewTextValue ?? string.Empty;

        //    // Подсчитываем количество букв 'A' в тексте
        //    i = text.Count(c => c == 'A');

        //    // Обновляем счетчик в label
        //    label.Text = "A: " + i.ToString();
        //}


        private async void B_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
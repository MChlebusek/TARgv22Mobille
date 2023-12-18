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
    public partial class PickerPage : ContentPage
    {
        Picker myPicker;
        WebView myWebView;
        StackLayout myStackLayout;
        Frame myFrame;
        string[] myLehed = new string[4] { "https://moodle.edu.ee", "https://www.tthk.ee/", "https://tahvel.edu.ee/#/", "https://thk.edupage.org/timetable/view.php?fullscreen=1" };

        Entry addressEntry;
        Button homeButton;
        Button backButton;
        Button saveButton;

        public PickerPage() : base()
        {
            InitializeComponent();

            myPicker = new Picker
            {
                Title = "Lehed"
            };
            myPicker.Items.Add("Moodle");
            myPicker.Items.Add("TTHK");
            myPicker.Items.Add("Tahvel");
            myPicker.Items.Add("Tunniplan");
            myPicker.SelectedIndexChanged += MyPicker_SelectedIndexChanged;

            myWebView = new WebView();
            myFrame = new Frame
            {
                BorderColor = Color.Red,
                BackgroundColor = Color.Green
            };

            myStackLayout = new StackLayout { Children = { myPicker, myFrame } };
            Content = myStackLayout;

            addressEntry = new Entry
            {
                Placeholder = "Sisestage URL",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            addressEntry.Completed += AddressEntry_Completed;

            homeButton = new Button
            {
                Text = "Koju"
            };
            homeButton.Clicked += HomeButton_Clicked;

            backButton = new Button
            {
                Text = "Tagasi"
            };
            backButton.Clicked += BackButton_Clicked;

            saveButton = new Button
            {
                Text = "Salvesta leht",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            saveButton.Clicked += SaveButton_Clicked;

            myStackLayout.Children.Add(addressEntry);
            myStackLayout.Children.Add(homeButton);
            myStackLayout.Children.Add(backButton);
            myStackLayout.Children.Add(saveButton);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadSavedPage();
        }

        private void MyPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedPage();
        }

        private void LoadSavedPage()
        {
            string savedPage = Preferences.Get("savedPage", string.Empty);

            if (!string.IsNullOrWhiteSpace(savedPage))
            {
                myPicker.SelectedIndex = Array.IndexOf(myLehed, savedPage);
                myWebView.Source = new UrlWebViewSource { Url = savedPage };
                myStackLayout.Children.Add(myWebView);
            }
        }

        private void LoadSelectedPage()
        {
            if (myWebView != null)
            {
                myStackLayout.Children.Remove(myWebView);
            }
            myWebView = new WebView
            {
                Source = new UrlWebViewSource { Url = myLehed[myPicker.SelectedIndex] },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            myStackLayout.Children.Add(myWebView);
        }

        private void AddressEntry_Completed(object sender, EventArgs e)
        {
            string enteredUrl = addressEntry.Text;
            if (!string.IsNullOrWhiteSpace(enteredUrl))
            {
                myWebView.Source = new UrlWebViewSource { Url = enteredUrl };
                myStackLayout.Children.Add(myWebView);
            }
        }

        private async void HomeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StartPage1());
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            // Реализация кнопки "Back" по вашей логике
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("savedPage", myLehed[myPicker.SelectedIndex]);
        }
    }
}

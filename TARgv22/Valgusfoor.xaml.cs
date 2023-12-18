using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace TARgv22
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor : ContentPage
    {
        private bool isTrafficLightOn = false;
        private Frame redCircle, yellowCircle, greenCircle;
        private Label statusLabel;
        private Label redLabel, yellowLabel, greenLabel;
        private Button lopetaTooButton;

        public Valgusfoor()
        {


            Label titleLabel = new Label
            {
                Text = "Valgusfoor",
                FontSize = 24,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 20, 0, 0)
            };


            redCircle = CreateCircle( Color.Gray);
            yellowCircle = CreateCircle(Color.Gray);
            greenCircle = CreateCircle(Color.Gray);


            statusLabel = new Label 
            {
                Text = "Kõigepealt lülita valgusfoor sisse",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 20, 0, 0)
            };


            Button sisseButton = new Button
            {
                Text = "Sisse",
                FontSize = 18,
                Margin = new Thickness(0, 20, 0, 0)
            };
            sisseButton.Clicked += OnSisseClicked;

            Button valjaButton = new Button
            {
                Text = "Välja",
                FontSize = 18,
                Margin = new Thickness(0, 20, 0, 0)
            };
            valjaButton.Clicked += OnValjaClicked;
            Button tooButton = new Button
            {
                Text = "Töö",
                FontSize = 18,
                Margin = new Thickness(0, 20, 0, 0)
            };
            tooButton.Clicked += OnTooButtonClicked;
            lopetaTooButton = new Button
            {
                Text = "Lõp.töö",
                FontSize = 18,
                Margin = new Thickness(0, 20, 0, 0)
            };
            lopetaTooButton.Clicked += OnLopetaTooClicked;
            redLabel = new Label
            {
                Text = "Punane(Seisa)",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 5, 0, 0)
            };

            yellowLabel = new Label
            {
                Text = "Kollane(Valmistu liikuma)",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 5, 0, 0)
            };

            greenLabel = new Label
            {
                Text = "Roheline(Sõida)",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 5, 0, 0)
            };


            Content = new StackLayout
            {
                Children = {
                titleLabel,
                redCircle,
                redLabel,
                yellowCircle,
                yellowLabel,
                greenCircle,
                greenLabel,
                statusLabel,
                new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { sisseButton, valjaButton, tooButton, lopetaTooButton }
                }
            },
                Padding = new Thickness(20)
            };
        }
    

        private Xamarin.Forms.Frame CreateCircle(Color color)
        {
            return new Xamarin.Forms.Frame
            {
                WidthRequest = 100,
                HeightRequest = 100,
                CornerRadius = 50,
                BackgroundColor = color,
                GestureRecognizers = {
            new TapGestureRecognizer {
                Command = new Command(() => OnCircleClicked(color))
            }
        },
                Margin = new Thickness(0, 10, 0, 10)
            };
        }

        private void OnCircleClicked(Color color)
        {
            if (isTrafficLightOn)
            {
                string message = GetTrafficLightMessage(color);
                statusLabel.Text = message; 
            }
            else
            {
                statusLabel.Text = "Kõigepealt lülita valgusfoor sisse"; 
            }
        }

        private string GetTrafficLightMessage(Color color)
        {
            if (color == Color.Red)
            {
                return "Seisa";
            }
            else if (color == Color.Yellow)
            {
                return "Valmistu liikuma";
            }
            else if (color == Color.Green)
            {
                return "Sõida";
            }
            else
            {
                return "";
            }
        }

        private void OnSisseClicked(object sender, EventArgs e)
        {
            isTrafficLightOn = true;
            redCircle.BackgroundColor = Color.Red;
            yellowCircle.BackgroundColor = Color.Yellow;
            greenCircle.BackgroundColor = Color.Green;
            statusLabel.Text = "Valgusfoor on sisse lülitatud"; 
        }

        private void OnValjaClicked(object sender, EventArgs e)
        {
            isTrafficLightOn = false;
            redCircle.BackgroundColor = Color.Gray;
            yellowCircle.BackgroundColor = Color.Gray;
            greenCircle.BackgroundColor = Color.Gray;
            statusLabel.Text = "Valgusfoor on välja lülitatud"; 
        }
        private async void OnTooButtonClicked(object sender, EventArgs e) //включает цвета по очереди, бесконечный цикл
        {
            while (isTrafficLightOn)
            {
                redCircle.BackgroundColor = Color.Gray;
                yellowCircle.BackgroundColor = Color.Gray;
                greenCircle.BackgroundColor = Color.Gray;

                await Task.Delay(1000);

                redCircle.BackgroundColor = Color.Red;

                await Task.Delay(2000);

                redCircle.BackgroundColor = Color.Gray;
                yellowCircle.BackgroundColor = Color.Yellow;

                await Task.Delay(2000);

                yellowCircle.BackgroundColor = Color.Gray;

                greenCircle.BackgroundColor = Color.Green;
                await Task.Delay(1000);
            }

            redCircle.BackgroundColor = Color.Gray;
            yellowCircle.BackgroundColor = Color.Gray;
            greenCircle.BackgroundColor = Color.Gray;
        }

        private void OnLopetaTooClicked(object sender, EventArgs e) // при нажатии завершает повтор программы 
        {
            isTrafficLightOn = false;
        }
    }
}

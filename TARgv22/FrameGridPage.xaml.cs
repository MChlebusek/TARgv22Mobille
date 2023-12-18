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
    public partial class FrameGridPage : ContentPage
    {
        Grid grid;
        Random rnd;

        public FrameGridPage()
        {
            rnd = new Random();

            grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(1, GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(2, GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(3, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1, GridUnitType.Star)},
                }
            };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Frame frame = new Frame
                    {
                        BorderColor = Color.White,
                        CornerRadius = 10,
                        BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255))
                    };

                    
                    frame.GestureRecognizers.Add(new TapGestureRecognizer
                    {
                        Command = new Command(() =>
                        {
                            frame.BackgroundColor = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                        })
                    });

                    grid.Children.Add(frame, i, j);
                }
            }

            Content = grid;
        }
    }
}

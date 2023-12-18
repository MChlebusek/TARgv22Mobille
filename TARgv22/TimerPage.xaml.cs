using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        private Stopwatch stopwatch;

        public TimerPage()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
        }

        private async void btn_tagasi_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                Device.StartTimer(TimeSpan.FromSeconds(1), UpdateTimer);
                timer_start.Text = "Stop";
            }
            else
            {
                stopwatch.Stop();
                timer_start.Text = "Start";
            }
        }

        private bool UpdateTimer()
        {
            if (stopwatch.IsRunning)
            {
                long elapsedSeconds = stopwatch.ElapsedMilliseconds / 1000;
                timer_value.Text = elapsedSeconds.ToString();
            }

            return true; 
        }
    }
}
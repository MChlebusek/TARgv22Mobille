using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;
using Xamarin.Forms.Xaml;

namespace TARgv22
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoxViewPage : ContentPage
    {
        private int clickCount;
        private Random random;

        public BoxViewPage()
        {
            InitializeComponent();
            clickCount = 0;
            random = new Random();
        }

        private void OnBoxViewTapped(object sender, EventArgs e)
        {
            // Генерируем случайный цвет
            Color randomColor = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
            myBoxView.Color = randomColor;

            // Увеличиваем счетчик нажатий и обновляем текст над квадратом
            clickCount++;
            clickCountLabel.Text = $"Click Count: {clickCount}";
        }
    }
}
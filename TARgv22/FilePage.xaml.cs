using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TARgv22
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilePage : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public FilePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateFileList();
        }
        private void UpdateFileList()
        {
            filesList.ItemsSource = Directory.GetFiles(folderPath).Select(f => Path.GetFileName(f));
            filesList.SelectedItem = null;
        }

        private void filesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            string filename = (string)e.SelectedItem;
            textEditor.Text = File.ReadAllText(Path.Combine(folderPath, (string)e.SelectedItem));
            fileNameEntry.Text = filename;
            filesList.SelectedItem = null;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string filename = fileNameEntry.Text;
            if (String.IsNullOrEmpty(filename)) return;
            if (File.Exists(Path.Combine(folderPath, filename)))
            {
                bool isRewrited = await DisplayAlert("Kinnitus", "Fail on juba olemas, Kas salvestada ümber?", "Jah", "Ei");
            }
            File.WriteAllText(Path.Combine(folderPath, filename), textEditor.Text);
            UpdateFileList();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            string fileName = (string)((MenuItem)sender).BindingContext;
            File.Delete(Path.Combine(folderPath, fileName));
            UpdateFileList();
        }

        private void ToList_Clicked(object sender, EventArgs e)
        {
            string fileName = (string)((MenuItem)sender).BindingContext;
            List<string> järjend = File.ReadLines(Path.Combine(folderPath, fileName)).ToList();
            list.ItemsSource = järjend;
        }
    }
}
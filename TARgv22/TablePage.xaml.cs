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
    public partial class TablePage : ContentPage
    {
        TableView tableView;
        SwitchCell switchCell;
        ImageCell imageCell;
        TableSection fotosection;
        EntryCell phoneEntryCell;
        EntryCell emailEntryCell;
        EntryCell messageEntryCell;
        Label statusLabel; 

        public TablePage()
        {
            fotosection = new TableSection();

            switchCell = new SwitchCell { Text = "Näita veel..." };
            switchCell.OnChanged += SwitchCell_OnChanged;

            imageCell = new ImageCell { Text = " Foto: ", ImageSource = "test.jpg", Detail = "Kirjeldus" };

            phoneEntryCell = new EntryCell
            {
                Label = "Telefon: ",
                Placeholder = "Kirjuta telefoni nr. ",
                Keyboard = Keyboard.Telephone
            };

            emailEntryCell = new EntryCell
            {
                Label = "Email: ",
                Placeholder = "Siia tuleb Email",
                Keyboard = Keyboard.Email
            };

            messageEntryCell = new EntryCell
            {
                Label = "Sõnum: ",
                Placeholder = "Sisestage sõnum siia"
            };

            statusLabel = new Label 
            {
                TextColor = Color.Green, 
                HorizontalOptions = LayoutOptions.Center 
            };

            tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmed: ")
                {
                    new TableSection("Põhiandmed: ")
                    {
                        new EntryCell
                        {
                            Label = "Nimi: ",
                            Placeholder="Siia tuleb nimi",
                            Keyboard=Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandmed: ")
                    {
                       phoneEntryCell,
                       emailEntryCell,
                       switchCell
                    },
                    new TableSection("Sõnumi saatmine: ")
                    {
                        messageEntryCell,
                        new ViewCell
                        {
                            View = new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Children =
                                {
                                    new Button
                                    {
                                        Text = "HELISTA",
                                        Command = new Command(() =>
                                        {
                                            if (!string.IsNullOrWhiteSpace(phoneEntryCell.Text))
                                            {
                                                //PhoneDialer.Open(phoneEntryCell.Text);
                                            }
                                        })
                                    },
                                    new Button
                                    {
                                        Text = "SAADA SMS",
                                        Command = new Command(async () =>
                                        {
                                            if (!string.IsNullOrWhiteSpace(phoneEntryCell.Text))
                                            {
                                                await DisplayAlert("Sõnum", $"Sõnum saadetud {phoneEntryCell.Text}-le:\n {messageEntryCell.Text}", "OK");
                                                statusLabel.Text = $"Sõnum saadetud {phoneEntryCell.Text}"; // Устанавливаем текст статуса отправки сообщения
                                            }
                                        })
                                    },
                                    new Button
                                    {
                                        Text = "SAADA EMAIL",
                                        Command = new Command(async () =>
                                        {
                                            if (!string.IsNullOrWhiteSpace(emailEntryCell.Text))
                                            {
                                                await DisplayAlert("Email", $"Email saadetud aadressile {emailEntryCell.Text}:\n {messageEntryCell.Text}", "OK");
                                                statusLabel.Text = $"Email saadetud aadressile {emailEntryCell.Text}"; // Устанавливаем текст статуса отправки сообщения
                                            }
                                        })
                                    }
                                }
                            }
                        }
                    },
                    fotosection
                }
            };

            var mainLayout = new StackLayout // Основной контейнер страницы
            {
                Children = { tableView, statusLabel }, // Добавляем таблицу и метку со статусом
                VerticalOptions = LayoutOptions.FillAndExpand // Растягиваем содержимое по вертикали
            };

            Content = mainLayout; // Устанавливаем основной контейнер в качестве содержимого страницы
        }

        private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                fotosection.Title = "Foto: ";
                fotosection.Add(imageCell);
                switchCell.Text = "Peida";
            }
            else
            {
                fotosection.Title = "";
                fotosection.Remove(imageCell);
                switchCell.Text = "Näita veel...";
            }
        }
    }
}

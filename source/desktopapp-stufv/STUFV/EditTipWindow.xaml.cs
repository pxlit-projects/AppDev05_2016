using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace STUFV
{
    /// <summary>
    /// Interaction logic for EditTipWindow.xaml
    /// </summary>
    public partial class EditTipWindow : Window
    {
        HttpClient client = new HttpClient();
        private Tip tip;
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;

        public EditTipWindow(Tip tip)
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://webapp-stufv20160527104738.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.tip = tip;
            tipTextBox.Text = tip.TipText;

            this.Closing += EditTipWindow_Closing;
        }

        private async Task<bool> UpdateTip(Tip tip)
        {
            processLabel.Content = "Bezig met verwerken...";

            try
            {
                var tipUrl = "/api/tip/" + tip.Id;
                HttpResponseMessage response = await client.PutAsJsonAsync(tipUrl, tip);

                if (response.IsSuccessStatusCode)
                {
                    
                    MessageBox.Show("Tip succesvol aangepast!");
                    processLabel.Content = "";
                    return true;
                }
                else
                {
                    processLabel.Content = "";
                    return false;
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw. U zal worden doorverwezen naar het loginscherm.",
                    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginWindow window = new LoginWindow();
                window.Show();
                Close();
                scherm.Close();
            }
            return false;
        }

       

        private async Task<bool> CheckClose()
        {
            if (tip.TipText!= tipTextBox.Text)
            {
                MessageBoxResult result = MessageBox.Show("Wijzigingen opslaan?",
                    "Sluit venster", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);

                if (result == MessageBoxResult.Yes)
                {
                    tip.TipText = tipTextBox.Text;
                    return await UpdateTip(tip);
                }
                else if (result == MessageBoxResult.No)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private async void SaveTipButton_Click(object sender, RoutedEventArgs e)
        {
            if (tip.TipText != tipTextBox.Text)
            {
                tip.TipText = tipTextBox.Text;
                await UpdateTip(tip);
            }
        }

        private async void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (await CheckClose())
            {
                Close();
            }
        }

        private async void EditTipWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (await CheckClose())
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}

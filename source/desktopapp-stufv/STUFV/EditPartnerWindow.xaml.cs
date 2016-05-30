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
    /// Interaction logic for EditPartnerWindow.xaml
    /// </summary>
    public partial class EditPartnerWindow : Window
    {
        Partner partner;
        HttpClient client = new HttpClient();
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        public EditPartnerWindow(Partner partner)
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://webapp-stufv20160527104738.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            this.partner = partner;
            partnerPanel.DataContext = partner;
        }

        private async Task<bool> UpdatePartner(Partner partner)
        {
            processLabel.Content = "Bezig met verwerken...";

            try
            {
                var partnerUrl = "/api/partner/" + partner.Id;
                HttpResponseMessage response = await client.PutAsJsonAsync(partnerUrl, partner);

                if (response.IsSuccessStatusCode)
                {
                   
                    MessageBox.Show("Partner succesvol aangepast!");
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
            if (partner.Name != NaamBox.Text || partner.Image != ImageBox.Text || partner.URL != UrlBox.Text)
            {
                MessageBoxResult result = MessageBox.Show("Wijzigingen opslaan?",
                    "Sluit venster", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation);

                if (result == MessageBoxResult.Yes)
                {
                    partner.Name = NaamBox.Text;
                    partner.Image = ImageBox.Text;
                    partner.URL = UrlBox.Text;
                    return await UpdatePartner(partner);
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

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (partner.Name != NaamBox.Text || partner.Image != ImageBox.Text || partner.URL != UrlBox.Text)
            {
                partner.Name = NaamBox.Text;
                partner.Image = ImageBox.Text;
                partner.URL = UrlBox.Text;
                await UpdatePartner(partner);
            }
        }

        private async void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (await CheckClose())
            {
                Close();
            }
        }

        private async void EditPartnerWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

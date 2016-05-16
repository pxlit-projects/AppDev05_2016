using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STUFV
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        HttpClient client = new HttpClient();
        private int aantalOrganisaties = 0;
        private int aantalReviews = 0;

        public HomePage()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            GetAantalNieuweOrganisaties();
            GetAantalNieuweReviews();

            organisationLabel.Text = "Momenteel zijn er " + aantalOrganisaties + " organisaties \ndie zich willen registeren.\n" 
               + "Je kan ze wel of niet toelaten \nin de \"Nieuwe organisaties\" \ntab of door te klikken op \nbovenstaande afbeelding.";

            reviewLabel.Text = "Momenteel zijn er " + aantalReviews + " reviews \ndie geflagged zijn.\n"
               + "Je kan ze wel of niet toelaten \nin de \"Controle op reviews\" \ntab of door te klikken op \nbovenstaande afbeelding.";
            
            menuBox.SelectionChanged += MenuBox_SelectionChanged;
        }

        private void MenuBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = menuBox.SelectedIndex;

            switch (index)
            {
                case 0:
                    scherm.displayFrame.Source = new Uri("HomePage.xaml", UriKind.Relative);
                    break;
                case 1:
                    scherm.displayFrame.Source = new Uri("ArticlePage.xaml", UriKind.Relative);
                    break;
                case 2:
                    scherm.displayFrame.Source = new Uri("NewOrganisationPage.xaml", UriKind.Relative);
                    break;
                case 3:
                    scherm.displayFrame.Source = new Uri("ReviewsPage.xaml", UriKind.Relative);
                    break;
                case 4:
                    scherm.displayFrame.Source = new Uri("UsersPage.xaml", UriKind.Relative);
                    break;
                case 5:
                    scherm.displayFrame.Source = new Uri("ManageOrganisationPage.xaml", UriKind.Relative);
                    break;
                case 6:
                    scherm.displayFrame.Source = new Uri("ManageEventPage.xaml", UriKind.Relative);
                    break;
                case 7:
                    scherm.displayFrame.Source = new Uri("ManageArticlePage.xaml", UriKind.Relative);
                    break;
                case 8:
                    scherm.displayFrame.Source = new Uri("ManageLoginPage.xaml", UriKind.Relative);
                    break;
                case 9:
                    scherm.displayFrame.Source = new Uri("StatsPage.xaml", UriKind.Relative);
                    break;
                case 10:
                    scherm.displayFrame.Source = new Uri("LogoutPage.xaml", UriKind.Relative);
                    break;
            }
        }
        // Swap pages when any button is pressed.
        private void Article_Click(object sender, RoutedEventArgs e)
        {
            scherm.displayFrame.Source = new Uri("ArticlePage.xaml", UriKind.Relative);
        }

        private void Organisation_Click(object sender, RoutedEventArgs e)
        {
            scherm.displayFrame.Source = new Uri("NewOrganisationPage.xaml", UriKind.Relative);
        }

        private void Review_Click(object sender, RoutedEventArgs e)
        {
            scherm.displayFrame.Source = new Uri("ReviewsPage.xaml", UriKind.Relative);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            try {
                Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
                e.Handled = true;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw. U zal worden doorverwezen naar het loginscherm.",
                    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginWindow window = new LoginWindow();
                window.Show();
                scherm.Close();
            }
        }

        private async void GetAantalNieuweOrganisaties()
        {
            try {
                var organisationUrl = "/api/organisations";
                HttpResponseMessage response = await client.GetAsync(organisationUrl);
                IEnumerable<Organisation> organisations = null;
                if (response.IsSuccessStatusCode)
                {
                    organisations = await response.Content.ReadAsAsync<IEnumerable<Organisation>>();
                }

                int teller = 0;
                foreach (Organisation organisation in organisations)
                {
                    if (organisation.isRegistered == false)
                    {
                        teller++;
                    }
                }
                aantalOrganisaties = teller;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw. U zal worden doorverwezen naar het loginscherm.",
                    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginWindow window = new LoginWindow();
                window.Show();
                scherm.Close();
            }
        }

        private async void GetAantalNieuweReviews()
        {
            try {
                var reviewUrl = "/api/reviews";
                HttpResponseMessage response = await client.GetAsync(reviewUrl);
                IEnumerable<Review> reviews = null;
                if (response.IsSuccessStatusCode)
                {
                    reviews = await response.Content.ReadAsAsync<IEnumerable<Review>>();
                }

                int teller = 0;
                if (reviews != null)
                {
                    foreach (Review review in reviews)
                    {
                        teller++;
                    }
                }
                aantalReviews = teller;
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw. U zal worden doorverwezen naar het loginscherm.",
                    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginWindow window = new LoginWindow();
                window.Show();
                scherm.Close();
            }
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace STUFV
{
    /// <summary>
    /// Interaction logic for StatistiekenPage.xaml
    /// </summary>
    public partial class StatsPage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        HttpClient client = new HttpClient();

        public StatsPage()
        {
            InitializeComponent();
            menuBox.SelectionChanged += MenuBox_SelectionChanged;

            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
                    scherm.displayFrame.Source = new Uri("NewEventPage.xaml", UriKind.Relative);
                    break;
                case 4:
                    scherm.displayFrame.Source = new Uri("ReviewsPage.xaml", UriKind.Relative);
                    break;
                case 5:
                    scherm.displayFrame.Source = new Uri("UsersPage.xaml", UriKind.Relative);
                    break;
                case 6:
                    scherm.displayFrame.Source = new Uri("ManageOrganisationPage.xaml", UriKind.Relative);
                    break;
                case 7:
                    scherm.displayFrame.Source = new Uri("ManageEventPage.xaml", UriKind.Relative);
                    break;
                case 8:
                    scherm.displayFrame.Source = new Uri("ManageArticlePage.xaml", UriKind.Relative);
                    break;
                case 9:
                    scherm.displayFrame.Source = new Uri("ManageLoginPage.xaml", UriKind.Relative);
                    break;
                case 10:
                    scherm.displayFrame.Source = new Uri("StatsPage.xaml", UriKind.Relative);
                    break;
                case 11:
                    scherm.displayFrame.Source = new Uri("LogoutPage.xaml", UriKind.Relative);
                    break;
            }
        }

        public async void loadAllStats(object sender, RoutedEventArgs e)
        {
            IEnumerable < Review > reviews = await GetReviews();
            IEnumerable < User > users = await GetUsers();
            IEnumerable < Organisation > organisations = await GetOrganisations();
            IEnumerable < Event > events = await GetEvents();
            IEnumerable < Article > articles = await getArticles();
            int reviewCount = reviews.ToList().Count();
            int userCount = users.ToList().Count();
            int organisationCount = organisations.ToList().Count();
            int eventCount = events.ToList().Count();
            int articleCount = articles.ToList().Count();
            userLabel.Content = userCount.ToString();
            organisationLabel.Content = organisationCount.ToString();
            reviewLabel.Content = reviewCount.ToString();
            eventLabel.Content = eventCount.ToString();
            artikelLabel.Content = articleCount.ToString();
        }

        public async Task<IEnumerable<Article>> getArticles()
        {
            IEnumerable<Article> articles = null;

            try
            {
                var articleUrl = "/api/article";
                HttpResponseMessage response = await client.GetAsync(articleUrl);

                if (response.IsSuccessStatusCode)
                {
                    articles = await response.Content.ReadAsAsync<IEnumerable<Article>>();
                }
            }
            catch(HttpRequestException)
            {
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw. U zal worden doorverwezen naar het loginscherm.",
    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginWindow window = new LoginWindow();
                window.Show();
                scherm.Close();
            }
            return articles;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> users = null;
            
            try
            {
                var userUrl = "/api/user";
                HttpResponseMessage response = await client.GetAsync(userUrl);

                if (response.IsSuccessStatusCode)
                {
                    users = await response.Content.ReadAsAsync<IEnumerable<User>>();
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw. U zal worden doorverwezen naar het loginscherm.",
                    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginWindow window = new LoginWindow();
                window.Show();
                scherm.Close();
            }
            return users;
        }

        public async Task<IEnumerable<Review>> GetReviews()
        {
            IEnumerable<Review> reviews = null;
            try
            {
                var reviewUrl = "/api/review";
                HttpResponseMessage response = await client.GetAsync(reviewUrl);

                if (response.IsSuccessStatusCode)
                {
                    reviews = await response.Content.ReadAsAsync<IEnumerable<Review>>();
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw. U zal worden doorverwezen naar het loginscherm.",
                    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginWindow window = new LoginWindow();
                window.Show();
                scherm.Close();
            }
            return reviews;
        }

        public async Task<IEnumerable<Organisation>> GetOrganisations()
        {
            IEnumerable<Organisation> organisations = null;
            try
            {
                var organisationUrl = "/api/organisations";
                HttpResponseMessage response = await client.GetAsync(organisationUrl);

                if (response.IsSuccessStatusCode)
                {
                    organisations = await response.Content.ReadAsAsync<IEnumerable<Organisation>>();
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw. U zal worden doorverwezen naar het loginscherm.",
                    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginWindow window = new LoginWindow();
                window.Show();
                scherm.Close();
            }
            return organisations;
        }

        private async Task<IEnumerable<Event>> GetEvents()
        {
            IEnumerable<Event> events = null;
            List<Event> relatedEvents = new List<Event>();
            try
            {
                var eventUrl = "/api/event";
                HttpResponseMessage response = await client.GetAsync(eventUrl);

                if (response.IsSuccessStatusCode)
                {
                    events = await response.Content.ReadAsAsync<IEnumerable<Event>>();
                    foreach (Event orgEvent in events)
                    {
                        if (orgEvent.Handled == true)
                        {
                            relatedEvents.Add(orgEvent);
                        }
                    }
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw. U zal worden doorverwezen naar het loginscherm.",
                    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
                LoginWindow window = new LoginWindow();
                window.Show();
                scherm.Close();
            }
            return relatedEvents;
        }
    }
}

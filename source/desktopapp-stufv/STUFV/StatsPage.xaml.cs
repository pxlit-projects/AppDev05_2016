using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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
        List<Review> reviews;
        List<User> users;
        List<Organisation> organisations;
        List<Event> events;
        List<Login> logins;

        public StatsPage()
        {
            InitializeComponent();
            menuBox.SelectionChanged += MenuBox_SelectionChanged;

            client.BaseAddress = new Uri("http://localhost:54238/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<string> filterItems = new List<string> { "Aantal gebruikers", "Aantal organisaties", "Aantal evenementen",
                "Aantal reviews", "Aantal logins" };

            filterBox.ItemsSource = filterItems;

            List<string> timeItems = new List<string> { "Vandaag", "Gisteren", "Deze week", "Vorige week","Deze maand",
                "Vorige maand", "Dit jaar","Vorig jaar", "Afgelopen 10 jaar" };

            timeBox.ItemsSource = timeItems;
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
                    scherm.displayFrame.Source = new Uri("TipPage.xaml", UriKind.Relative);
                    break;
                case 3:
                    scherm.displayFrame.Source = new Uri("NewOrganisationPage.xaml", UriKind.Relative);
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
                    scherm.displayFrame.Source = new Uri("ManagePartnerPage.xaml", UriKind.Relative);
                    break;
                case 11:
                    scherm.displayFrame.Source = new Uri("ManageTipPage.xaml", UriKind.Relative);
                    break;
                case 12:
                    scherm.displayFrame.Source = new Uri("StatsPage.xaml", UriKind.Relative);
                    break;
                case 13:
                    scherm.displayFrame.Source = new Uri("LogoutPage.xaml", UriKind.Relative);
                    break;
            }
        }

        public async void loadAllStats(object sender, RoutedEventArgs e)
        {
            IEnumerable<Review> reviews = await GetReviews();
            IEnumerable<User> users = await GetUsers();
            IEnumerable<Organisation> organisations = await GetOrganisations();
            IEnumerable<Event> events = await GetEvents();
            IEnumerable<Article> articles = await getArticles();
            IEnumerable<Login> logins = await GetLogins();
            this.reviews = reviews.ToList();
            this.users = users.ToList();
            this.organisations = organisations.ToList();
            this.events = events.ToList();
            this.logins = logins.ToList();
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

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string filter = filterBox.SelectedValue.ToString();

            string time = timeBox.SelectedValue.ToString();

            if (filter != "" && time != "")
            {
                CreateGraph(time);
            }
        }

        public void CreateGraph(string time)
        {
            string timeText = "";
            switch (time)
            {
                case "Vandaag":
                    break;
                case "Gisteren":
                    break;
                case "Deze week":
                    break;
                case "Vorige week":
                    break;
                case "Deze maand":
                    break;
                case "Vorige maand":
                    break;
                case "Dit jaar":
                    break;
                case "Vorig jaar":
                    break;
                case "Afgelopen 10 jaar":
                    break;
            }

            List<KeyValuePair<string, int>> listKeys = listKeys = new List<KeyValuePair<string, int>>();
            DateTime currentHour = DateTime.Now.AddHours(-DateTime.Now.Hour);

            for (int i = 0; i <= DateTime.Now.Hour; i++)
            {
                int counter = 0;
                foreach (var login in logins)
                {
                    if (login.DateTime.Hour == currentHour.Hour && 
                        login.DateTime.ToShortDateString() == DateTime.Now.ToShortDateString())
                    {
                        counter++;
                    }
                }
                listKeys.Add(new KeyValuePair<string, int>(currentHour.ToString("HH:00"), counter));
                currentHour = currentHour.AddHours(1);
            }

            titleSeries.Title = "Aantal logins per uur";
            ((LineSeries)chart.Series[0]).ItemsSource = listKeys;
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
            catch (HttpRequestException)
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
            List<Organisation> relatedOrganisations = new List<Organisation>();
            try
            {
                var organisationUrl = "/api/organisations";
                HttpResponseMessage response = await client.GetAsync(organisationUrl);

                if (response.IsSuccessStatusCode)
                {
                    organisations = await response.Content.ReadAsAsync<IEnumerable<Organisation>>();
                    foreach (Organisation organisation in organisations)
                    {
                        if (organisation.isRegistered == true)
                        {
                            relatedOrganisations.Add(organisation);
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
            return relatedOrganisations;
        }

        private async Task<IEnumerable<Event>> GetEvents()
        {
            IEnumerable<Event> events = null;
            try
            {
                var eventUrl = "/api/event";
                HttpResponseMessage response = await client.GetAsync(eventUrl);

                if (response.IsSuccessStatusCode)
                {
                    events = await response.Content.ReadAsAsync<IEnumerable<Event>>();
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
            return events;
        }

        public async Task<IEnumerable<Login>> GetLogins()
        {
            IEnumerable<Login> logins = null;
            try
            {
                var loginUrl = "/api/login";
                HttpResponseMessage response = await client.GetAsync(loginUrl);

                if (response.IsSuccessStatusCode)
                {
                    logins = await response.Content.ReadAsAsync<IEnumerable<Login>>();
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
            return logins;
        }
    }
}

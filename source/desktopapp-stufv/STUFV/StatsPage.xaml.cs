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
                    scherm.displayFrame.Source = new Uri("ManagePartnerPage.xaml", UriKind.Relative);
                    break;
                case 10:
                    scherm.displayFrame.Source = new Uri("ManageTipPage.xaml", UriKind.Relative);
                    break;
                case 11:
                    scherm.displayFrame.Source = new Uri("ManageLoginPage.xaml", UriKind.Relative);
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
            string filter = "";
            string time = "";

            try
            {
                filter = filterBox.SelectedValue.ToString();
                time = timeBox.SelectedValue.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Enkele waarden ontbreken!");
            }

            if (filter != "" && time != "")
            {
                CreateGraph(filter, time);
            }
        }

        public void CreateGraph(string filter,string time)
        {
            List<KeyValuePair<string, int>> listKeys = listKeys = new List<KeyValuePair<string, int>>();
            switch (time)
            {
                case "Vandaag":
                    DateTime currentHour = DateTime.Now.AddHours(-DateTime.Now.Hour);

                    switch (filter)
                    {
                        case "Aantal gebruikers":
                            for (int i = 0; i <= DateTime.Now.Hour; i++)
                            {
                                int counter = 0;

                                foreach (var user in users)
                                {
                                    if (Convert.ToDateTime(user.RegisterDate).Hour == currentHour.Hour &&
                                        Convert.ToDateTime(user.RegisterDate).ToShortDateString() == DateTime.Now.ToShortDateString())
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(currentHour.ToString("HH:00"), counter));
                                currentHour = currentHour.AddHours(1);
                            }
                            titleSeries.Title = "Aantal gebruikers vandaag";
                            break;
                        case "Aantal organisaties":
                            for (int i = 0; i <= DateTime.Now.Hour; i++)
                            {
                                int counter = 0;

                                foreach (var organisation in organisations)
                                {
                                    if (Convert.ToDateTime(organisation.RegisterDate).Hour == currentHour.Hour &&
                                        Convert.ToDateTime(organisation.RegisterDate).ToShortDateString() == DateTime.Now.ToShortDateString())
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(currentHour.ToString("HH:00"), counter));
                                currentHour = currentHour.AddHours(1);
                            }
                            titleSeries.Title = "Aantal organisaties vandaag";
                            break;
                        case "Aantal evenementen":
                            for (int i = 0; i <= DateTime.Now.Hour; i++)
                            {
                                int counter = 0;

                                foreach (var orgEvent in events)
                                {
                                    if (Convert.ToDateTime(orgEvent.RegisterDate).Hour == currentHour.Hour &&
                                        Convert.ToDateTime(orgEvent.RegisterDate).ToShortDateString() == DateTime.Now.ToShortDateString())
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(currentHour.ToString("HH:00"), counter));
                                currentHour = currentHour.AddHours(1);
                            }
                            titleSeries.Title = "Aantal evenementen vandaag";
                            break;
                        case "Aantal reviews":
                            for (int i = 0; i <= DateTime.Now.Hour; i++)
                            {
                                int counter = 0;

                                foreach (var review in reviews)
                                {
                                    if (Convert.ToDateTime(review.DateTime).Hour == currentHour.Hour &&
                                        Convert.ToDateTime(review.DateTime).ToShortDateString() == DateTime.Now.ToShortDateString())
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(currentHour.ToString("HH:00"), counter));
                                currentHour = currentHour.AddHours(1);
                            }
                            titleSeries.Title = "Aantal reviews vandaag";
                            break;
                        case "Aantal logins":
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
                            titleSeries.Title = "Aantal logins vandaag";
                            break;
                    }
                    
                    break;
                case "Gisteren":
                    DateTime yesterdayHour = DateTime.Now.AddDays(-1).AddHours(-DateTime.Now.Hour);

                    switch (filter)
                    {
                        case "Aantal gebruikers":
                            for (int i = 0; i < 24; i++)
                            {
                                int counter = 0;

                                foreach (var user in users)
                                {
                                    if (Convert.ToDateTime(user.RegisterDate).Hour == yesterdayHour.Hour &&
                                        Convert.ToDateTime(user.RegisterDate).ToShortDateString() == DateTime.Now.AddDays(-1).ToShortDateString())
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(yesterdayHour.ToString("HH:00"), counter));
                                yesterdayHour = yesterdayHour.AddHours(1);
                            }
                            titleSeries.Title = "Aantal gebruikers gisteren";
                            break;
                        case "Aantal organisaties":
                            for (int i = 0; i < 24; i++)
                            {
                                int counter = 0;

                                foreach (var organisation in organisations)
                                {
                                    if (Convert.ToDateTime(organisation.RegisterDate).Hour == yesterdayHour.Hour &&
                                        Convert.ToDateTime(organisation.RegisterDate).ToShortDateString() == DateTime.Now.AddDays(-1).ToShortDateString())
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(yesterdayHour.ToString("HH:00"), counter));
                                yesterdayHour = yesterdayHour.AddHours(1);
                            }
                            titleSeries.Title = "Aantal organisaties gisteren";
                            break;
                        case "Aantal evenementen":
                            for (int i = 0; i < 24; i++)
                            {
                                int counter = 0;

                                foreach (var orgEvent in events)
                                {
                                    if (Convert.ToDateTime(orgEvent.RegisterDate).Hour == yesterdayHour.Hour &&
                                        Convert.ToDateTime(orgEvent.RegisterDate).ToShortDateString() == DateTime.Now.AddDays(-1).ToShortDateString())
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(yesterdayHour.ToString("HH:00"), counter));
                                yesterdayHour = yesterdayHour.AddHours(1);
                            }
                            titleSeries.Title = "Aantal evenementen gisteren";
                            break;
                        case "Aantal reviews":
                            for (int i = 0; i < 24; i++)
                            {
                                int counter = 0;

                                foreach (var review in reviews)
                                {
                                    if (Convert.ToDateTime(review.DateTime).Hour == yesterdayHour.Hour &&
                                        Convert.ToDateTime(review.DateTime).ToShortDateString() == DateTime.Now.AddDays(-1).ToShortDateString())
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(yesterdayHour.ToString("HH:00"), counter));
                                yesterdayHour = yesterdayHour.AddHours(1);
                            }
                            titleSeries.Title = "Aantal reviews gisteren";
                            break;
                        case "Aantal logins":
                            for (int i = 0; i < 24; i++)
                            {
                                int counter = 0;

                                foreach (var login in logins)
                                {
                                    if (login.DateTime.Hour == yesterdayHour.Hour &&
                                        login.DateTime.ToShortDateString() == DateTime.Now.AddDays(-1).ToShortDateString())
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(yesterdayHour.ToString("HH:00"), counter));
                                yesterdayHour = yesterdayHour.AddHours(1);
                            }
                            titleSeries.Title = "Aantal logins gisteren";
                            break;
                    }
                    break;
                case "Deze week":
                    DateTime currentDayWeek = DateTime.Now.AddDays(-(Convert.ToInt32(DateTime.Now.DayOfWeek))+1);

                    switch (filter)
                    {
                        case "Aantal gebruikers":
                            for (int i = 0; i <= Convert.ToInt32(DateTime.Now.DayOfWeek)-1; i++)
                            {
                                int counter = 0;

                                foreach (var user in users)
                                {
                                    if (Convert.ToDateTime(user.RegisterDate).DayOfWeek == currentDayWeek.DayOfWeek &&
                                        Convert.ToDateTime(user.RegisterDate) <= DateTime.Now &&
                                        Convert.ToDateTime(user.RegisterDate) >= DateTime.Now.AddDays(-(Convert.ToInt32(DateTime.Now.DayOfWeek)) + 1) &&
                                        Convert.ToDateTime(user.RegisterDate).Month == DateTime.Now.Month &&
                                        Convert.ToDateTime(user.RegisterDate).Year == DateTime.Now.Year)
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(currentDayWeek.ToString("dddd"), counter));
                                currentDayWeek = currentDayWeek.AddDays(1);
                            }
                            titleSeries.Title = "Aantal gebruikers deze week";
                            break;
                        case "Aantal organisaties":
                            for (int i = 0; i <= Convert.ToInt32(DateTime.Now.DayOfWeek) - 1; i++)
                            {
                                int counter = 0;

                                foreach (var organisation in organisations)
                                {
                                    if (Convert.ToDateTime(organisation.RegisterDate).DayOfWeek == currentDayWeek.DayOfWeek &&
                                        Convert.ToDateTime(organisation.RegisterDate) <= DateTime.Now &&
                                        Convert.ToDateTime(organisation.RegisterDate) >= DateTime.Now.AddDays(-(Convert.ToInt32(DateTime.Now.DayOfWeek)) + 1) &&
                                        Convert.ToDateTime(organisation.RegisterDate).Month == DateTime.Now.Month &&
                                        Convert.ToDateTime(organisation.RegisterDate).Year == DateTime.Now.Year)
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(currentDayWeek.ToString("dddd"), counter));
                                currentDayWeek = currentDayWeek.AddDays(1);
                            }
                            titleSeries.Title = "Aantal organisaties deze week";
                            break;
                        case "Aantal evenementen":
                            for (int i = 0; i <= Convert.ToInt32(DateTime.Now.DayOfWeek) - 1; i++)
                            {
                                int counter = 0;

                                foreach (var orgEvent in events)
                                {
                                    if (Convert.ToDateTime(orgEvent.RegisterDate).DayOfWeek == currentDayWeek.DayOfWeek &&
                                        Convert.ToDateTime(orgEvent.RegisterDate) <= DateTime.Now &&
                                        Convert.ToDateTime(orgEvent.RegisterDate) >= DateTime.Now.AddDays(-(Convert.ToInt32(DateTime.Now.DayOfWeek)) + 1) &&
                                        Convert.ToDateTime(orgEvent.RegisterDate).Month == DateTime.Now.Month &&
                                        Convert.ToDateTime(orgEvent.RegisterDate).Year == DateTime.Now.Year)
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(currentDayWeek.ToString("dddd"), counter));
                                currentDayWeek = currentDayWeek.AddDays(1);
                            }
                            titleSeries.Title = "Aantal evenementen deze week";
                            break;
                        case "Aantal reviews":
                            for (int i = 0; i <= Convert.ToInt32(DateTime.Now.DayOfWeek) - 1; i++)
                            {
                                int counter = 0;

                                foreach (var review in reviews)
                                {
                                    if (Convert.ToDateTime(review.DateTime).DayOfWeek == currentDayWeek.DayOfWeek &&
                                        Convert.ToDateTime(review.DateTime) <= DateTime.Now &&
                                        Convert.ToDateTime(review.DateTime) >= DateTime.Now.AddDays(-(Convert.ToInt32(DateTime.Now.DayOfWeek)) + 1) &&
                                        Convert.ToDateTime(review.DateTime).Month == DateTime.Now.Month &&
                                        Convert.ToDateTime(review.DateTime).Year == DateTime.Now.Year)
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(currentDayWeek.ToString("dddd"), counter));
                                currentDayWeek = currentDayWeek.AddDays(1);
                            }
                            titleSeries.Title = "Aantal reviews deze week";
                            break;
                        case "Aantal logins":
                            for (int i = 0; i <= Convert.ToInt32(DateTime.Now.DayOfWeek) - 1; i++)
                            {
                                int counter = 0;

                                foreach (var login in logins)
                                {
                                    if (login.DateTime.DayOfWeek == currentDayWeek.DayOfWeek &&
                                        login.DateTime <= DateTime.Now &&
                                        login.DateTime >= DateTime.Now.AddDays(-(Convert.ToInt32(DateTime.Now.DayOfWeek)) + 1) &&
                                        login.DateTime.Month == DateTime.Now.Month &&
                                        login.DateTime.Year == DateTime.Now.Year)
                                    {
                                        counter++;
                                    }
                                }
                                listKeys.Add(new KeyValuePair<string, int>(currentDayWeek.ToString("dddd"), counter));
                                currentDayWeek = currentDayWeek.AddDays(1);
                            }
                            titleSeries.Title = "Aantal logins deze week";
                            break;
                    }
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

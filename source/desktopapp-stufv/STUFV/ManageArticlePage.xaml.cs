using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
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
    /// Interaction logic for ManageArticlePage.xaml
    /// </summary>
    public partial class ManageArticlePage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        HttpClient client = new HttpClient();

        public ManageArticlePage()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<string> filterItems = new List<string> { "Id", "Titel", "AuteurId", "Datum aangemaakt", "Datum vanaf" };

            filterBox.ItemsSource = filterItems;
            filterBox.SelectedIndex = 0;

            menuBox.SelectionChanged += MenuBox_SelectionChanged;
            filterBox.SelectionChanged += FilterBox_SelectionChanged;
            searchDatePicker.SelectedDateChanged += SearchDatePicker_SelectedDateChanged;
            LoadArticles();
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

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filterBox.SelectedIndex >= 3)
            {
                searchDatePicker.Visibility = Visibility.Visible;
                searchTextBox.IsEnabled = false;
            }
            else
            {
                searchDatePicker.Visibility = Visibility.Hidden;
                searchTextBox.IsEnabled = true;
            }
            searchTextBox.Text = "";
            searchDatePicker.Text = "";
        }


        private async void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (searchTextBox.Text != "")
            {
                IEnumerable<Article> allArticles = await GetArticles();

                string filter = filterBox.SelectedValue.ToString();

                List<Article> selectArticles = new List<Article>();
                foreach (Article article in allArticles)
                {
                    switch (filter)
                    {
                        case "Id":
                            int id = 0;
                            if (int.TryParse(searchTextBox.Text, out id))
                            {
                                id = Convert.ToInt32(searchTextBox.Text);
                            }
                            if (article.Id == id) { selectArticles.Add(article); }
                            break;
                        case "Titel":
                            if (article.Title.ToUpper().Contains(searchTextBox.Text.ToUpper())) { selectArticles.Add(article); }
                            break;
                        case "AuteurId":
                            int auteurId = 0;
                            if (int.TryParse(searchTextBox.Text, out auteurId))
                            {
                                auteurId = Convert.ToInt32(searchTextBox.Text);
                            }
                            if (article.UserId == auteurId) { selectArticles.Add(article); }
                            break;
                        default:
                            break;
                    }
                }
                if (selectArticles == null)
                {
                    messageLabel.Content = "Geen resultaten";
                }
                else
                {
                    messageLabel.Content = "Er zijn " + selectArticles.Count + " resultaten gevonden!";
                    articlesDataGrid.ItemsSource = selectArticles;
                }
            }
            else
            {
                messageLabel.Content = "";
                LoadArticles();
            }
        }


        private async void SearchDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchDatePicker.SelectedDate != null)
            {
                IEnumerable<Article> allArticles = await GetArticles();

                string filter = filterBox.SelectedValue.ToString();

                List<Article> selectArticles = new List<Article>();
                foreach (Article article in allArticles)
                {
                    switch (filter)
                    {
                        case "Datum aangemaakt":
                            if (article.DateTime.Date == searchDatePicker.SelectedDate) { selectArticles.Add(article); }
                            break;
                        case "Datum vanaf":
                            if (article.DateTime >= searchDatePicker.SelectedDate) { selectArticles.Add(article); }
                            break;
                        default:
                            break;
                    }
                }
                if (selectArticles == null)
                {
                    messageLabel.Content = "Geen resultaten";
                }
                else
                {
                    messageLabel.Content = "Er zijn " + selectArticles.Count + " resultaten gevonden!";
                    articlesDataGrid.ItemsSource = selectArticles;
                }
            }
            else
            {
                messageLabel.Content = "";
                LoadArticles();
            }
        }

        private async void LoadArticles()
        {
            articlesDataGrid.ItemsSource = await GetArticles();
        }

        private void SendMail(Article article, User author)
        {
            try
            {
                string active = null;
                if (article.Active == true)
                {
                    active = "geactiveerd";
                }
                else
                {
                    active = "gedeactiveerd";
                }

                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("stufv.test@hotmail.com");
                mail.To.Add(author.Email);
                mail.Subject = "STUFV: Aanpassingen status artikel met id " + article.Id;
                mail.Body = string.Format("De administrator, {0} {1}, heeft jouw artikel {2}. Bekijk de desktopapp voor meer informatie", 
                    scherm.user.FirstName, scherm.user.LastName, active);
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new NetworkCredential("stufv.test@hotmail.com", "paswoord123");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("Kon mail niet verzenden: " + ex.Message);
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

        public async Task<IEnumerable<Article>> GetArticles()
        {
            IEnumerable<Article> articles = null;
            try {
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

        public async Task UpdateArticle(Article article)
        {
            try {
                var articleUrl = "/api/article/" + article.Id;
                HttpResponseMessage response = await client.PutAsJsonAsync(articleUrl, article);

                if (response.IsSuccessStatusCode)
                {
                    User author = await GetUser(article.UserId);
                    if (scherm.user.Email != author.Email)
                    {
                        SendMail(article, author);
                    }
                    LoadArticles();
                }
                messageLabel.Content = "";
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

        public async Task<IEnumerable<User>> GetUsers()
        {
            IEnumerable<User> users = null;
            try {
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

        public async Task<User> GetUser(int id)
        {
            IEnumerable<User> users = await GetUsers();

            User user = null;
            for (int x = 0; x < users.Count(); x++)
            {
                if (users.ElementAt(x).Id.Equals(id))
                {
                    user = users.ElementAt(x);
                }
            }
            return user;
        }

        private async void ChangeArticleButton_Click(object sender, RoutedEventArgs e)
        {
            Article article = (Article)articlesDataGrid.CurrentItem;
            User author = await GetUser(article.UserId);

            EditArticleWindow editWindow = new EditArticleWindow(article, author, scherm.user);
            editWindow.ShowDialog();
            LoadArticles();
        }

        private async void DetailsAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            Article article = (Article)articlesDataGrid.CurrentItem;
            User author = await GetUser(article.UserId);

            UserDetailsWindow detailsWindow = new UserDetailsWindow(author);
            detailsWindow.ShowDialog();
        }

        private async void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            Article article = (Article)articlesDataGrid.CurrentItem;
            bool originalActive = article.Active;

            if (article.Active == true)
            {
                if (MessageBox.Show("Bent u zeker dat u dit artikel wilt deactiveren",
                    "Deactiveren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    article.Active = false;
                }
            }
            else
            {
                if (MessageBox.Show("Bent u zeker dat u dit artikel wilt activeren?",
                    "Activeren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    article.Active = true;
                }
            }

            if (originalActive != article.Active)
            {
                messageLabel.Content = "Verwerken...";
                await UpdateArticle(article);
            }
        }
    }
}

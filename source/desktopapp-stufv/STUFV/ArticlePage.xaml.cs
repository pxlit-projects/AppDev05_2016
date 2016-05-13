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
using System.Windows.Threading;

namespace STUFV
{
    /// <summary>
    /// Interaction logic for ArtikelPage.xaml
    /// </summary>
    public partial class ArticlePage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        DispatcherTimer timer;
        HttpClient client = new HttpClient();

        public ArticlePage()
        {
            InitializeComponent();

            authorBlock.Text = scherm.user.FirstName + " " + scherm.user.LastName;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

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

        private void Timer_Tick(object sender, EventArgs e)
        {
            dateBlock.Text = DateTime.Now.ToLongDateString() + ", " + DateTime.Now.ToLongTimeString();
        }

        private void PlaceArticleButton_Click(object sender, RoutedEventArgs e)
        {
            Article article = new Article();
            article.Title = titleTextBox.Text;
            article.Content = contentTextBox.Text;
            article.UserId = scherm.user.Id;
            article.DateTime = DateTime.Now.AddHours(2);
            article.Active = true;
            article.ThumbsUp = 0;

            AddArticle(article);
        }

        private async void AddArticle(Article article)
        {
            try {
                var userUrl = "/api/article";
                HttpResponseMessage response = await client.PostAsJsonAsync(userUrl, article);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show(String.Format("Artikel succesvol geplaatst op {0}. Auteur: {1} {2}",
                                article.DateTime.ToLongDateString(), scherm.user.FirstName, scherm.user.LastName));
                }
            }
            catch (HttpRequestException ex)
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

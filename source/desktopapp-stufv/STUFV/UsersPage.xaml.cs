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
    /// Interaction logic for GebruikersPage.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        private HttpClient client = new HttpClient();

        public UsersPage()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://webapp-stufv20160429025210.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            loadUsers();

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
                    scherm.displayFrame.Source = new Uri("StatsPage.xaml", UriKind.Relative);
                    break;
                case 7:
                    scherm.displayFrame.Source = new Uri("LogoutPage.xaml", UriKind.Relative);
                    break;
            }
        }

        public async void loadUsers()
        {
            usersDataGrid.ItemsSource = await GetUsers();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var userUrl = "/api/user";
            HttpResponseMessage response = await client.GetAsync(userUrl);
            IEnumerable<User> users = null;

            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<IEnumerable<User>>();
            }
            return users;
        }

        private void MailButton_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)usersDataGrid.CurrentItem;

            var url = "mailto:" + user.Email;
            Process.Start(url);
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)usersDataGrid.CurrentItem;
            UserDetailsWindow detailsWindow = new UserDetailsWindow(user);
            detailsWindow.ShowDialog();
        }
    }
}

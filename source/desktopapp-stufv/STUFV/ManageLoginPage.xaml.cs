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
    /// Interaction logic for ManageLoginPage.xaml
    /// </summary>
    public partial class ManageLoginPage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        HttpClient client = new HttpClient();

        public ManageLoginPage()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<string> filterItems = new List<string> { "Id", "UserId", "Naam", "Email", "Datum login", "Datum vanaf" };

            filterBox.ItemsSource = filterItems;

            LoadLogins();
            menuBox.SelectionChanged += MenuBox_SelectionChanged;
            loginDataGrid.SelectionChanged += LoginDataGrid_SelectionChanged;
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

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (filterBox.SelectedIndex >= 4)
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
                IEnumerable<Login> allLogins = await GetLogins();

                string filter = filterBox.SelectedValue.ToString();

                List<Login> selectLogins = new List<Login>();
                foreach (Login login in allLogins)
                {
                    switch (filter)
                    {
                        case "Id":
                            int id = 0;
                            if (int.TryParse(searchTextBox.Text, out id))
                            {
                                id = Convert.ToInt32(searchTextBox.Text);
                            }
                            if (login.Id == id) { selectLogins.Add(login); }
                            break;
                        case "UserId":
                            int userId = 0;
                            if (int.TryParse(searchTextBox.Text, out userId))
                            {
                                id = Convert.ToInt32(searchTextBox.Text);
                            }
                            if (login.UserId == userId) { selectLogins.Add(login); }
                            break;
                        case "Naam":
                            IEnumerable<User> naamUsers = await GetUsers();
                            foreach (User user in naamUsers)
                            {
                                if (user.FirstName.ToUpper().Contains(searchTextBox.Text.ToUpper()) 
                                    || user.LastName.ToUpper().Contains(searchTextBox.Text.ToUpper()))
                                {
                                    if (login.UserId == user.Id)
                                    {
                                        selectLogins.Add(login);
                                    }
                                }
                            }
                            break;
                        case "Email":
                            IEnumerable<User> emailUsers = await GetUsers();
                            foreach (User user in emailUsers)
                            {
                                if (user.Email.ToUpper().Contains(searchTextBox.Text.ToUpper()))
                                {
                                    if (login.UserId == user.Id)
                                    {
                                        selectLogins.Add(login);
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (selectLogins == null)
                {
                    messageLabel.Content = "Geen resultaten";
                }
                else
                {
                    messageLabel.Content = "Er zijn " + selectLogins.Count + " resultaten gevonden!";
                    loginDataGrid.ItemsSource = selectLogins;
                }
            }
            else
            {
                messageLabel.Content = "";
                LoadLogins();
            }
        }


        private async void SearchDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchDatePicker.SelectedDate != null)
            {
                IEnumerable<Login> allLogins = await GetLogins();

                string filter = filterBox.SelectedValue.ToString();

                List<Login> selectLogins = new List<Login>();
                foreach (Login login in allLogins)
                {
                    switch (filter)
                    {
                        case "Datum login":
                            if (login.DateTime.Date == searchDatePicker.SelectedDate) { selectLogins.Add(login); }
                            break;
                        case "Datum vanaf":
                            if (login.DateTime >= searchDatePicker.SelectedDate) { selectLogins.Add(login); }
                            break;
                        default:
                            break;
                    }
                }
                if (selectLogins == null)
                {
                    messageLabel.Content = "Geen resultaten";
                }
                else
                {
                    messageLabel.Content = "Er zijn " + selectLogins.Count + " resultaten gevonden!";
                    loginDataGrid.ItemsSource = selectLogins;
                }
            }
            else
            {
                messageLabel.Content = "";
                LoadLogins();
            }
        }

        private async void LoginDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchTextBox.IsFocused == false && searchDatePicker.IsDropDownOpen == false
                && searchDatePicker.IsFocused == false && filterBox.IsFocused == false)
            {
                IEnumerable<Login> logins = await GetLogins();
                List<DateTime> loginDates = new List<DateTime>();

                Login login = (Login)loginDataGrid.CurrentItem;
                User user = await GetUser(login.UserId);

                string role = null;

                switch (user.RoleID)
                {
                    case 1:
                        role = "Admin";
                        break;
                    case 2:
                        role = "User";
                        break;
                }

                userLabel.Content = string.Format("{0} {1} ({2})", user.FirstName, user.LastName, role);
                homePlaceTextBox.Text = "ToDo";

                foreach (Login forLogin in logins)
                {
                    if (forLogin.UserId == login.UserId) { loginDates.Add(forLogin.DateTime); }
                }
                loginDates.Sort();

                latestLogin.Content = loginDates.Last().ToLongDateString() + ", " + loginDates.Last().ToLongTimeString();
                detailsPanel.DataContext = user;
            } 
        }

        public async void LoadLogins()
        {
            IEnumerable<Login> getLogins = await GetLogins();
            List<Login> logins = getLogins.ToList();

            loginDataGrid.ItemsSource = logins;
        }

        public async Task<IEnumerable<Login>> GetLogins()
        {
            var loginUrl = "/api/login";
            HttpResponseMessage response = await client.GetAsync(loginUrl);
            IEnumerable<Login> logins = null;

            if (response.IsSuccessStatusCode)
            {
                logins = await response.Content.ReadAsAsync<IEnumerable<Login>>();
            }
            return logins;
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
    }
}

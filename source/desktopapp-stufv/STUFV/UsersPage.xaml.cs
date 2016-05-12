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

            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<string> filterItems = new List<string> { "Id", "Voornaam", "Achternaam", "Email" };

            filterBox.ItemsSource = filterItems;

            loadUsers();

            menuBox.SelectionChanged += MenuBox_SelectionChanged;
            searchTextBox.SelectionChanged += SearchTextBox_SelectionChanged;
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

        private async void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (searchTextBox.Text != "")
            {
                IEnumerable<User> allUsers = await GetUsers();

                string filter = filterBox.Text;

                List<User> selectUsers = new List<User>();
                foreach (User user in allUsers)
                {
                    switch (filter)
                    {
                        case "Id":
                            int id = 0;
                            if (int.TryParse(searchTextBox.Text, out id))
                            {
                                id = Convert.ToInt32(searchTextBox.Text);
                            }
                            if (user.Id == id) { selectUsers.Add(user); }
                            break;
                        case "Voornaam":
                            if (user.FirstName.ToUpper().Contains(searchTextBox.Text.ToUpper())) { selectUsers.Add(user); }
                            break;
                        case "Achternaam":
                            if (user.LastName.ToUpper().Contains(searchTextBox.Text.ToUpper())) { selectUsers.Add(user); }
                            break;
                        case "Email":
                            if (user.Email.ToUpper().Contains(searchTextBox.Text.ToUpper())) { selectUsers.Add(user); }
                            break;
                        default:
                            break;
                    }
                }
                if (selectUsers == null)
                {
                    messageLabel.Content = "Geen resultaten";
                }
                else
                {
                    messageLabel.Content = "Er zijn " + selectUsers.Count + " resultaten gevonden!";
                    usersDataGrid.ItemsSource = selectUsers;
                }
            }
            else
            {
                messageLabel.Content = "";
                loadUsers();
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

        public async Task UpdateUser(User user)
        {
            var userUrl = "/api/user/" + user.Id;
            HttpResponseMessage response = await client.PutAsJsonAsync(userUrl, user);

            if (response.IsSuccessStatusCode)
            {
                loadUsers();
            }
        }

        public async void ChangeStatus()
        {
            User user = (User)usersDataGrid.CurrentItem;
            bool originalActive = user.Active;

            if (user.Active == true)
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u de gebruiker, {0} {1}, wilt deactiveren?", user.FirstName, user.LastName),
                    "Deactiveren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    user.Active = false;
                }
            }
            else
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u de gebruiker, {0} {1}, wilt activeren?", user.FirstName, user.LastName),
                    "Activeren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    user.Active = true;
                }
            }

            if (originalActive != user.Active)
            {
                await UpdateUser(user);
            }
        }

        public async void ChangeRole()
        {
            User user = (User)usersDataGrid.CurrentItem;
            int originalRoleID = user.RoleID;

            if (user.RoleID == 1)
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u de gebruiker, {0} {1}, wilt degraderen tot een gewone gebruiker?", user.FirstName, user.LastName),
                    "Deactiveren", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    user.RoleID = 2;
                }
            }
            else
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u de gebruiker, {0} {1}, wilt promoveren tot administrator?", user.FirstName, user.LastName),
                    "Activeren", MessageBoxButton.YesNoCancel, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    user.RoleID = 1;
                }
            }

            if (originalRoleID != user.RoleID)
            {
                await UpdateUser(user);
            }
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

        private void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeStatus();
        }

        private void ChangeRoleButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeRole();
        }
    }
}

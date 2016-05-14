using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ManageOrganisationPage.xaml
    /// </summary>
    public partial class ManageOrganisationPage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        private HttpClient client = new HttpClient();

        public ManageOrganisationPage()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<string> filterItems = new List<string> { "Id", "Naam" };

            filterBox.ItemsSource = filterItems;
            filterBox.SelectedIndex = 0;

            LoadOrganisations();

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

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            searchTextBox.Text = "";
        }

        private async void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (searchTextBox.Text != "")
            {
                IEnumerable<Organisation> allOrganisations = await GetOrganisations();

                string filter = filterBox.SelectedValue.ToString();

                List<Organisation> selectOrganisations = new List<Organisation>();
                foreach (Organisation organisation in allOrganisations)
                {
                    if (organisation.isRegistered == true)
                    {
                        switch (filter)
                        {
                            case "Id":
                                int id = 0;
                                if (int.TryParse(searchTextBox.Text, out id))
                                {
                                    id = Convert.ToInt32(searchTextBox.Text);
                                }
                                if (organisation.Id == id) { selectOrganisations.Add(organisation); }
                                break;
                            case "Naam":
                                if (organisation.Name.ToUpper().Contains(searchTextBox.Text.ToUpper())) { selectOrganisations.Add(organisation); }
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (selectOrganisations == null)
                {
                    messageLabel.Content = "Geen resultaten";
                }
                else
                {
                    messageLabel.Content = "Er zijn " + selectOrganisations.Count + " resultaten gevonden!";
                    manageOrganisationDataGrid.ItemsSource = selectOrganisations;
                }
            }
            else
            {
                messageLabel.Content = "";
                LoadOrganisations();
            }
        }

        public async void LoadOrganisations()
        {
            IEnumerable<Organisation> allOrganisations = await GetOrganisations();
            List<Organisation> selectOrganisations = new List<Organisation>();

            foreach (Organisation organisation in allOrganisations)
            {
                if (organisation.isRegistered == true)
                {
                    selectOrganisations.Add(organisation);
                }
            }

            manageOrganisationDataGrid.ItemsSource = selectOrganisations;
        }

        private void SendMail(Organisation organisation, User user)
        {
            try
            {
                string active = null;
                if (organisation.Active == true)
                {
                    active = "geactiveerd. Je kan terug evenementen plaatsen op de website van STUFV.";
                }
                else
                {
                    active = "gedeactiveerd. Je kan geen evenementen meer toevoegen.";
                }

                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("stufv.test@hotmail.com");
                mail.To.Add(user.Email);
                mail.Subject = "STUFV: Aanpassing Status organisatie (" + organisation.Name + ")";
                mail.Body = string.Format("Jouw organisatie werd {0}", active);
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

        public async Task<IEnumerable<Organisation>> GetOrganisations()
        {
            IEnumerable<Organisation> organisations = null;
            try {
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

        public async Task UpdateOrganisation(Organisation organisation)
        {
            try {
                var organisationUrl = "/api/organisations/" + organisation.Id;
                HttpResponseMessage response = await client.PutAsJsonAsync(organisationUrl, organisation);

                if (response.IsSuccessStatusCode)
                {
                    User user = await GetUser(organisation.UserId);
                    SendMail(organisation, user);
                    LoadOrganisations();
                    messageLabel.Content = "";
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

        private async void MailOrganisationButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                Organisation organisation = (Organisation)manageOrganisationDataGrid.CurrentItem;
                User user = await GetUser(organisation.UserId);

                var url = "mailto:" + user.Email;
                Process.Start(url);
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

        private void EventsButton_Click(object sender, RoutedEventArgs e)
        {
            Organisation organisation = (Organisation)manageOrganisationDataGrid.CurrentItem;
            OrganisationEventsWindow eventWindow = new OrganisationEventsWindow(organisation);
            eventWindow.ShowDialog();
        }

        private async void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            Organisation organisation = (Organisation)manageOrganisationDataGrid.CurrentItem;
            bool originalActive = organisation.Active;

            if (organisation.Active == true)
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u de organisatie, {0}, wilt deactiveren?", organisation.Name),
                    "Deactiveren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    organisation.Active = false;
                }
            }
            else
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u de organisatie, {0}, wilt activeren?", organisation.Name),
                    "Activeren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    organisation.Active = true;
                }
            }

            if (originalActive != organisation.Active)
            {
                messageLabel.Content = "Verwerken...";
                await UpdateOrganisation(organisation);
            }
        }
    }
}

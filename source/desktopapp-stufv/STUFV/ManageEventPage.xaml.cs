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
    /// Interaction logic for ManageEventPage.xaml
    /// </summary>
    public partial class ManageEventPage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        HttpClient client = new HttpClient();

        public ManageEventPage()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<string> filterItems = new List<string> { "Id", "Naam", "Datum vanaf" };

            filterBox.ItemsSource = filterItems;
            filterBox.SelectedIndex = 0;

            LoadEvents();
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
            if (filterBox.SelectedIndex == 2)
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
                IEnumerable<Event> allEvents = await GetEvents();

                string filter = filterBox.SelectedValue.ToString();

                List<Event> selectEvents = new List<Event>();
                foreach (Event orgEvent in allEvents)
                {
                    switch (filter)
                    {
                        case "Id":
                            int id = 0;
                            if (int.TryParse(searchTextBox.Text, out id))
                            {
                                id = Convert.ToInt32(searchTextBox.Text);
                            }
                            if (orgEvent.Id == id) { selectEvents.Add(orgEvent); }
                            break;
                        case "Naam":
                            if (orgEvent.Name.ToUpper().Contains(searchTextBox.Text.ToUpper())) { selectEvents.Add(orgEvent); }
                            break;
                        default:
                            break;
                    }
                }
                if (selectEvents == null)
                {
                    messageLabel.Content = "Geen resultaten";
                }
                else
                {
                    messageLabel.Content = "Er zijn " + selectEvents.Count + " resultaten gevonden!";
                    eventDataGrid.ItemsSource = selectEvents;
                }
            }
            else
            {
                messageLabel.Content = "";
                LoadEvents();
            }
        }

        private async void SearchDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (searchDatePicker.SelectedDate != null)
            {
                IEnumerable<Event> allEvents = await GetEvents();

                string filter = filterBox.SelectedValue.ToString();

                List<Event> selectEvents = new List<Event>();
                foreach (Event orgEvent in allEvents)
                {
                    if (orgEvent.Start.Date >= searchDatePicker.SelectedDate) { selectEvents.Add(orgEvent); }
                }
                if (selectEvents == null)
                {
                    messageLabel.Content = "Geen resultaten";
                }
                else
                {
                    messageLabel.Content = "Er zijn " + selectEvents.Count + " resultaten gevonden!";
                    eventDataGrid.ItemsSource = selectEvents;
                }
            }
            else
            {
                messageLabel.Content = "";
                LoadEvents();
            }
        }

        private async void LoadEvents()
        {
            eventDataGrid.ItemsSource = await GetEvents();
        }

        private void SendMail(Event orgEvent, User user)
        {
            try
            {
                string active = null;
                if (orgEvent.Active == true)
                {
                    active = "geactiveerd. Je kan je event online bekijken op de website van STUFV.";
                }
                else
                {
                    active = "gedeactiveerd. Het evenement is nu niet meer zichtbaar op de website van STUFV.";
                }

                SmtpClient SmtpServer = new SmtpClient("smtp.live.com");
                var mail = new MailMessage();
                mail.From = new MailAddress("stufv.test@hotmail.com");
                mail.To.Add(user.Email);
                mail.Subject = "STUFV: Aanpassing Status event (" + orgEvent.Name + ")";
                mail.Body = string.Format("Jouw evenement werd {0}", active);
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

        private async Task<IEnumerable<Event>> GetEvents()
        {
            IEnumerable<Event> events = null;
            try {
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

        private async Task UpdateEvent(Event orgEvent)
        {
            try {
                var eventUrl = "/api/event/" + orgEvent.Id;
                HttpResponseMessage response = await client.PutAsJsonAsync(eventUrl, orgEvent);

                if (response.IsSuccessStatusCode)
                {
                    Organisation organisation = await GetOrganisation(orgEvent.OrganisationId);
                    User user = await GetUser(organisation.UserId);
                    SendMail(orgEvent, user);
                    LoadEvents();
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

        public async Task<User> GetUser(int id)
        {
            User user = null;
            try
            {
                var userUrl = "/api/user/" + id;
                HttpResponseMessage response = await client.GetAsync(userUrl);

                if (response.IsSuccessStatusCode)
                {
                    user = await response.Content.ReadAsAsync<User>();
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
            return user;
        }

        public async Task<Organisation> GetOrganisation(int id)
        {
            Organisation organisation = null;
            try
            {
                var organisationUrl = "/api/organisation/" + id;
                HttpResponseMessage response = await client.GetAsync(organisationUrl);

                if (response.IsSuccessStatusCode)
                {
                    organisation = await response.Content.ReadAsAsync<Organisation>();
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
            return organisation;
        }

        private async void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            Event orgEvent = (Event)eventDataGrid.CurrentItem;
            bool originalActive = orgEvent.Active;

            if (orgEvent.Active == true)
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u het event, {0}, wilt deactiveren?", orgEvent.Name),
                    "Deactiveren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    orgEvent.Active = false;
                }
            }
            else
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u het event, {0}, wilt activeren?", orgEvent.Name),
                    "Activeren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    orgEvent.Active = true;
                }
            }

            if (originalActive != orgEvent.Active)
            {
                messageLabel.Content = "Verwerken...";
                await UpdateEvent(orgEvent);
                
            }
        }
    }
}

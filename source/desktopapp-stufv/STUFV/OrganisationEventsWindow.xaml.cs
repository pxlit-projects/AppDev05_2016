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
using System.Windows.Shapes;

namespace STUFV
{
    /// <summary>
    /// Interaction logic for OrganisationEventsWindow.xaml
    /// </summary>
    public partial class OrganisationEventsWindow : Window
    {
        Organisation organisation;
        HttpClient client = new HttpClient();
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;

        public OrganisationEventsWindow(Organisation organisation)
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://webapp-stufv20160527104738.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.organisation = organisation;

            List<string> filterItems = new List<string> { "Id", "Naam", "Datum vanaf" };

            filterBox.ItemsSource = filterItems;
            filterBox.SelectedIndex = 0;

            LoadEvents();
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
                IEnumerable<Event> allEvents = await GetRelatedEvents();

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
                IEnumerable<Event> allEvents = await GetRelatedEvents();

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
            eventDataGrid.ItemsSource = await GetRelatedEvents();
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
                Close();
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
                Close();
                scherm.Close();
            }
            return events;
        }

        private async Task<IEnumerable<Event>> GetRelatedEvents()
        {
            IEnumerable<Event> events = await GetEvents();
            List<Event> selectEvents = new List<Event>();

            foreach (Event orgEvent in events)
            {
                if (orgEvent.OrganisationId == organisation.Id)
                {
                    selectEvents.Add(orgEvent);
                }
            }
            return selectEvents;
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
                Close();
                scherm.Close();
            }
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

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            searchTextBox.Text = "";
            filterBox.SelectedIndex = 0;
            LoadEvents();
        }
    }
}

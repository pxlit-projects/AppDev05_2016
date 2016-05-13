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

            client.BaseAddress = new Uri("http://webapp-stufv20160511012914.azurewebsites.net/");
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
            catch (HttpRequestException ex)
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

        private async Task UpdateEvent(Event orgEvent)
        {
            try {
                var eventUrl = "/api/event/" + orgEvent.Id;
                HttpResponseMessage response = await client.PutAsJsonAsync(eventUrl, orgEvent);

                if (response.IsSuccessStatusCode)
                {
                    LoadEvents();
                }
            }
            catch (HttpRequestException ex)
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
                await UpdateEvent(orgEvent);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        
    }
}

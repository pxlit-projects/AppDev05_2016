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
    /// Interaction logic for ManageEventPage.xaml
    /// </summary>
    public partial class ManageEventPage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        HttpClient client = new HttpClient();

        public ManageEventPage()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://webapp-stufv20160429025210.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<string> filterItems = new List<string> { "Id", "Naam", "Datum vanaf" };

            filterBox.ItemsSource = filterItems;

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
                    scherm.displayFrame.Source = new Uri("StatsPage.xaml", UriKind.Relative);
                    break;
                case 9:
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

        private async Task<IEnumerable<Event>> GetEvents()
        {
            var eventUrl = "/api/event";
            HttpResponseMessage response = await client.GetAsync(eventUrl);
            IEnumerable<Event> events = null;
            if (response.IsSuccessStatusCode)
            {
                events = await response.Content.ReadAsAsync<IEnumerable<Event>>();
            }
            return events;
        }

        private async Task UpdateEvent(Event orgEvent)
        {
            var eventUrl = "/api/event/" + orgEvent.Id;
            HttpResponseMessage response = await client.PutAsJsonAsync(eventUrl, orgEvent);

            if (response.IsSuccessStatusCode)
            {
                LoadEvents();
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
    }
}

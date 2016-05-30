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
    /// Interaction logic for ManagePartnerPage.xaml
    /// </summary>
    public partial class ManagePartnerPage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        private HttpClient client = new HttpClient();

        public ManagePartnerPage()
        {
            InitializeComponent();
            menuBox.SelectionChanged += MenuBox_SelectionChanged;

            client.BaseAddress = new Uri("http://webapp-stufv20160527104738.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<string> filterItems = new List<string> { "Id", "Naam" };

            filterBox.ItemsSource = filterItems;
            filterBox.SelectedIndex = 0;

            LoadPartners();
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
                    scherm.displayFrame.Source = new Uri("TipPage.xaml", UriKind.Relative);
                    break;
                case 3:
                    scherm.displayFrame.Source = new Uri("NewOrganisationPage.xaml", UriKind.Relative);
                    break;
                case 4:
                    scherm.displayFrame.Source = new Uri("ReviewsPage.xaml", UriKind.Relative);
                    break;
                case 5:
                    scherm.displayFrame.Source = new Uri("PartnerPage.xaml", UriKind.Relative);
                    break;
                case 6:
                    scherm.displayFrame.Source = new Uri("UsersPage.xaml", UriKind.Relative);
                    break;
                case 7:
                    scherm.displayFrame.Source = new Uri("ManageOrganisationPage.xaml", UriKind.Relative);
                    break;
                case 8:
                    scherm.displayFrame.Source = new Uri("ManageEventPage.xaml", UriKind.Relative);
                    break;
                case 9:
                    scherm.displayFrame.Source = new Uri("ManageArticlePage.xaml", UriKind.Relative);
                    break;
                case 10:
                    scherm.displayFrame.Source = new Uri("ManagePartnerPage.xaml", UriKind.Relative);
                    break;
                case 11:
                    scherm.displayFrame.Source = new Uri("ManageTipPage.xaml", UriKind.Relative);
                    break;
                case 12:
                    scherm.displayFrame.Source = new Uri("ManageLoginPage.xaml", UriKind.Relative);
                    break;
                case 13:
                    scherm.displayFrame.Source = new Uri("StatsPage.xaml", UriKind.Relative);
                    break;
                case 14:
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
                IEnumerable<Partner> allPartners = await GetPartners();

                string filter = filterBox.SelectedValue.ToString();

                List<Partner> selectPartners = new List<Partner>();
                foreach (Partner partner in allPartners)
                {
                    
                    
                        switch (filter)
                        {
                            case "Id":
                                int id = 0;
                                if (int.TryParse(searchTextBox.Text, out id))
                                {
                                    id = Convert.ToInt32(searchTextBox.Text);
                                }
                                if (partner.Id == id) { selectPartners.Add(partner); }
                                break;
                            case "Naam":
                                if (partner.Name.ToUpper().Contains(searchTextBox.Text.ToUpper())) { selectPartners.Add(partner); }
                                break;
                            default:
                                break;
                        }
                    
                }
                if (selectPartners == null)
                {
                    messageLabel.Content = "Geen resultaten";
                }
                else
                {
                    messageLabel.Content = "Er zijn " + selectPartners.Count + " resultaten gevonden!";
                    managePartnerDataGrid.ItemsSource = selectPartners;
                }
            }
            else
            {
                messageLabel.Content = "";
                LoadPartners();
            }
        }

        public async void LoadPartners()
        {
            IEnumerable<Partner> allPartners = await GetPartners();
            
            managePartnerDataGrid.ItemsSource = allPartners;
        }
        public async Task<IEnumerable<Partner>> GetPartners()
        {
            IEnumerable<Partner> partners = null;
            try
            {
                var partnerUrl = "/api/partner";
                HttpResponseMessage response = await client.GetAsync(partnerUrl);

                if (response.IsSuccessStatusCode)
                {
                    partners = await response.Content.ReadAsAsync<IEnumerable<Partner>>();
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
            return partners;
        }

        public async Task UpdatePartner(Partner partner)
        {
            try
            {
                var partnerUrl = "/api/partner/" + partner.Id;
                HttpResponseMessage response = await client.PutAsJsonAsync(partnerUrl, partner);

                if (response.IsSuccessStatusCode)
                {
                    
                    
                    LoadPartners();
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
            try
            {
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

       

        private async void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            Partner partner = (Partner)managePartnerDataGrid.CurrentItem;
            bool originalActive = partner.Active;

            if (partner.Active == true)
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u de Partner, {0}, wilt deactiveren?", partner.Name),
                    "Deactiveren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    partner.Active = false;
                }
            }
            else
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u de Partner, {0}, wilt activeren?", partner.Name),
                    "Activeren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    partner.Active = true;
                }
            }

            if (originalActive != partner.Active)
            {
                messageLabel.Content = "Verwerken...";
                await UpdatePartner(partner);
            }
        }



        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            searchTextBox.Text = "";
            filterBox.SelectedIndex = 0;
            LoadPartners();
        }
    }
}

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
    /// Interaction logic for OrganisatiePage.xaml
    /// </summary>
    public partial class OrganisationPage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        private HttpClient client = new HttpClient();

        public OrganisationPage()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://webapp-stufv20160429025210.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //List<Organisation> organisations = new List<Organisation>
            //{
            //    new Organisation {Name = "STUFV", Description = "blabla", Active = true },
            //    new Organisation {Name = "PXL", Description = "geen commentaar", Active = false },
            //    new Organisation {Name = "test", Description = "dit is een hele lange tekst. dit is een hele lange tekst" +
            //                                                "dit is een hele lange tekst. dit is een hele lange tekst.", Active = true }
            //};

            loadOrganisations();
            
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
                    scherm.displayFrame.Source = new Uri("OrganisationPage.xaml", UriKind.Relative);
                    break;
                case 3:
                    scherm.displayFrame.Source = new Uri("ReviewsPage.xaml", UriKind.Relative);
                    break;
                case 4:
                    scherm.displayFrame.Source = new Uri("UsersPage.xaml", UriKind.Relative);
                    break;
                case 5:
                    scherm.displayFrame.Source = new Uri("StatsPage.xaml", UriKind.Relative);
                    break;
                case 6:
                    scherm.displayFrame.Source = new Uri("LogoutPage.xaml", UriKind.Relative);
                    break;
            }
        }

        private void manageOrganisationButton_Click(object sender, RoutedEventArgs e)
        {
            newOrganisationGrid.Visibility = Visibility.Hidden;
            manageOrganisationGrid.Visibility = Visibility.Visible;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            manageOrganisationGrid.Visibility = Visibility.Hidden;
            newOrganisationGrid.Visibility = Visibility.Visible;
        }

        public async void loadOrganisations()
        {
            newOrganisationDataGrid.ItemsSource = await GetOrganisations();
            manageOrganisationDataGrid.ItemsSource = await GetOrganisations();
        }

        public async Task<IEnumerable<Organisation>> GetOrganisations()
        {
            var userUrl = "/api/organisation";
            HttpResponseMessage response = await client.GetAsync(userUrl);
            IEnumerable<Organisation> organisations = null;
            if (response.IsSuccessStatusCode)
            {
                organisations = await response.Content.ReadAsAsync<IEnumerable<Organisation>>();
            }
            return organisations;
        }
    }
}

﻿using System;
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

namespace STUFV {
    /// <summary>
    /// Interaction logic for OrganisatiePage.xaml
    /// </summary>
    public partial class NewOrganisationPage : Page {
        HomeWindow scherm = ( HomeWindow ) Application.Current.MainWindow;
        private HttpClient client = new HttpClient ( );

        public NewOrganisationPage ( ) {
            InitializeComponent ( );

            client.BaseAddress = new Uri ("http://webapp-stufv20160429025210.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear ( );
            client.DefaultRequestHeaders.Accept.Add ( new MediaTypeWithQualityHeaderValue ( "application/json" ) );

            List<string> filterItems = new List<string> { "Id", "Naam" };

            filterBox.ItemsSource = filterItems;

            loadOrganisations ( );

            menuBox.SelectionChanged += MenuBox_SelectionChanged;
        }

        private void MenuBox_SelectionChanged ( object sender, SelectionChangedEventArgs e ) {
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

        public async void loadOrganisations()
        {
            IEnumerable<Organisation> allOrganisations = await GetOrganisations();
            List<Organisation> selectOrganisations = new List<Organisation>();

            foreach (Organisation organisation in allOrganisations)
            {
                if (organisation.isRegistered == false)
                {
                    selectOrganisations.Add(organisation);
                }
            }
            organisationDataGrid.ItemsSource = selectOrganisations;
        }

        public async Task<IEnumerable<Organisation>> GetOrganisations ( ) {
            var userUrl = "/api/organisations";
            HttpResponseMessage response = await client.GetAsync ( userUrl );
            IEnumerable<Organisation> organisations = null;
            if ( response.IsSuccessStatusCode ) {
                organisations = await response.Content.ReadAsAsync<IEnumerable<Organisation>> ( );
            }
            return organisations;
        }

        public async void updateOrganisation(Organisation toUpdate)
        {
            var url = "api/organisations/" + toUpdate.Id;
            HttpResponseMessage response = await client.PutAsJsonAsync(url, toUpdate);

            if (response.IsSuccessStatusCode)
            {
                loadOrganisations();
            }
        }

        private void GoodOrganisationButton_Click(object sender, RoutedEventArgs e)
        {
            Organisation organisation = (Organisation)organisationDataGrid.CurrentItem;

            organisation.Active = true;
            organisation.isRegistered = true;

            updateOrganisation(organisation);
        }

        private void BadOrganisationButton_Click(object sender, RoutedEventArgs e)
        {
            Organisation organisation = (Organisation)organisationDataGrid.CurrentItem;

            organisation.Active = false;
            organisation.isRegistered = true;

            updateOrganisation(organisation);
        }
    }
}

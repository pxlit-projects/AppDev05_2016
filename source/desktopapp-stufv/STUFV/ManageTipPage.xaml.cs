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
    /// Interaction logic for ManageTipPage.xaml
    /// </summary>
    public partial class ManageTipPage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        HttpClient client = new HttpClient();

        public ManageTipPage()
        {
            InitializeComponent();
            menuBox.SelectionChanged += MenuBox_SelectionChanged;
            client.BaseAddress = new Uri("http://webapp-stufv20160527104738.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<string> filterItems = new List<string> { "Id"};

            filterBox.ItemsSource = filterItems;
            filterBox.SelectedIndex = 0;

            menuBox.SelectionChanged += MenuBox_SelectionChanged;
            
            
            LoadTips();
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
                    scherm.displayFrame.Source = new Uri("UsersPage.xaml", UriKind.Relative);
                    break;
                case 6:
                    scherm.displayFrame.Source = new Uri("ManageOrganisationPage.xaml", UriKind.Relative);
                    break;
                case 7:
                    scherm.displayFrame.Source = new Uri("ManageEventPage.xaml", UriKind.Relative);
                    break;
                case 8:
                    scherm.displayFrame.Source = new Uri("ManageArticlePage.xaml", UriKind.Relative);
                    break;
                case 9:
                    scherm.displayFrame.Source = new Uri("ManagePartnerPage.xaml", UriKind.Relative);
                    break;
                case 10:
                    scherm.displayFrame.Source = new Uri("ManageTipPage.xaml", UriKind.Relative);
                    break;
                case 11:
                    scherm.displayFrame.Source = new Uri("ManageLoginPage.xaml", UriKind.Relative);
                    break;
                case 12:
                    scherm.displayFrame.Source = new Uri("StatsPage.xaml", UriKind.Relative);
                    break;
                case 13:
                    scherm.displayFrame.Source = new Uri("LogoutPage.xaml", UriKind.Relative);
                    break;
            }
        }
     


        private async void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (searchTextBox.Text != "")
            {
                IEnumerable<Tip> allTips = await GetTips();

                string filter = filterBox.SelectedValue.ToString();

                List<Tip> selectTips = new List<Tip>();
                foreach (Tip tip in allTips)
                {
                    switch (filter)
                    {
                        case "Id":
                            int id = 0;
                            if (int.TryParse(searchTextBox.Text, out id))
                            {
                                id = Convert.ToInt32(searchTextBox.Text);
                            }
                            if (tip.Id == id) { selectTips.Add(tip); }
                            break;
                       
                        default:
                            break;
                    }
                }
                if (selectTips == null)
                {
                    messageLabel.Content = "Geen resultaten";
                }
                else
                {
                    messageLabel.Content = "Er zijn " + selectTips.Count + " resultaten gevonden!";
                    TipsDataGrid.ItemsSource = selectTips;
                }
            }
            else
            {
                messageLabel.Content = "";
                LoadTips();
            }
        }

        private async void LoadTips()
        {
            TipsDataGrid.ItemsSource = await GetTips();
        }

        public async Task<IEnumerable<Tip>> GetTips()
        {
            IEnumerable<Tip> Tips = null;
            try
            {
                var tipUrl = "/api/tip";
                HttpResponseMessage response = await client.GetAsync(tipUrl);

                if (response.IsSuccessStatusCode)
                {
                    Tips = await response.Content.ReadAsAsync<IEnumerable<Tip>>();
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

            return Tips;
        }

        public async Task UpdateTip(Tip tip)
        {
            try
            {
                var tipUrl = "/api/tip/" + tip.Id;
                HttpResponseMessage response = await client.PutAsJsonAsync(tipUrl, tip);

                if (response.IsSuccessStatusCode)
                {
                   
                    LoadTips();
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
        private async void ChangeTipButton_Click(object sender, RoutedEventArgs e)
        {
            Tip tip = (Tip)TipsDataGrid.CurrentItem;
            

            EditTipWindow editWindow = new EditTipWindow(tip);
            editWindow.ShowDialog();
            LoadTips();
        }

        

        private async void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            Tip tip = (Tip)TipsDataGrid.CurrentItem;
            bool originalActive = tip.Active;

            if (tip.Active == true)
            {
                if (MessageBox.Show("Bent u zeker dat u deze tip wilt deactiveren",
                    "Deactiveren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    tip.Active = false;
                }
            }
            else
            {
                if (MessageBox.Show("Bent u zeker dat u deze tip wilt activeren?",
                    "Activeren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    tip.Active = true;
                }
            }

            if (originalActive != tip.Active)
            {
                messageLabel.Content = "Verwerken...";
                await UpdateTip(tip);
            }
        }
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            searchTextBox.Text = "";
            filterBox.SelectedIndex = 0;
            LoadTips();
        }
    }
}

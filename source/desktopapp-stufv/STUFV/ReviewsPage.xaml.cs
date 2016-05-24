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
    /// Interaction logic for ReviewPage.xaml
    /// </summary>
    public partial class ReviewsPage : Page
    {
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        private HttpClient client = new HttpClient();

        public ReviewsPage()
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://localhost:54238/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<string> filterItems = new List<string> { "Id", "UserId", "Content" };

            filterBox.ItemsSource = filterItems;
            filterBox.SelectedIndex = 0;

            LoadReviews();

            menuBox.SelectionChanged += MenuBox_SelectionChanged;
            searchTextBox.SelectionChanged += SearchTextBox_SelectionChanged;
            alleReviewsButton.Checked += AlleReviewsButton_GotFocus;
            nbReviewsButton.Checked += NbReviewsButton_GotFocus;
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
                    scherm.displayFrame.Source = new Uri("ManageLoginPage.xaml", UriKind.Relative);
                    break;
                case 10:
                    scherm.displayFrame.Source = new Uri("ManagePartnerPage.xaml", UriKind.Relative);
                    break;
                case 11:
                    scherm.displayFrame.Source = new Uri("ManageTipPage.xaml", UriKind.Relative);
                    break;
                case 12:
                    scherm.displayFrame.Source = new Uri("StatsPage.xaml", UriKind.Relative);
                    break;
                case 13:
                    scherm.displayFrame.Source = new Uri("LogoutPage.xaml", UriKind.Relative);
                    break;
            }
        }

        private void AlleReviewsButton_GotFocus(object sender, RoutedEventArgs e)
        {
            searchTextBox.Text = "";
            LoadReviews();
        }

        private void NbReviewsButton_GotFocus(object sender, RoutedEventArgs e)
        {
            searchTextBox.Text = "";
            LoadReviews();
        }

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            searchTextBox.Text = "";
        }

        private async void SearchTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (searchTextBox.Text != "")
            {
                IEnumerable<Review> reviews = await GetReviews();
                IEnumerable<Review> allReviews = null;

                if (alleReviewsButton.IsChecked == true)
                {
                    allReviews = reviews;
                }
                else if (nbReviewsButton.IsChecked == true)
                {
                    List<Review> groupReviews = new List<Review>();
                    foreach (Review review in reviews)
                    {
                        if (review.Flagged == "True" && review.Handled == false)
                        {
                            groupReviews.Add(review);
                        }
                        allReviews = groupReviews;
                    }
                }

                string filter = filterBox.SelectedValue.ToString();

                List<Review> selectReviews = new List<Review>();
                foreach (Review review in allReviews)
                {
                    if (review.Active == true)
                    {
                        switch (filter)
                        {
                            case "Id":
                                int id = 0;
                                if (int.TryParse(searchTextBox.Text, out id))
                                {
                                    id = Convert.ToInt32(searchTextBox.Text);
                                }
                                if (review.Id == id) { selectReviews.Add(review); }
                                break;
                            case "Content":
                                if (review.Content.ToUpper().Contains(searchTextBox.Text.ToUpper())) { selectReviews.Add(review); }
                                break;
                            case "UserId":
                                if (int.TryParse(searchTextBox.Text, out id))
                                {
                                    id = Convert.ToInt32(searchTextBox.Text);
                                }
                                if (review.UserId == id){ selectReviews.Add(review); }
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (selectReviews == null)
                {
                    messageLabel.Content = "Geen resultaten";
                }
                else
                {
                    messageLabel.Content = "Er zijn " + selectReviews.Count + " resultaten gevonden!";
                    ReviewsDataGrid.ItemsSource = selectReviews;
                }
            }
            else
            {
                messageLabel.Content = "";
                LoadReviews();
            }
        }

        public async void LoadReviews()
        {
            IEnumerable<Review> reviews = await GetReviews();
            if (alleReviewsButton.IsChecked == true)
            {
                ReviewsDataGrid.ItemsSource = reviews;
            }
            else if (nbReviewsButton.IsChecked == true)
            {
                List<Review> selectReviews = new List<Review>();
                foreach (Review review in reviews)
                {
                    if (review.Flagged == "True" && review.Handled == false)
                    {
                        selectReviews.Add(review);
                    }
                }
                ReviewsDataGrid.ItemsSource = selectReviews;
            }            
        }

        public async Task<IEnumerable<Review>> GetReviews()
        {
            IEnumerable<Review> reviews = null;
            try {
                var reviewUrl = "/api/review";
                HttpResponseMessage response = await client.GetAsync(reviewUrl);
                
                if (response.IsSuccessStatusCode)
                {
                    reviews = await response.Content.ReadAsAsync<IEnumerable<Review>>();
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
            return reviews;
        }

        public async Task UpdateReview(Review review)
        {
            try {
                var reviewUrl = "/api/review/" + review.Id;
                HttpResponseMessage response = await client.PutAsJsonAsync(reviewUrl, review);

                if (response.IsSuccessStatusCode)
                {
                    LoadReviews();
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

        private async void ChangeStatusButton_Click(object sender, RoutedEventArgs e)
        {
            Review review = (Review)ReviewsDataGrid.CurrentItem;
            bool originalActive = review.Active;
            
            if (review.Handled == false && review.Flagged == "true" && review.Active == true)
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u deze review wilt deactiveren?"),
                    "Deactiveren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    review.Active = false;
                    review.Handled = true;
                }
            }
            else if (review.Active == true)
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u deze review wilt deactiveren?"),
                    "Deactiveren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    review.Active = false;
                }
            }
            else
            {
                if (MessageBox.Show(String.Format("Bent u zeker dat u deze review wilt activeren?"),
                    "Activeren", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    review.Active = true;
                }
            }

            if (originalActive != review.Active)
            {
                await UpdateReview(review);
            }
        }

        private async void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Review review = (Review)ReviewsDataGrid.CurrentItem;
            review.Handled = true;
            await UpdateReview(review);
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            Review review = (Review)ReviewsDataGrid.CurrentItem;
            ReviewDetailsWindow reviewDetailsWindow = new ReviewDetailsWindow(review);
            reviewDetailsWindow.ShowDialog();
        }

        private async void UserButton_Click(object sender, RoutedEventArgs e)
        {
            Review review = (Review)ReviewsDataGrid.CurrentItem;
            User user = await GetUser(review.UserId);
            UserDetailsWindow userDetails = new UserDetailsWindow(user);
            userDetails.ShowDialog();
        }
    }
}

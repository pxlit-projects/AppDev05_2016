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
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        HttpClient client = new HttpClient();
        HomeWindow scherm = (HomeWindow)Application.Current.MainWindow;
        private User detailsUser;

        public UserDetailsWindow(User user)
        {
            InitializeComponent();

            client.BaseAddress = new Uri("http://localhost:54238/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            detailsUser = user;
            detailsPanel.DataContext = user;

            string role = null;

            switch (user.RoleID)
            {
                case 1:
                    role = "Admin";
                    break;
                case 2:
                    role = "User";
                    break;
            }

            userLabel.Content = string.Format("{0} {1} ({2})", user.FirstName, user.LastName, role);
            GetCity();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public async void GetCity()
        {
            Cities city = null;
            try
            {
                var cityUrl = "/api/city/" + detailsUser.ZipCode;
                HttpResponseMessage response = await client.GetAsync(cityUrl);

                if (response.IsSuccessStatusCode)
                {
                    city = await response.Content.ReadAsAsync<Cities>();
                    homePlaceTextBox.Text = city.City;
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
        }
    }
}

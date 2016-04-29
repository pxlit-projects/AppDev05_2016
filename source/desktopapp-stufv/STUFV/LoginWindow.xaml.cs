using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            emailBox.GotFocus += EmailBox_GotFocus;
            emailBox.LostFocus += EmailBox_LostFocus;
            emailBox.KeyDown += EmailBox_KeyDown;

            passwordTextBox.GotFocus += PasswordTextBox_GotFocus;
            passwordBox.LostFocus += PasswordBox_LostFocus;
            passwordBox.KeyDown += PasswordBox_KeyDown;
        }

        private void EmailBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (emailBox.Text == "")
            {
                emailBox.Text = "E-mailadres";
                emailBox.Foreground = new SolidColorBrush(Colors.LightGray);
            }
        }

        private void EmailBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (emailBox.Text == "E-mailadres")
            {
                emailBox.Text = "";
                emailBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void EmailBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                passwordTextBox.Focus();
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length == 0)
            {
                passwordTextBox.Visibility = Visibility.Visible;
            }
        }

        private void PasswordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Visibility = Visibility.Hidden;
            passwordBox.Focus();
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            Login();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:26370/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var userUrl = "/api/User/" + emailBox.Text;
            //HttpResponseMessage response = await client.GetAsync(userUrl);
            //User user = null;
            //if (response.IsSuccessStatusCode)
            //{
            //    user = await response.Content.ReadAsAsync<User>();
            //}

            //this.Hide();
            HomeWindow homeWindow = new HomeWindow();
            Application.Current.MainWindow = homeWindow;
            homeWindow.ShowDialog();
        }
    }
}

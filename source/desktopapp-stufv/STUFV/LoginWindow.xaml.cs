using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
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
using System.Windows.Threading;

namespace STUFV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        HttpClient client = new HttpClient();
        HomeWindow homeWindow;
        DispatcherTimer loginTimer;
        private int attempts = 0;
        private int counter = 10;

        public LoginWindow()
        {
            InitializeComponent();

            emailBox.GotFocus += EmailBox_GotFocus;
            emailBox.LostFocus += EmailBox_LostFocus;
            emailBox.KeyDown += EmailBox_KeyDown;

            passwordTextBox.GotFocus += PasswordTextBox_GotFocus;
            passwordBox.LostFocus += PasswordBox_LostFocus;
            passwordBox.KeyDown += PasswordBox_KeyDown;

            loginTimer = new DispatcherTimer();
            loginTimer.Interval = TimeSpan.FromSeconds(1);
            loginTimer.Tick += LoginTimer_Tick;

            client.BaseAddress = new Uri("http://webapp-stufv20160527104738.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
            if (loginButton.IsEnabled == true)
            {
                errorBox.Content = "";
            }

            if (emailBox.Text == "E-mail")
            {
                emailBox.Text = "";
                emailBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void EmailBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                passwordTextBox.Focus();
            }
            else if (e.Key == Key.Enter)
            {
                Login();
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
            if (loginButton.IsEnabled == true)
            {
                errorBox.Content = "";
            }

            passwordTextBox.Visibility = Visibility.Hidden;
            passwordBox.Focus();
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                loginButton.Focus();
            }
            else if (e.Key == Key.Enter)
            {
                Login();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            loginButton.IsEnabled = false;
            Login();
        }

        private void LoginTimer_Tick(object sender, EventArgs e)
        {
            counter--;
            if (counter == 0)
            {
                loginTimer.Stop();
                errorBox.Content = "";
                loginButton.IsEnabled = true;
                counter = attempts * 5;
            }
            else
            {
                errorBox.Content = "Te veel pogingen. \nProbeer het opnieuw over " + counter + " seconden";
            }
        }

        private async void Login()
        {
            loginButton.IsEnabled = false;
            messageLabel.Content = "Velden controleren...";

            bool existEmail = await Exist(emailBox.Text);
            bool existPassword = false;

            if (existEmail)
            {
                User user = await GetUser(emailBox.Text);
                string salt = user.Salt;
                string encPassword = MD5Encrypt(passwordBox.Password, salt);

                existPassword = Login(user, encPassword);

                if (existPassword)
                {
                    messageLabel.Content = "Bezig met aanmelden...";
                    Login login = new Login();
                    login.UserId = user.Id;
                    login.DateTime = DateTime.Now;
                    InsertLogin(login);
                    homeWindow = new HomeWindow(user);
                    Application.Current.MainWindow = homeWindow;
                    homeWindow.Owner = Owner;
                    homeWindow.Show();
                    Close();
                }
                else {
                    errorBox.Content = "Verkeerd paswoord of geen toegang!";
                    passwordBox.Password = "";
                    messageLabel.Content = "";
                    loginButton.IsEnabled = true;
                    attempts++;
                }
            }
            else {
                errorBox.Content = "Email bestaat niet";
                messageLabel.Content = "";
                loginButton.IsEnabled = true;
                attempts++;
            }

            if (!(attempts < (counter / 5 + 1)))
            {
                loginButton.IsEnabled = false;
                counter = attempts * 5;
                loginTimer.Start();
            }
            else
            {
                loginButton.IsEnabled = true;
            }
        }

        public async Task<bool> Exist(String email)
        {
            try
            {
                IEnumerable<User> users = await GetUsers();

                for (int x = 0; x < users.Count(); x++)
                {
                    if (users.ElementAt(x).Email.Equals(email))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            
        }

        private static string MD5Encrypt(string password, string salt)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(salt + password));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public bool Login(User user, string password)
        {
            if (user.PassWord == password && user.RoleID == 1 && user.Active == true)
            {
                return true;
            }

            return false;
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
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw.",
                    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return users;
        }

        public async Task<User> GetUser(string email)
        {
            IEnumerable<User> users = await GetUsers();

            User user = null;
            for (int x = 0; x < users.Count(); x++)
            {
                if (users.ElementAt(x).Email.Equals(email))
                {
                    user = users.ElementAt(x);
                }
            }
            return user;
        }

        public async void InsertLogin(Login login)
        {
            try
            {
                var loginUrl = "/api/login";
                HttpResponseMessage response = await client.PostAsJsonAsync(loginUrl, login);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Verbinding met de server verbroken. Probeer later opnieuw.",
                    "Serverfout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

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

namespace STUFV {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        HttpClient client = new HttpClient ( );


        public LoginWindow ( ) {
            InitializeComponent ( );

            emailBox.GotFocus += EmailBox_GotFocus;
            emailBox.LostFocus += EmailBox_LostFocus;
            emailBox.KeyDown += EmailBox_KeyDown;

            passwordTextBox.GotFocus += PasswordTextBox_GotFocus;
            passwordBox.LostFocus += PasswordBox_LostFocus;
            passwordBox.KeyDown += PasswordBox_KeyDown;

            client.BaseAddress = new Uri ( "http://webapp-stufv20160429025210.azurewebsites.net/" );
            client.DefaultRequestHeaders.Accept.Clear ( );
            client.DefaultRequestHeaders.Accept.Add ( new MediaTypeWithQualityHeaderValue ( "application/json" ) );
        }

        private void EmailBox_LostFocus ( object sender, RoutedEventArgs e ) {
            if ( emailBox.Text == "" ) {
                emailBox.Text = "E-mailadres";
                emailBox.Foreground = new SolidColorBrush ( Colors.LightGray );
            }
        }

        private void EmailBox_GotFocus ( object sender, RoutedEventArgs e ) {
            if ( emailBox.Text == "E-mailadres" ) {
                emailBox.Text = "";
                emailBox.Foreground = new SolidColorBrush ( Colors.Black );
            }
        }

        private void EmailBox_KeyDown ( object sender, KeyEventArgs e ) {
            if ( e.Key == Key.Tab ) {
                passwordTextBox.Focus ( );
            }
        }

        private void PasswordBox_LostFocus ( object sender, RoutedEventArgs e ) {
            if ( passwordBox.Password.Length == 0 ) {
                passwordTextBox.Visibility = Visibility.Visible;
            }
        }

        private void PasswordTextBox_GotFocus ( object sender, RoutedEventArgs e ) {
            passwordTextBox.Visibility = Visibility.Hidden;
            passwordBox.Focus ( );
        }

        private void PasswordBox_KeyDown ( object sender, KeyEventArgs e ) {
            if ( e.Key == Key.Tab ) {
                loginButton.Focus ( );
                Login ( );
            }
        }

        private void LoginButton_Click ( object sender, RoutedEventArgs e ) {
            Login ( );
        }

        private async void Login ( ) {
            bool existEmail = await Exist ( emailBox.Text );
            bool existPassword = false;

            if ( existEmail ) {
                User user = await GetUser(emailBox.Text);
                string salt = user.Salt;
                string encPassword = MD5Encrypt ( passwordBox.Password, salt );

                existPassword = Login ( user , encPassword );

                if ( existPassword ) {
                    HomeWindow homeWindow = new HomeWindow ( user );
                    Application.Current.MainWindow = homeWindow;
                    homeWindow.ShowDialog ( );
                } else {
                    errorBox.Content = "Verkeerd paswoord of geen toegang!";
                }
            } else {
                errorBox.Content = "Email bestaat niet";
            }
        }

        public async Task<bool> Exist ( String email ) {
            IEnumerable<User> users = await GetUsers ( );

            for ( int x = 0 ; x < users.Count ( ) ; x++ ) {
                if ( users.ElementAt ( x ).Email.Equals ( email ) ) {
                    return true;
                }
            }
            return false;
        }

        private static string MD5Encrypt ( string password, string salt ) {
            MD5 md5 = new MD5CryptoServiceProvider ( );

            md5.ComputeHash ( ASCIIEncoding.ASCII.GetBytes ( salt + password ) );
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder ( );
            for ( int i = 0 ; i < result.Length ; i++ ) {
                strBuilder.Append ( result[ i ].ToString ( "x2" ) );
            }

            return strBuilder.ToString ( );
        }

        public bool Login ( User user, string password ) {
            if ( user.PassWord == password &&  user.RoleID == 1) {
                return true;
            }
            
            return false;
        }

        public async Task<IEnumerable<User>> GetUsers ( ) {
            var userUrl = "/api/user";
            HttpResponseMessage response = await client.GetAsync ( userUrl );
            IEnumerable<User> users = null;

            if ( response.IsSuccessStatusCode ) {
                users = await response.Content.ReadAsAsync<IEnumerable<User>> ( );
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
    }
}

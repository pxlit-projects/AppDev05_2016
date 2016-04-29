using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            userBox.GotFocus += UserBox_GotFocus;
            userBox.LostFocus += UserBox_LostFocus;
            userBox.KeyDown += UserBox_KeyDown;

            passwordTextBox.GotFocus += PasswordTextBox_GotFocus;
            passwordBox.LostFocus += PasswordBox_LostFocus;
            passwordBox.KeyDown += PasswordBox_KeyDown;
        }

        private void UserBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (userBox.Text == "")
            {
                userBox.Text = "Gebruikersnaam";
                userBox.Foreground = new SolidColorBrush(Colors.LightGray);
            }
        }

        private void UserBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (userBox.Text == "Gebruikersnaam")
            {
                userBox.Text = "";
                userBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void UserBox_KeyDown(object sender, KeyEventArgs e)
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
            this.Hide();
            HomeWindow homeWindow = new HomeWindow();
            Application.Current.MainWindow = homeWindow;
            homeWindow.ShowDialog();
        }
    }
}

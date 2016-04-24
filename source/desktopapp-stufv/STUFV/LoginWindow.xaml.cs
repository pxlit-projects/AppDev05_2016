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

            gebruikersBox.GotFocus += GebruikersBox_GotFocus;
            gebruikersBox.LostFocus += GebruikersBox_LostFocus;
            gebruikersBox.KeyDown += GebruikersBox_KeyDown;

            paswoordTextBox.GotFocus += PaswoordTextBox_GotFocus;
            paswoordBox.LostFocus += PaswoordBox_LostFocus;
            paswoordBox.KeyDown += PaswoordBox_KeyDown;
        }

        private void GebruikersBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (gebruikersBox.Text == "")
            {
                gebruikersBox.Text = "Gebruikersnaam";
                gebruikersBox.Foreground = new SolidColorBrush(Colors.LightGray);
            }
        }

        private void GebruikersBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (gebruikersBox.Text == "Gebruikersnaam")
            {
                gebruikersBox.Text = "";
                gebruikersBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void GebruikersBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                paswoordTextBox.Focus();
            }
        }

        private void PaswoordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (paswoordBox.Password.Length == 0)
            {
                paswoordTextBox.Visibility = Visibility.Visible;
            }
        }

        private void PaswoordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            paswoordTextBox.Visibility = Visibility.Hidden;
            paswoordBox.Focus();
        }

        private void PaswoordBox_KeyDown(object sender, KeyEventArgs e)
        {
            Aanmelden();
        }

        private void aanmeldButton_Click(object sender, RoutedEventArgs e)
        {
            Aanmelden();
        }

        private void Aanmelden()
        {
            this.Hide();
            HomeWindow homeWindow = new HomeWindow();
            Application.Current.MainWindow = homeWindow;
            homeWindow.ShowDialog();
        }
    }
}

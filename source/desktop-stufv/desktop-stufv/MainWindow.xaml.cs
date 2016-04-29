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
using MahApps.Metro.Controls;
using webapp_stufv.Models;

namespace desktop_stufv {

    public partial class MainWindow : MetroWindow {

        private HttpClient _client;

        public MainWindow ( ) {
            InitializeComponent ( );
            InitializeClient ( );
            setTabs ( );
        }

        private void InitializeClient() {
            _client = new HttpClient ( );
            _client.BaseAddress = new Uri ( "http://webapp-stufv20160429025210.azurewebsites.net/" );
            _client.DefaultRequestHeaders.Accept.Clear ( );
            _client.DefaultRequestHeaders.Accept.Add ( new MediaTypeWithQualityHeaderValue ( "application/json" ) );
        }

        private void setTabs() {
            bindUsersList ( );
        }

        private void bindUsersList ( ) {
            IEnumerable<User> users = getUsers ( );
            if (users != null ) {
                bindUsers ( users );
            }
        }

        private void bindUsers (IEnumerable<User> users) {
            usersList.ItemsSource = users;
        }

        private IEnumerable<User> getUsers ( ) {
            var usersUrl = "api/user";
            HttpResponseMessage response = _client.GetAsync ( usersUrl ).Result;

            if ( response.IsSuccessStatusCode ) {
                IEnumerable<User> users = response.Content.ReadAsAsync<IEnumerable<User>> ( ).Result;
                return users;
            }

            return null;
        }
    }
}

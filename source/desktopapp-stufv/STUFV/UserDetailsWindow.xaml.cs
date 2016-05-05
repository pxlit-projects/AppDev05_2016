using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace STUFV
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        public UserDetailsWindow(User user)
        {
            InitializeComponent();

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

            userLabel.Content = String.Format("{0} {1} ({2})", user.FirstName, user.LastName, role);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

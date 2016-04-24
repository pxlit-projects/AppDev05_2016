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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();

            menuBox.SelectionChanged += MenuBox_SelectionChanged;

            List<Organisation> organisations = new List<Organisation>
            {
                new Organisation {Name = "STUFV", Description = "blabla", Active = true },
                new Organisation {Name = "PXL", Description = "geen commentaar", Active = false },
                new Organisation {Name = "test", Description = "dit is een hele lange tekst. dit is een hele lange tekst" +
                                                            "dit is een hele lange tekst. dit is een hele lange tekst.", Active = true }
            };

            List<Review> reviews = new List<Review>
            {
                new Review {Id=1, Active  =true, Content="Looooool"}
            };

            nieuwOrganisatieDataGrid.DataContext = organisations;
            beheerOrganisatieDataGrid.DataContext = organisations;
        }

        private void MenuBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = menuBox.SelectedIndex;

            switch (index)
            {
                case 0:
                    closeGrids();
                    homeGrid.Visibility = Visibility.Visible;
                    break;
                case 1:
                    closeGrids();
                    artikelGrid.Visibility = Visibility.Visible;
                    break;
                case 2:
                    closeGrids();
                    organisatieGrid.Visibility = Visibility.Visible;
                    break;
                case 3:
                    closeGrids();
                    reviewsGrid.Visibility = Visibility.Visible;
                    break;
                case 4:
                    closeGrids();
                    gebruikersGrid.Visibility = Visibility.Visible;
                    break;
                case 5:
                    closeGrids();
                    statistiekenGrid.Visibility = Visibility.Visible;
                    break;
                case 6:
                    closeGrids();
                    logoutGrid.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void closeGrids()
        {
            homeGrid.Visibility = Visibility.Hidden;
            artikelGrid.Visibility = Visibility.Hidden;
            organisatieGrid.Visibility = Visibility.Hidden;
            reviewsGrid.Visibility = Visibility.Hidden;
            gebruikersGrid.Visibility = Visibility.Hidden;
            statistiekenGrid.Visibility = Visibility.Hidden;
            logoutGrid.Visibility = Visibility.Hidden;
        }
    }
}

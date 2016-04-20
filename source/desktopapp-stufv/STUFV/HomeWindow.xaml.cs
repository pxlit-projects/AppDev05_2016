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

            //homeItem.MouseEnter += MenuItem_MouseEnter;
            //artikelItem.MouseEnter += MenuItem_MouseEnter;
            //controleOrganisatiesItem.MouseEnter += MenuItem_MouseEnter;
            //controleReviewsItem.MouseEnter += MenuItem_MouseEnter;
            //beheerGebrItem.MouseEnter += MenuItem_MouseEnter;
            //statistiekenItem.MouseEnter += MenuItem_MouseEnter;
            //logoutItem.MouseEnter += MenuItem_MouseEnter;
        }

        //private void MenuItem_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    ListBoxItem item = (ListBoxItem)sender;
        //    item.Background = new SolidColorBrush(Colors.DarkGray);
        //}
    }
}

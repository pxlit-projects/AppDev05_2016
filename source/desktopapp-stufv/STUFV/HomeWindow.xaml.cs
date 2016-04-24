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

            List<Organisation> organisations = new List<Organisation>
            {
                new Organisation {Name = "STUFV", Description = "blabla", Active = true },
                new Organisation {Name = "PXL", Description = "geen commentaar", Active = false },
                new Organisation {Name = "test", Description = "dit is een hele lange tekst. dit is een hele lange tekst" +
                                                            "dit is een hele lange tekst. dit is een hele lange tekst.", Active = true }
            };

            nieuwOrganisatieDataGrid.DataContext = organisations;
            beheerOrganisatieDataGrid.DataContext = organisations;
        }
    }
}

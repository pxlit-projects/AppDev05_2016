﻿using System;
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
    /// Interaction logic for ReviewDetailsWindow.xaml
    /// </summary>
    public partial class ReviewDetailsWindow : Window
    {
        public ReviewDetailsWindow(Review review)
        {
            InitializeComponent();

            detailsPanel.DataContext = review;


        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}

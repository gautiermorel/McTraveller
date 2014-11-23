using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MacdonaldsHackathon2014
{
    public partial class StartScreen : PhoneApplicationPage
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        void PrintText(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            //Redirection 
            NavigationService.Navigate(new Uri("/HomeScreen.xaml", UriKind.Relative));
        }

    }
}
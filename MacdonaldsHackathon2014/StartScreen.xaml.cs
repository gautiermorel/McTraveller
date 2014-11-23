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
            if (lbi.Content.ToString() == "McDonald's Free Wifi")
            {
                NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("You have to be connected to a McDonald's network");
            }
            

        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MacdonaldsHackathon2014.Resources;

namespace MacdonaldsHackathon2014
{
    public partial class HomeScreen : PhoneApplicationPage
    {
        public User temporaryUser { get; set; }
        // Constructeur
        public HomeScreen()
        {
            InitializeComponent();
            

            // For the demonstration
            temporaryUser = new User("McGuest", "toto112", "toto112@toto.net");

            PhoneApplicationService.Current.State["param"] = temporaryUser;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Quizz.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MeetHome.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            temporaryUser = (User)PhoneApplicationService.Current.State["param"];
            PhoneApplicationService.Current.State["param"] = temporaryUser;
            base.OnNavigatedTo(e);
        }
    }
}
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
    public partial class Result : PhoneApplicationPage
    {
        public Result()
        {
            InitializeComponent();
        }

        private void Retry_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Quizz.xaml", UriKind.Relative));

        }

        private void Meetup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MeetHome.xaml", UriKind.Relative));
        }
    }
}
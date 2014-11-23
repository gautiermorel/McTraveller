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
    public partial class Register : PhoneApplicationPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = (TextBox)sender;

            t.Text = "";
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox t = (TextBox)sender;

            if (string.IsNullOrEmpty(t.Text))
                t.Text = "Nickname";
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox t = (TextBox)sender;

            if (string.IsNullOrEmpty(t.Text))
                t.Text = "Nickname";
        }

        private void TextBox_LostFocus_2(object sender, RoutedEventArgs e)
        {
            TextBox t = (TextBox)sender;

            if (string.IsNullOrEmpty(t.Text))
                t.Text = "Email address";
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HomeScreen.xaml", UriKind.Relative));
        }
    }
}
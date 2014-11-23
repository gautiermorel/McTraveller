﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace MacdonaldsHackathon2014
{
    public partial class FillMeetForm : PhoneApplicationPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<int> ListAge { get; set; }
        public User CurrentUser { get; set; }

        public FillMeetForm()
        {
            InitializeComponent();
            this.DataContext = this;

            this.ListAge = new List<int>();
            for (int i = 16; i < 99; i++)
                ListAge.Add(i);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask photoChooserTask = new PhotoChooserTask();

            photoChooserTask.Completed += photoChooserTask_Completed;
            photoChooserTask.Show();
        }

        void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage img = new BitmapImage();
                img.SetSource(e.ChosenPhoto);

                //pictureChoose.Source = img;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (PhoneApplicationService.Current.State.Keys.Contains("param"))
                CurrentUser = (User)PhoneApplicationService.Current.State["param"];

            base.OnNavigatedTo(e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (PhoneApplicationService.Current.State.Keys.Contains("param"))
                CurrentUser = (User)PhoneApplicationService.Current.State["param"];

            try
            {
                if (male.IsChecked == true)
                    CurrentUser.Gender = "Male";
                else if (female.IsChecked == true)
                    CurrentUser.Gender = "Female";
                else
                    throw new Exception("Please select your gender");

                if (age.SelectedItem == null)
                    throw new Exception("Please select your age");
                else
                    CurrentUser.Age = (int)age.SelectedItem;

                if (bike.IsChecked == true)
                    CurrentUser.AddActivity(bike.ToString());
                if (museum.IsChecked == true)
                    CurrentUser.AddActivity(museum.ToString());
                if (computer.IsChecked == true)
                    CurrentUser.AddActivity(computer.ToString());
                if (eat.IsChecked == true)
                    CurrentUser.AddActivity(eat.ToString());
                if (nightclub.IsChecked == true)
                    CurrentUser.AddActivity(nightclub.ToString());
                if (eat.IsChecked == true)
                    CurrentUser.AddActivity(eat.ToString());
                if (meet.IsChecked == true)
                    CurrentUser.AddActivity(meet.ToString());

                if (CurrentUser.Activities.Count == 0)
                    throw new Exception("Please select at least one activity");

                if (fr.IsChecked == true)
                    CurrentUser.AddLanguage(fr.ToString());
                if (sp.IsChecked == true)
                    CurrentUser.AddLanguage(sp.ToString());
                if (en.IsChecked == true)
                    CurrentUser.AddLanguage(en.ToString());
                if (ch.IsChecked == true)
                    CurrentUser.AddLanguage(ch.ToString());
                if (it.IsChecked == true)
                    CurrentUser.AddLanguage(it.ToString());
                if (se.IsChecked == true)
                    CurrentUser.AddLanguage(se.ToString());

                if (CurrentUser.Languages.Count == 0)
                    throw new Exception("Please select at least one language");

                PhoneApplicationService.Current.State["current"] = CurrentUser;
                NavigationService.Navigate(new Uri("/MeetHome.xaml", UriKind.Relative));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
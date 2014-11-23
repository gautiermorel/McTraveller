using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MacdonaldsHackathon2014
{
    public partial class MeetHome : PhoneApplicationPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                NotifyPropertyChanged("CurrentUser");
            }
        }

        private ObservableCollection<User> _listPhonesConnected;
        public ObservableCollection<User> ListPhonesConnected
        {
            get { return _listPhonesConnected; }
            set
            {
                _listPhonesConnected = value;
                NotifyPropertyChanged("ListPhonesConnected");
            }
        }

        public List<Connection> ListConnections { get; set; }

        public MeetHome()
        {
            InitializeComponent();
            this.DataContext = this;

            CurrentUser = (User)PhoneApplicationService.Current.State["param"];

            ListPhonesConnected = new ObservableCollection<User>();
            User tmp1 = new User("Daphné", "toto123", "daphné123@toto.net");
            tmp1.Age = 21;
            tmp1.Gender = "Female";
            tmp1.AddActivity("NightClub");
            tmp1.AddActivity("Biking");
            tmp1.AddLanguage("French");
            User tmp2 = new User("Pierre", "toto123", "PierreDeFeu@titi.net");
            tmp2.Age = 35;
            tmp2.Gender = "Male";
            tmp2.AddActivity("Music");
            tmp2.AddLanguage("French");
            tmp2.AddLanguage("Spanish");
            ListPhonesConnected.Add(tmp1);
            ListPhonesConnected.Add(tmp2);
            User tmp3 = new User("Elisabeth", "toto123", "daphné123@toto.net");
            tmp3.Age = 21;
            tmp3.Gender = "Female";
            tmp3.AddActivity("NightClub");
            tmp3.AddActivity("Biking");
            tmp3.AddLanguage("French");
            User tmp4 = new User("Paul", "toto123", "PierreDeFeu@titi.net");
            tmp4.Age = 35;
            tmp4.Gender = "Male";
            tmp4.AddActivity("Music");
            tmp4.AddLanguage("French");
            tmp4.AddLanguage("Spanish");
            ListPhonesConnected.Add(tmp3);
            ListPhonesConnected.Add(tmp4);
            User tmp5 = new User("Laura", "toto123", "daphné123@toto.net");
            tmp5.Age = 21;
            tmp5.Gender = "Female";
            tmp5.AddActivity("NightClub");
            tmp5.AddActivity("Biking");
            tmp5.AddLanguage("French");
            User tmp6 = new User("José", "toto123", "PierreDeFeu@titi.net");
            tmp6.Age = 35;
            tmp6.Gender = "Male";
            tmp6.AddActivity("Music");
            tmp6.AddLanguage("French");
            tmp6.AddLanguage("Spanish");
            ListPhonesConnected.Add(tmp5);
            ListPhonesConnected.Add(tmp6);
            User tmp7 = new User("Bernadette", "toto123", "daphné123@toto.net");
            tmp7.Age = 21;
            tmp7.Gender = "Female";
            tmp7.AddActivity("NightClub");
            tmp7.AddActivity("Biking");
            tmp7.AddLanguage("French");
            User tmp8 = new User("Walter", "toto123", "PierreDeFeu@titi.net");
            tmp8.Age = 35;
            tmp8.Gender = "Male";
            tmp8.AddActivity("Music");
            tmp8.AddLanguage("French");
            tmp8.AddLanguage("Spanish");
            ListPhonesConnected.Add(tmp7);
            ListPhonesConnected.Add(tmp8);

            this.ListConnections = new List<Connection>();
            this.ListConnections.Add(new Connection() { ConnectedFrom = CurrentUser.Username, ConnectedTo = "Daphné" });
            this.ListConnections.Add(new Connection() { ConnectedFrom = "Pierre", ConnectedTo = CurrentUser.Username });

            foreach (Connection connection in ListConnections)
            {
                if (connection.ConnectedFrom == CurrentUser.Username)
                {
                    User tempUser = ListPhonesConnected.Where(x => x.Username == connection.ConnectedTo).FirstOrDefault();
                    if (tempUser != null)
                        tempUser.ImConnectedToThisUser = true;
                }
                else if (connection.ConnectedTo == CurrentUser.Username)
                {
                    User tempUser = ListPhonesConnected.Where(x => x.Username == connection.ConnectedFrom).FirstOrDefault();
                    if (tempUser != null)
                        tempUser.IsConnectedToMe = true;
                }
            }
        }

        private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User selectedUser = (User)((LongListSelector)sender).SelectedItem;

            if (selectedUser != null)
            {
                PhoneApplicationService.Current.State["param"] = selectedUser;
                PhoneApplicationService.Current.State["current"] = CurrentUser;
                PhoneApplicationService.Current.State["connections"] = ListConnections;
                NavigationService.Navigate(new Uri("/MeetZoomPeople.xaml", UriKind.Relative));
            }
            ((LongListSelector)sender).SelectedItem = null;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (PhoneApplicationService.Current.State.Keys.Contains("current"))
                CurrentUser = (User)PhoneApplicationService.Current.State["current"];

            //if (CurrentUser.Age == -1)
            //    NavigationService.Navigate(new Uri("/FillMeetForm.xaml", UriKind.Relative));

            User userSelected = null;
            if (PhoneApplicationService.Current.State.Keys.Contains("param"))
                userSelected = (User)PhoneApplicationService.Current.State["param"];

            if (PhoneApplicationService.Current.State.Keys.Contains("connections"))
                ListConnections = (List<Connection>)PhoneApplicationService.Current.State["connections"];

            User tmp = ListPhonesConnected.Where(x => x.Username == userSelected.Username).FirstOrDefault();

            if (tmp != null)
                tmp = userSelected;

            base.OnNavigatedTo(e);
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            PhoneApplicationService.Current.State["param"] = CurrentUser;
            base.OnBackKeyPress(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<User> listMatchedUsers = new List<User>();
            foreach (Connection connect in ListConnections)
            {
                if (connect.ConnectedFrom == CurrentUser.Username)
                {
                    foreach (Connection connect1 in ListConnections)
                    {
                        if (connect1 != connect && connect1.ConnectedFrom == connect.ConnectedTo && connect1.ConnectedTo == CurrentUser.Username)
                        {
                            User tmpUser = ListPhonesConnected.Where(x => x.Username == connect1.ConnectedFrom).FirstOrDefault();
                            if (tmpUser != null)
                            {
                                if (listMatchedUsers.Where(x => x.Username == tmpUser.Username).FirstOrDefault() == null)
                                {
                                    listMatchedUsers.Add(tmpUser);
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (connect.ConnectedTo == CurrentUser.Username)
                {
                    foreach (Connection connect1 in ListConnections)
                    {
                        if (connect1 != connect && connect1.ConnectedTo == connect.ConnectedFrom && connect1.ConnectedFrom == CurrentUser.Username)
                        {
                            User tmpUser = ListPhonesConnected.Where(x => x.Username == connect1.ConnectedTo).FirstOrDefault();
                            if (tmpUser != null)
                            {
                                if (listMatchedUsers.Where(x => x.Username == tmpUser.Username).FirstOrDefault() == null)
                                {
                                    listMatchedUsers.Add(tmpUser);
                                    break;
                                }
                            }
                        }
                    }
                }
            }


            //foreach (Connection connection in ListConnections)
            //{
            //    if (connection.ConnectedFrom == CurrentUser.Username)
            //    {
            //        User tempUser = ListPhonesConnected.Where(x => x.Username == connection.ConnectedTo).FirstOrDefault();
            //        if (tempUser != null)
            //        {
            //            foreach (Connection connection1 in ListConnections)
            //            {
            //                if (connection1.ConnectedFrom == tempUser.Username)
            //                {
            //                    listMatchedUsers.Add(tempUser);
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //    else if (connection.ConnectedTo == CurrentUser.Username)
            //    {
            //        User tempUser = ListPhonesConnected.Where(x => x.Username == connection.ConnectedFrom).FirstOrDefault();
            //        if (tempUser != null)
            //        {
            //            foreach (Connection connection1 in ListConnections)
            //            {
            //                if (connection1.ConnectedFrom == tempUser.Username)
            //                {
            //                    listMatchedUsers.Add(tempUser);
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //}

            PhoneApplicationService.Current.State["connections"] = ListConnections;
            PhoneApplicationService.Current.State["MacthedUsers"] = listMatchedUsers;
            NavigationService.Navigate(new Uri("/MutualConnections.xaml", UriKind.Relative));
        }

        private bool CheckConnectionExist(List<Connection> ListConnections, string from, string to)
        {
            foreach (Connection c in ListConnections)
            {
                if (c.ConnectedFrom == from && c.ConnectedTo == to)
                    return true;
            }
            return false;
        }
    }
}
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

namespace MacdonaldsHackathon2014
{
    public partial class MeetZoomPeople : PhoneApplicationPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private User _userSelected;
        public User UserSelected
        {
            get { return _userSelected; }
            set
            {
                _userSelected = value;
                NotifyPropertyChanged("UserSelected");
            }
        }

        public User CurrentUser { get; set; }

        public List<Connection> ListConnections { get; set; }

        public MeetZoomPeople()
        {
            InitializeComponent();
            this.DataContext = this;

            UserSelected = (User)PhoneApplicationService.Current.State["param"];
            CurrentUser = (User)PhoneApplicationService.Current.State["current"];
            ListConnections = (List<Connection>)PhoneApplicationService.Current.State["connections"];
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            PhoneApplicationService.Current.State["param"] = UserSelected;

            base.OnBackKeyPress(e);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            CurrentUser = (User)PhoneApplicationService.Current.State["current"];
            if (cb.IsChecked == true)
            {
                if (!string.IsNullOrEmpty((string)cb.CommandParameter) && CurrentUser.Username != (string)cb.CommandParameter)
                {
                    if (!CheckConnectionExist(ListConnections, CurrentUser.Username, (string)cb.CommandParameter))
                        ListConnections.Add(new Connection() { ConnectedFrom = CurrentUser.Username, ConnectedTo = (string)cb.CommandParameter });
                }
            }
            else
            {
                if (!string.IsNullOrEmpty((string)cb.CommandParameter) && CurrentUser.Username != (string)cb.CommandParameter)
                {
                    if (!CheckConnectionExist(ListConnections, CurrentUser.Username, (string)cb.CommandParameter))
                        ListConnections.Remove(ListConnections.Where(x => x.ConnectedFrom == CurrentUser.Username && x.ConnectedTo == (string)cb.CommandParameter).FirstOrDefault());
                }
            }
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
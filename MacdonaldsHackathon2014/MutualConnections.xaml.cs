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
    public partial class MutualConnections : PhoneApplicationPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<User> _matchedUsers;
        public ObservableCollection<User> MatchedUsers
        {
            get { return _matchedUsers; }
            set
            {
                _matchedUsers = value;
                NotifyPropertyChanged("MatchedUsers");
            }
        }


        public MutualConnections()
        {
            InitializeComponent();
            this.DataContext = this;

            MatchedUsers = new ObservableCollection<User>((List<User>)PhoneApplicationService.Current.State["MacthedUsers"]);
        }
    }
}
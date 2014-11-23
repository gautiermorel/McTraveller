using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MacdonaldsHackathon2014
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }
        public Image Picture { get; set; }

        public List<string> Languages { get; set; }
        public List<string> Activities { get; set; }

        public bool IsConnectedToMe { get; set; }
        public bool ImConnectedToThisUser { get; set; }

        public string LanguagesToShow { get; set; }
        public string ActivitiesToShow { get; set; }

        public int Points { get; set; }

        public User() { }

        public User(string username, string password, string email)
        {
            Points = 0;
            this.Age = -1;

            this.IsConnectedToMe = false;
            this.ImConnectedToThisUser = false;

            this.Username = username;
            this.Password = password;
            this.Languages = new List<string>();
            this.Activities = new List<string>();
        }

        public void AddLanguage(string language)
        {
            this.Languages.Add(language);
            if (this.Languages.Count <= 2)
            {
                if (string.IsNullOrEmpty(LanguagesToShow))
                    LanguagesToShow = language;
                else
                    LanguagesToShow += ", " + language;
            }
            else if (this.Languages.Count > 2)
                LanguagesToShow += ", ...";
        }

        public void AddActivity(string activity)
        {
            this.Activities.Add(activity);
            if (this.Activities.Count <= 2)
            {
                if (string.IsNullOrEmpty(ActivitiesToShow))
                    ActivitiesToShow = activity;
                else
                    ActivitiesToShow += ", " + activity;
            }
            else if (this.Activities.Count > 2)
                ActivitiesToShow += ", ...";
        }

    }
}

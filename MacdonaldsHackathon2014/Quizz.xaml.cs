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
    public partial class Quizz : PhoneApplicationPage, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<Question> _listQuestions;
        public ObservableCollection<Question> ListQuestions
        {
            get { return _listQuestions; }
            set
            {
                _listQuestions = value;
                NotifyPropertyChanged("ListQuestion");
            }
        }

        public Quizz()
        {
            InitializeComponent();
            this.DataContext = this;

            this.ListQuestions = new ObservableCollection<Question>();

            this.ListQuestions.Add(new Question("This is the first question. What do you think about it ? :D",
                                                new Answer("This is answer 1", false),
                                                new Answer("this is answer 2", false),
                                                new Answer("this is answer 3", true),
                                                new Answer("this is answer 4", false)));

            this.ListQuestions.Add(new Question("This is the question 2. What do you think about it ? :D",
                                    new Answer("This is answer 1", false),
                                    new Answer("this is answer 2", false),
                                    new Answer("this is answer 3", true),
                                    new Answer("this is answer 4", false)));

            this.ListQuestions.Add(new Question("This is the question 3. What do you think about it ? :D",
                        new Answer("This is answer 1", false),
                        new Answer("this is answer 2", false),
                        new Answer("this is answer 3", true),
                        new Answer("this is answer 4", false)));

            this.ListQuestions.Add(new Question("This is the question 4. What do you think about it ? :D",
                        new Answer("This is answer 1", false),
                        new Answer("this is answer 2", false),
                        new Answer("this is answer 3", true),
                        new Answer("this is answer 4", false)));

            this.ListQuestions.Add(new Question("This is the question 5. What do you think about it ? :D",
                        new Answer("This is answer 1", false),
                        new Answer("this is answer 2", false),
                        new Answer("this is answer 3", true),
                        new Answer("this is answer 4", false)));

            this.ListQuestions.Add(new Question("This is the question 6. What do you think about it ? :D",
                        new Answer("This is answer 1", false),
                        new Answer("this is answer 2", false),
                        new Answer("this is answer 3", true),
                        new Answer("this is answer 4", false)));

            this.ListQuestions.Add(new Question("This is the question 7. What do you think about it ? :D",
                        new Answer("This is answer 1", false),
                        new Answer("this is answer 2", false),
                        new Answer("this is answer 3", true),
                        new Answer("this is answer 4", false)));

            this.ListQuestions.Add(new Question("This is the question 8. What do you think about it ? :D",
                        new Answer("This is answer 1", false),
                        new Answer("this is answer 2", false),
                        new Answer("this is answer 3", true),
                        new Answer("this is answer 4", false)));

            this.ListQuestions.Add(new Question("This is the question 9. What do you think about it ? :D",
                        new Answer("This is answer 1", false),
                        new Answer("this is answer 2", false),
                        new Answer("this is answer 3", true),
                        new Answer("this is answer 4", false)));

            this.ListQuestions.Add(new Question("This is the question 10. What do you think about it ? :D",
                        new Answer("This is answer 1", false),
                        new Answer("this is answer 2", false),
                        new Answer("this is answer 3", true),
                        new Answer("this is answer 4", false)));

        }
    }
}
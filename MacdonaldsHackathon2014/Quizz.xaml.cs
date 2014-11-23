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

        private void SubmitAll_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Result.xaml", UriKind.Relative));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MeetHome.xaml", UriKind.Relative));
        }

        public Quizz()
        {
            InitializeComponent();
            this.DataContext = this;

            this.ListQuestions = new ObservableCollection<Question>();

            this.ListQuestions.Add(new Question("What is the name of the Church in Westminster?",
                        new Answer("Church of Westminster", false),
                        new Answer("Saint Paul's Cathedral", false),
                        new Answer("Westminster Abbey", true),
                        new Answer("Parliament Abbey", false),
                        "The current abbey was built between 1245 and 1272, under the direction of King Henry III."));

            this.ListQuestions.Add(new Question("Who Lives in Buckingham palace?",
                        new Answer("Prime Minister Of UK", false),
                        new Answer("Queen", true),
                        new Answer("Judge Of the Court", false),
                        new Answer("Royal Guard", false),
                        "Buckingham Palace is the home of the Queen and Prince Philip."));

            this.ListQuestions.Add(new Question("In times of peace, whose priority was it to rebuild Westminster ?",
                        new Answer("Mark the Builder", false),
                        new Answer("Bob the builder", false),
                        new Answer("Steve the Builder", false),
                        new Answer("Henry the Builder", true),
                        "In Henry's reign there were no major wars, so he could spend his time on building projects, and his first priority was the rebuilding of Westminster Abbey."));

            this.ListQuestions.Add(new Question("Which of these statues can be found it Leicester Square?",
                        new Answer("Robert Burns", false),
                        new Answer("William Wallace", false),
                        new Answer("Sir Isaac Newton", true),
                        new Answer("Winston Churchill", false),
                        "Newton’s mother wanted Isaac to become a farmer, but Isaac had no interest in farming exams and failed."));

            this.ListQuestions.Add(new Question("How many rooms does Buckingham Palace hold?",
                        new Answer("550", false),
                        new Answer("346", false),
                        new Answer("775", true),
                        new Answer("120", false),
                        "Buckingham Palace has 775 rooms. These include 19 State rooms, 52 Royal and guest bedrooms, 188 staff bedrooms, 92 offices and 78 bathrooms."));

            this.ListQuestions.Add(new Question("Which of these London street markets, in its full version, is held on Sundays only?",
                        new Answer("Petticoat Lane", false),
                        new Answer("Berwick Street", false),
                        new Answer("Portobello Market", true),
                        new Answer("Leather Lane", false),
                        "Petticoat Lane - Leather Lane is in Holborn. Berwick street is in Soho. Portobello Market is in the Notting Hill area. 'Petticoat Lane' is the name given to the Sunday Market in and near Middlesex Street."));

            this.ListQuestions.Add(new Question("Which of these tube station are in the City of Westminster ?",
                        new Answer("Holborn", false),
                        new Answer("Liverpool Street Station", false),
                        new Answer("Hyde Park Corner", true),
                        new Answer("Kings Cross", false),
                        "Hyde Park spreads over 350 acres."));

            this.ListQuestions.Add(new Question("Which of these tube station are in the City of Westminster?",
                        new Answer("Camden Town", false),
                        new Answer("Earls Court", false),
                        new Answer("Leicester Square", true),
                        new Answer("Euston Square", false),
                        "Leicester Square is the centre of London's cinema land, The square is the prime location in London for world leading film premières and co-hosts the London Film Festival each year."));

            this.ListQuestions.Add(new Question("which one is the tallest Skyscraper in London?",
                        new Answer("Tower of London", false),
                        new Answer("Canada square", false),
                        new Answer("The Shard", true),
                        new Answer("Heron tower", false),
                        "The Shard is 87-storey skyscraper in London that is approximately 309 metres (1,014 ft) high, the Shard is currently the tallest building in the Europe."));

            this.ListQuestions.Add(new Question("What is the name of London's most complete park, with playground, gardens, water sports, picnic area, etc... ?",
                        new Answer("Griffith Park", false),
                        new Answer("Hyde Park", false),
                        new Answer("Regents Park", true),
                        new Answer("Central Park", false),
                        "Designed by John Nash in the early 1800s, Regents Park was originally meant to be the grounds for a country villa for the prince regent. "));

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            a1.Text = "Oops. " + this.ListQuestions[0].Tips;
            a1.Visibility = Visibility.Visible;
            r1.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            a1.Text = "Oops. " + this.ListQuestions[0].Tips;
            a1.Visibility = Visibility.Visible;
            r1.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_2(object sender, RoutedEventArgs e)
        {
            a1.Text = "Right. " + this.ListQuestions[0].Tips;
            a1.Visibility = Visibility.Visible;
            r1.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_3(object sender, RoutedEventArgs e)
        {
            a1.Text = "Oops. " + this.ListQuestions[0].Tips;
            a1.Visibility = Visibility.Visible;
            r1.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_4(object sender, RoutedEventArgs e)
        {
            a2.Text = "Oops. " + this.ListQuestions[1].Tips;
            a2.Visibility = Visibility.Visible;
            r2.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_5(object sender, RoutedEventArgs e)
        {
            a2.Text = "Right. " + this.ListQuestions[1].Tips;
            a2.Visibility = Visibility.Visible;
            r2.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_6(object sender, RoutedEventArgs e)
        {
            a2.Text = "Oops. " + this.ListQuestions[1].Tips;
            a2.Visibility = Visibility.Visible;
            r2.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_7(object sender, RoutedEventArgs e)
        {
            a2.Text = "Oops. " + this.ListQuestions[1].Tips;
            a2.Visibility = Visibility.Visible;
            r2.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_8(object sender, RoutedEventArgs e)
        {
            a3.Text = "Oops. " + this.ListQuestions[2].Tips;
            a3.Visibility = Visibility.Visible;
            r3.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_9(object sender, RoutedEventArgs e)
        {
            a3.Text = "Oops. " + this.ListQuestions[2].Tips;
            a3.Visibility = Visibility.Visible;
            r3.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_10(object sender, RoutedEventArgs e)
        {
            a3.Text = "Oops. " + this.ListQuestions[2].Tips;
            a3.Visibility = Visibility.Visible;
            r3.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_11(object sender, RoutedEventArgs e)
        {
            a3.Text = "Right. " + this.ListQuestions[2].Tips;
            a3.Visibility = Visibility.Visible;
            r3.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_12(object sender, RoutedEventArgs e)
        {
            a4.Text = "Oops. " + this.ListQuestions[9].Tips;
            a4.Visibility = Visibility.Visible;
            r4.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_13(object sender, RoutedEventArgs e)
        {
            a4.Text = "Oops. " + this.ListQuestions[9].Tips;
            a4.Visibility = Visibility.Visible;
            r4.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_14(object sender, RoutedEventArgs e)
        {
            a4.Text = "Right. " + this.ListQuestions[9].Tips;
            a4.Visibility = Visibility.Visible;
            r4.Visibility = Visibility.Visible;
        }

        private void RadioButton_Click_15(object sender, RoutedEventArgs e)
        {
            a4.Text = "Oops. " + this.ListQuestions[9].Tips;
            a4.Visibility = Visibility.Visible;
            r4.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HomeScreen.xaml", UriKind.Relative));
        }

        private void RadioButton_Click_16(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Click_17(object sender, RoutedEventArgs e)
        {

        }
    }
}
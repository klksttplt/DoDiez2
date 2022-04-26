using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Regex _regex;
        public MainWindow()
        {
            InitializeComponent();
            DatePicker1.SelectedDate = DateTime.Today.AddDays(-1);
            InfoText.Text = "Pick a date!";
            _regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",RegexOptions.CultureInvariant | RegexOptions.Singleline);
        }

        private void FillText( Person person)
        {
           var text = person.name + " " + person.surname + " with email " + person.email + " was born " +
                   person.birth.ToString() +
                   (person.IsAdult ? ", is adult " : ", is not adult ") + "\n" + person.name + " " +
                   person.surname + " is " + person.SunSign + " and " + person.ChineseSign +
                   (person.IsBirthday ? "\nIt's their birthday!" : "\nIt's not their birthday :c");
            InfoText.Text = text;
        }

        private void CheckData()
        {
            if (NameText.Text == "" && SurnameText.Text == "" && EmailText.Text == "")
                throw new EmptyFieldsException("Fields cannot be empty");
            if (!_regex.IsMatch(EmailText.Text)) throw new EmailFormatException("Wrong email format");
            if (DatePicker1.SelectedDate.Value > DateTime.Today)
                throw new FutureBirthException("You can't set birthday in the future");
            if (DatePicker1.SelectedDate.Value < new DateTime(1900, 1, 1))
                throw new PastBirthException("You can't set birthday before year 1900");
        }

        private void DateButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckData();
                var person = new Person(NameText.Text, SurnameText.Text, DatePicker1.SelectedDate.Value,
                    EmailText.Text);
                FillText(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
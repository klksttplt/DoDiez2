using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DatePicker1.SelectedDate = DateTime.Today.AddDays(-1);
            InfoText.Text = "Pick a date!";
        }

        private void DateButtonClicked(object sender, RoutedEventArgs e)
        {
            //Empty fields
            if (NameText.Text == "" && SurnameText.Text == "" && EmailText.Text == "")
            {
                MessageBox.Show("All fields must be filled!");
                return;
            }
            //String with info
            string text;
            //Creating a person
            var person = new Person(NameText.Text, SurnameText.Text, DatePicker1.SelectedDate.Value, EmailText.Text);
            //Invalid date of birth check
            if (person.birth > DateTime.Today || person.birth.Year < 1900)
            {
                MessageBox.Show("Invalid date");
                return;
            }
            //Ordinary text
            {
                text = person.name + " " + person.surname + " with email " + person.email + " was born " +
                       person.birth.ToString() +
                       (person.IsAdult ? ", is adult " : ", is not adult ") + "\n" + person.name + " " +
                       person.surname + " is " + person.SunSign + " and " + person.ChineseSign +
                       (person.IsBirthday ? "\nIt's their birthday!" : "\nIt's not their birthday :c");
            }
            InfoText.Text = text;
        }
    }
}
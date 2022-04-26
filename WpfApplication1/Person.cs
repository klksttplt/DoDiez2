using System;
using System.Net.Mail;
using System.Text.RegularExpressions;


namespace lab1wpf
{
    public class Person
    {
        public DateTime birth;
        private string westernSign;
        private string chineseSign;

        public readonly string SunSign;
        public readonly string ChineseSign;
        public readonly bool IsAdult;
        public readonly bool IsBirthday;

        public readonly string name;
        public readonly string surname;
        public readonly string email;


        private int age;

        public Person(string name, string surname, DateTime birth, string email)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.birth = birth;

            CalculateChineseSign();
            CalculateWesternSign();
            age = CalculateYears();

            if (birth.Day == DateTime.Today.Day && birth.Month == DateTime.Today.Month) IsBirthday = true;
            if (age >= 18) IsAdult = true;
            SunSign = westernSign;
            ChineseSign = chineseSign;
        }

        public Person(string name, string surname, string email)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
        }

        public Person(string name, string surname, DateTime birth)
        {
            this.name = name;
            this.surname = surname;
            AddBirth(birth);
            CalculateChineseSign();
            CalculateWesternSign();
            age = CalculateYears();
        }

        private void AddBirth(DateTime birth)
        {
            this.birth = birth;
        }

        private int CalculateYears()
        {
            if (birth.Year != DateTime.Today.Year && birth.Month <= DateTime.Today.Month
                                                  && birth.Day > DateTime.Today.Day)
                return DateTime.Today.Year - birth.Year - 1;
            else return DateTime.Today.Year - birth.Year;
        }


        private void CalculateWesternSign()
        {
            if (birth.Day >= 21 && birth.Month == 3 || birth.Day <= 19 && birth.Month == 4) westernSign = "Aries";
            if (birth.Day >= 20 && birth.Month == 4 || birth.Day <= 20 && birth.Month == 5) westernSign = "Taurus";
            if (birth.Day >= 21 && birth.Month == 5 || birth.Day <= 20 && birth.Month == 6) westernSign = "Gemini";
            if (birth.Day >= 21 && birth.Month == 6 || birth.Day <= 22 && birth.Month == 7) westernSign = "Cancer";
            if (birth.Day >= 23 && birth.Month == 7 || birth.Day <= 22 && birth.Month == 8) westernSign = "Leo";
            if (birth.Day >= 23 && birth.Month == 8 || birth.Day <= 22 && birth.Month == 9) westernSign = "Virgo";
            if (birth.Day >= 23 && birth.Month == 9 || birth.Day <= 22 && birth.Month == 10) westernSign = "Libra";
            if (birth.Day >= 23 && birth.Month == 10 || birth.Day <= 21 && birth.Month == 11) westernSign = "Scorpio";
            if (birth.Day >= 22 && birth.Month == 11 || birth.Day <= 21 && birth.Month == 12)
                westernSign = "Saggitarius";
            if (birth.Day >= 22 && birth.Month == 12 || birth.Day <= 19 && birth.Month == 1) westernSign = "Capricorn";
            if (birth.Day >= 20 && birth.Month == 1 || birth.Day <= 18 && birth.Month == 2) westernSign = "Aquaris";
            if (birth.Day >= 19 && birth.Month == 2 || birth.Day <= 20 && birth.Month == 3) westernSign = "Pisces";
        }


        private void CalculateChineseSign()
        {
            for (var i = 0; i < 15; i++)
            {
                if (birth.Year == 1900 + 12 * i) chineseSign = "Mouse";
                if (birth.Year == 1901 + 12 * i) chineseSign = "Bull";
                if (birth.Year == 1902 + 12 * i) chineseSign = "Tiger";
                if (birth.Year == 1903 + 12 * i) chineseSign = "Rabbit";
                if (birth.Year == 1904 + 12 * i) chineseSign = "Dragon";
                if (birth.Year == 1905 + 12 * i) chineseSign = "Shake";
                if (birth.Year == 1906 + 12 * i) chineseSign = "Horse";
                if (birth.Year == 1907 + 12 * i) chineseSign = "Sheep";
                if (birth.Year == 1908 + 12 * i) chineseSign = "Monkey";
                if (birth.Year == 1909 + 12 * i) chineseSign = "Rooster";
                if (birth.Year == 1910 + 12 * i) chineseSign = "Dog";
                if (birth.Year == 1911 + 12 * i) chineseSign = "Boar";
            }
        }
    }
}
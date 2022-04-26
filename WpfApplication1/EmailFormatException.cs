using System;
using System.Windows;

namespace lab1wpf
{
    public class EmailFormatException:Exception
    {
        public EmailFormatException(string message)
            : base(message)
        {
            MessageBox.Show(message);
        }
    }
}
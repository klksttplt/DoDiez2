using System;
using System.Windows;

namespace lab1wpf
{
    public class PastBirthException:Exception
    {
        public PastBirthException(string message)
            : base(message)
        {
            MessageBox.Show(message);
        }
    }
}
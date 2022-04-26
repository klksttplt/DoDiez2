using System;
using System.Windows;

namespace lab1wpf
{
    public class FutureBirthException:Exception
    {

        public FutureBirthException(string message)
            : base(message)
        {
            MessageBox.Show(message);
        }
    }
}
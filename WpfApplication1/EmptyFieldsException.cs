using System;
using System.Windows;

namespace lab1wpf
{
    public class EmptyFieldsException:Exception
    {
        public EmptyFieldsException(string message)
                : base(message)
            {
                MessageBox.Show(message);
            }
    }
}
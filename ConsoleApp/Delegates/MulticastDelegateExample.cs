using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class MulticastDelegateExample
    {
        delegate void ShowMessage(string message);

        public void Message1(string message)
        {
            Console.WriteLine($"1st message: {message}");
        }
        public void Message2(string message)
        {
            Debug.WriteLine($"2nd message: {message}");
        }
        public void Message3(string message)
        {
            Console.WriteLine($"3rd message: {message}");
        }

        public void Test()
        {
            ShowMessage showMessage = null;

            showMessage += Message1;
            showMessage += Message2;
            showMessage += Message3;
            showMessage += Console.WriteLine;

            showMessage("Hello");

            showMessage -= Message3;

            showMessage("Bye");

            showMessage = Message1;
            showMessage("Hi");
        }

    }
}

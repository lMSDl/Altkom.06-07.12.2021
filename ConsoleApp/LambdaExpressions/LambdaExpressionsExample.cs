using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.LambdaExpressions
{
    public class LambdaExpressionsExample
    {
        Func<int, int, int> Calculator { get; set; }
        Action<string> SomeAction { get; set; }
        Action AnotherAction { get; set; }

        void SomeMethod(Action<string> action, string parameter)
        {
            action(parameter);
        }

        public void Test()
        {
            //metoda anonimowa
            Calculator += //delegate (int a, int b) { return a + b; };
                          //<patametry> <operator> <ciało>
                          //(a, b) => { return a + b; };
                            (a, b) => a + b;

            SomeAction += //(param) => Console.WriteLine(param);
                            param => Console.WriteLine(param);

            AnotherAction += () => Console.WriteLine("Hello");

            SomeMethod(x => Console.WriteLine(x), "Bye");
            SomeMethod(x =>
            { 
                var value = x.Replace(',', '?');
                Console.WriteLine(value);
            },
            "a, b, c, d");
        }
    }
}

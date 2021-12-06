using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class BuildInDelegatesExample
    {
        public delegate void OddNumberDelegate();
        //public event OddNumberDelegate NumberEvent;

        public event Action NumberEvent;
        public event EventHandler NumberEventHandler;

        public void Add(int a, int b)
        {
            var result = a + b;
            Console.WriteLine(result);
            if (result % 2 != 0)
                NumberEvent();
        }

        public bool Substract(int a, int b)
        {
            var result = a - b;
            Console.WriteLine(result);
            return result % 2 != 0;
        }
        int counter;
        void CountNumbers()
        {
            counter++;
        }

        //delegate void Method1Delegate(int a, int b);
        //delegate bool Method2Delegate(int a, int b);
        //private void Method(Method1Delegate method, Method2Delegate method2)
        //Action - predefiniowane delegaty dla funkcji nie zwracających rezultatu
        //Func - predefiniowane delegaty dla funkcji zwracających rezultat
        private void Method(Action<int, int> method, Func<int, int, bool> method2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    method(i, ii);
                    if (method2(i, ii))
                        NumberEvent();
                }
            }
        }

        public void Test()
        {
            //Method1Delegate method1 = Add;
            //Method2Delegate method2 = Substract;
            Action<int, int> method1 = Add;
            Func<int, int, bool> method2 = Substract;

            NumberEvent += CountNumbers;

            Method(method1, method2);

            Console.WriteLine($"Counter: {counter}");


            Method(Add, Substract);

        }
    }
}

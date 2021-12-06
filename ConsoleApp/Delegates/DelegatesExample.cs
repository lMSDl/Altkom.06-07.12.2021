using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class DelegatesExample
    {
        public delegate void NoParametersNoReturnDelegate();
        public delegate void ParametersNoReturnDelegate(string @string);
        public delegate bool PrametersReturnDelegate(int x, int y);

        public void Func1()
        {
            Console.WriteLine("1");
        }
        public void Func2(string value)
        {
            Console.WriteLine(value);
        }
        public bool Func3(int a, int b)
        {
            Console.WriteLine($"{a} {b}");
            return a == b;
        }

        public PrametersReturnDelegate Delegate3 {get; set;}

        public void Test()
        {
            var delegate1 = new NoParametersNoReturnDelegate(Func1);

            Run(delegate1);
            Run(null);

            ParametersNoReturnDelegate delegate2 = Func2;
            delegate2("Test2");

            Delegate3 = Func3;

            for (int i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    if(Delegate3(i, ii))
                        Console.WriteLine("==");
                }
            }
        }

        public void Run(NoParametersNoReturnDelegate method)
        {
            if (method != null)
                method();
        }
    }
}

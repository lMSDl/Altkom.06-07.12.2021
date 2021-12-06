using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Delegates
{
    public class EventExample
    {
        public delegate void OddNumberDelegate();
       
        public event OddNumberDelegate NumberEvent;

        public OddNumberDelegate NumberDelegate;

        public void Add(int a, int b)
        {
            var result = a + b;
            Console.WriteLine(result);
            if (result % 2 != 0)
                NumberEvent();
        }

        int counter;
        void CountNumbers()
        {
            counter++;
        }

        public void Test()
        {
            NumberEvent += CountNumbers;

            for (int i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    Add(i, ii);
                }
            }

            Console.WriteLine($"Counter: {counter}");
        }

    }
}

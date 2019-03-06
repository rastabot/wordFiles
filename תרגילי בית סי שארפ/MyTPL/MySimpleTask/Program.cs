using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Threading
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace MySimpleTask
{
    class Program
    {
        public static void DoSomething(object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}", Thread.CurrentThread.ManagedThreadId);
            }
        }
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Task t1 = Task.Factory.StartNew(DoSomething, 10);
            // t1.Start();
            Task t2 = new Task(DoSomething, 20);
            t2.Start();

            t1.Wait(200);
            t2.Wait(100);

            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace MyIsBackground
{
    class Program
    {
        public static void PrintNumbers()
        {
            Console.WriteLine("{0} is executing PrintNumbers()", Thread.CurrentThread.Name);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("{0}", i);
                Thread.Sleep(500);
            }
        }

        static void Main(string[] args)
        {
            var myProgObj = new Program();
            Thread myThread = new Thread(new ThreadStart(PrintNumbers));

            // ThreadPool -> TPL task prallelism 
            myThread.IsBackground = true;

            myThread.Start();

        }
    }
}

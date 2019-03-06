using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace MyThreadStart
{
    class MyClass
    {
        // method that suits the ThreadStart delegate
        public static void PrintNumbers()
        {
            Console.WriteLine("{0} is executing PrintNumbers()", Thread.CurrentThread.Name);
            for (int i = 0; i < 10 ; i++)
            {
                Console.WriteLine("{0}", i);
                Thread.Sleep(500);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please choose how to run the method " + 
                " select [1] for 1 thread and [2] for 2 threads");
            string threadCount = Console.ReadLine();
            // Get the main thread
            Thread myPrimaryThread = Thread.CurrentThread;
            myPrimaryThread.Name = "Primary";
            Console.WriteLine("Main thread is running at:{0}", myPrimaryThread);
            switch (threadCount)
            {
                case "1":
                    MyClass.PrintNumbers();
                    break;
                case "2":
                    Thread myThreadObj = 
                        new Thread(new ThreadStart(MyClass.PrintNumbers));
                    myThreadObj.Name = "Second";
                    myThreadObj.Start();
                    break;
                default:
                    Console.WriteLine("please choose correct selection");
                    // goto case "1";
                    break;
            }
        }
    }
}

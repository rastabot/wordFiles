using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Diagnostics;

namespace MyThreadPool
{
    class Program
    {
        static void DoSomthing(object state)
        {
            int loops = (int)state * 200;
            for (int i = 0; i < loops; i++)
            {
                i++;
                Console.WriteLine("Thread id:{0}, State{1}", 
                    Thread.CurrentThread.ManagedThreadId, state);
            }
        }
        static void RunThreads()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("Runing threads...");
            Thread t1 = new Thread(DoSomthing); t1.Start(3);
            Thread t2 = new Thread(DoSomthing); t2.Start(6);
            Thread t3 = new Thread(DoSomthing); t3.Start(9);
            Thread t4 = new Thread(DoSomthing); t4.Start(12);
            Thread t5 = new Thread(DoSomthing); t5.Start(15);

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();

            sw.Stop();
            Console.WriteLine("It took {0} milliseconds to end the threads",
                sw.ElapsedMilliseconds);
        }
        static void RunThreadPool()
        {
            // There is NO easy way to measure ThreadPool time
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("run ThreadPool");
            ThreadPool.QueueUserWorkItem(DoSomthing, 3);
            ThreadPool.QueueUserWorkItem(DoSomthing, 6);
            ThreadPool.QueueUserWorkItem(DoSomthing, 9);
            ThreadPool.QueueUserWorkItem(DoSomthing, 12);
            sw.Stop();
            Console.WriteLine("It took {0} milliseconds to end the threads",
                sw.ElapsedMilliseconds);
        }
        static void Main(string[] args)
        {
            // RunThreads();
           RunThreadPool();

        }
    }
}

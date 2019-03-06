using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace MyLock
{
    public class MyClass
    {
        // using lock token
        private object lockToken = new object();
        public void PrintNum()
        {
            lock (lockToken)
            {            
                Console.WriteLine("{0}", Thread.CurrentThread.Name);
                Console.WriteLine("Numbers are:");
                for (int i = 0; i < 20; i++)
                {
                    Random myRndObj = new Random();
                    Thread.Sleep(10 * myRndObj.Next(100));
                    Console.WriteLine("i value is: {0}", i);
                }
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var myClassObj = new MyClass();
            Thread myTObj = new Thread(new ThreadStart(myClassObj.PrintNum));

            Thread[] tonsOfNumbers = new Thread[1000];
            for (int i = 0; i < 1000; i++)
            {
                tonsOfNumbers[i] = new Thread(new ThreadStart(myClassObj.PrintNum));
                tonsOfNumbers[i].Name = string.Format("Working thread is: {0}", i);
            }
            foreach (Thread t in tonsOfNumbers)
            {
                t.Start();
            }
            Console.ReadLine();
        }
    }
}

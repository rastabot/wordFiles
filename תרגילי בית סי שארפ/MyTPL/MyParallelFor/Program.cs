using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyParallelFor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using For");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("i = {0}, thread = {1}", i, 
                    Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(20);
            }

            Console.WriteLine("Using Parallel.For()");
            Parallel.For(0, 3, (x) => {
                Console.WriteLine("x = {0}, thread = {1}", x,
                   Thread.CurrentThread.ManagedThreadId);
            });
        }
    }
}

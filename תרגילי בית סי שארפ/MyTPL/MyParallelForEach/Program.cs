using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace MyParallelForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            var webRun = new List<string>
            {
                "https://www.google.com",
                "http://www.msn.com",
                "http://www.ynet.co.il"
            };
            Parallel.ForEach(webRun, x => {
                var client = new WebClient();
                string reply = client.DownloadString(x);
                Console.WriteLine("Thread:{0}, {1}, Reply:{2}",
                    Thread.CurrentThread.ManagedThreadId, x, reply.Length);
            });
        }
    }
}

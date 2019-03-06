using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace MyProcess
{
    class Program
    {
        static void ShowAllProcess()
        {
            Process[] allProcesses = Process.GetProcesses(Environment.MachineName);
            foreach (Process p in allProcesses)
            {
                Console.WriteLine("PID:{0}, Name:{1}", p.Id, p.ProcessName);
            }

        }

        static void ListAllthreads(int pid)
        {
            Process theProcess = null;
            try
            {
                theProcess = Process.GetProcessById(pid);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No PID", ex.Message);
            }
            ProcessThreadCollection threadCollection = theProcess.Threads;

            foreach (ProcessThread pt in threadCollection)
            {
                Console.WriteLine("Thread: {0} Start time:{1} Priority:{2}", 
                    pt.Id, pt.StartTime.ToShortDateString(), pt.PriorityLevel);
            }
        }
        static void Main(string[] args)
        {
            ShowAllProcess();
            ListAllthreads(3432);
        }
    }
}

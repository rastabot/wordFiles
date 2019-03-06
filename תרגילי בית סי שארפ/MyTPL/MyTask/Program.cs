using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyTask
{
    class MyClass
    {
        public long createDate;
        public string name;
        public int threadNum;

        // Action delegate signature 
        public void TaskDemo()
        {
            Task[] taskArr = new Task[100];
            for (int i = 0; i < taskArr.Length; i++)
            {
                taskArr[i] = new Task(() => {
                    var myClassObj = new MyClass();
                    myClassObj.threadNum = Thread.CurrentThread.ManagedThreadId;
                    Console.WriteLine("Task # {0} created at {1} and runing on {2}",
                        myClassObj.name, myClassObj.createDate, myClassObj.threadNum);
                });
                taskArr[i].Start();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myObj = new MyClass();
            myObj.TaskDemo();
        }
    }
}

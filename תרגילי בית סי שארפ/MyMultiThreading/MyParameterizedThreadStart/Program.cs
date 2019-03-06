using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyParameterizedThreadStart
{
    public class AddParams
    {
        public int a, b;
        public AddParams(int _a, int _b)
        {
            this.a = _a;
            this.b = _b;
        }
    }
    class Program
    {
        public static void Add(object data)
        {
            if (data is AddParams)
            {
                Console.WriteLine("{0}", Thread.CurrentThread.Name);
                // is - we have to explicitly casting
                AddParams ap = (AddParams)data;
                Console.WriteLine("{0}+{1}={2}", ap.a, ap.b, ap.a + ap.b);
            }
        }
        static void Main(string[] args)
        {
            AddParams myObj = new AddParams(20, 10);
            Thread myParamObj = new Thread(new ParameterizedThreadStart(Add));
            myParamObj.Start(myObj);
            Console.ReadLine();
        }
    }
}

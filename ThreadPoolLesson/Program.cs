using System;
using System.IO;
using System.Text;
using System.Threading;

namespace ThreadPoolLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Max Thread Number

            //int workerThreads = 0;
            //int otherThreads = 0; // vvod i vivod
            //ThreadPool.GetMaxThreads(out workerThreads, out otherThreads);

            //Console.WriteLine("Worker: " + workerThreads.ToString());
            //Console.WriteLine("Other: " + otherThreads.ToString());
            //Console.WriteLine();

            #endregion


            #region Min Thread Number

            //int minWorkerThread = 0;
            //int minOtherThread = 0;
            //ThreadPool.GetMinThreads(out minWorkerThread, out minOtherThread);

            //Console.WriteLine("Worker: " + minWorkerThread.ToString());
            //Console.WriteLine("Other: " + minOtherThread.ToString());
            //Console.WriteLine();

            #endregion


            #region Available Threads Number

            //int availableWorkerThread = 0;
            //int availableOtherThreads = 0;

            //ThreadPool.GetAvailableThreads(out availableWorkerThread, out availableOtherThreads);

            //Console.WriteLine("Av Worker: " + availableWorkerThread);
            //Console.WriteLine("Av Other: " + availableOtherThreads);
            //Console.WriteLine();

            #endregion


            #region UseThreadPool

            //Console.WriteLine("Main Thread");

            //Random random = new Random();

            //for (int i = 0; i < 10; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(CallBackFunc, random.Next(10));
            //}

            //Console.WriteLine("Main thread is working!");
            //Thread.Sleep(1000);

            #endregion


            #region Async
            int count = 0;
            byte[] bytes;

            using (FileStream fs = new FileStream("../../../Program.cs", FileMode.Open))
            {

                bytes = new byte[fs.Length];

                IAsyncResult result = fs.BeginRead(bytes, 0, bytes.Length, WaitSomeTime, null);

                if (!result.IsCompleted)
                {
                    Console.WriteLine("Waiting!");
                }

                count = fs.EndRead(result);
            }

            Console.WriteLine(Encoding.UTF8.GetString(bytes));
            Console.WriteLine(count);
            Console.ReadKey();


            #endregion


            #region Timer

            Timer timer = new Timer(DoSomething, null, 1000, 1000);

            timer.Change(0, 1000);

            Console.WriteLine(Timer.ActiveCount);

            timer.Dispose();

            #endregion

            Console.ReadKey();

        }

        private static void DoSomething(object data)
        {
            Console.WriteLine("Hello");
        }

        private static void WaitSomeTime(object obj)
        {
            Thread.Sleep(5000);
        }

        private static void CallBackFunc(object obj)
        {
            Console.WriteLine($"Thread #{Thread.CurrentThread.ManagedThreadId} : {(int)obj}");
            Thread.Sleep(1000);
        }


    }
}




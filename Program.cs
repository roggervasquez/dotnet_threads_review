using System;
using System.Threading;

namespace Core_BasicTheading
{

    class MyThread
    {
        public static void Run() {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Child : Invoking thread : {i} ");
                // Simulate work time for the thread
                Thread.Sleep(500);
                Console.WriteLine ($"Child : Terminating thread  {i} ");

            }
        
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Thread World!");
            Console.WriteLine("Start a child thread");

            Thread thread = new Thread(new ThreadStart(MyThread.Run));

            thread.Start();
            // Print some info of the child thread
            Console.WriteLine($"Priority :{thread.Priority} , IsBackGround : {thread.IsBackground} ," +
                              $"State :{thread.ThreadState}  " );


            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Main Thread : index {i} ");
                Thread.Sleep(500);

            }
            Console.WriteLine("Main Thread : Wait to child thread terminates, calling join");
            thread.Join();
            Console.WriteLine("Main thread : finished wating child one");
                        
            
        }
    }
}
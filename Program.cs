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
                Console.WriteLine($"Child : Terminating thread  {i} ");

            }

        }
    }

    class ThreadTimer
    {
        public Thread thread;
        Timer timer;
        public ThreadTimer(string name, Timer t)
        {
            thread = new Thread(new ThreadStart(this.run));
            thread.Name = name;
            timer = t;
            thread.Start();

        }

        private void run()
        {
            if (thread.Name == "Tick")
            {
                for (int i = 1; i < 5; i++)
                {
                    Console.WriteLine("----Tick :" + i);
                    timer.Tick(true);
                    
                }
                timer.Tick(false);
            }
            else
            {
                for (int i = 1; i < 5; i++)
                {
                    Console.WriteLine("++++Tock :" + i);
                    timer.Tock(true);
                }
                timer.Tock(false);

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


            // Test the timer Threads
            // Shared timer
            Timer timer = new Timer();
            ThreadTimer threadTimerTick = new ThreadTimer("Tick", timer);
            ThreadTimer threadTimerTock = new ThreadTimer("Tock", timer);

            threadTimerTick.thread.Join();
            threadTimerTock.thread.Join();

            Console.WriteLine("Timer Stopped");
                        
            
        }
    }
}
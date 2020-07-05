using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;

namespace Core_BasicTheading
{
    public class Timer
    {
        object lockOn = new object(); // This is the share variable is like a Sempahore

        public void Tick(bool isRunning)
        {
            lock(lockOn)
            {
                if(!isRunning)
                {
                    Monitor.Pulse(lockOn); // Notify any waithing threads to enter critical section
                    return;
                }
                Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} : Tick");
                Thread.Sleep(500);
                Monitor.Pulse(lockOn); // Let other thread run
                // And wait for other thread to complete
                Monitor.Wait(lockOn); 

            }
        }

        public void Tock (bool isRunning)
        {
            lock(lockOn)
            {
                if (!isRunning)
                {
                    Monitor.Pulse(lockOn); // Notify any waithing threads to enter critical section
                    return;
                }
                Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff} : *** Tock");
                Thread.Sleep(500);
                Monitor.Pulse(lockOn); // Let other thread run
                                       // And wait for other thread to complete
                Monitor.Wait(lockOn);
            }
            
        }
    }
}

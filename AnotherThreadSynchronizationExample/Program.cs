using System;
using System.Threading;

//ref link:https://www.youtube.com/watch?v=LybN08MQo2o&list=PLRwVmtr-pp06KcX24ycbC-KkmAISAFKV5&index=8
//

class MainClass
{
    static object baton = new object();
    static Random rand = new Random();
    static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            new Thread(UseRestroomStall).Start();
        }
    }
    static void UseRestroomStall()
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId +
            "Trying to obtain the bathroom stall...");
        lock(baton)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + 
                " obtained the lock. Doing my business...");
            Thread.Sleep(rand.Next(2000));
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + 
                " leaving the stall...");
        }
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + 
            " is leaving the restaurant.");
    }
}
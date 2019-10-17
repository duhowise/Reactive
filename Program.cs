using System.Collections.ObjectModel;
using System;
using System.Reactive.Linq;

namespace Reactive
{
    class Program
    {
        static void Main(string[] args)
        {
            StartBackgroundWork();
            System.Console.ReadLine();
        }

     public static void StartBackgroundWork(){

         System.Console.WriteLine("Shows use of Start to start on a background thread:");
         var o=Observable.Start(() =>
         {
             //This starts on a background thread.
             Console.WriteLine("From background thread. Does not block main thread.");
             Console.WriteLine("Calculating...");
             System.Threading.Thread.Sleep(3000);
             Console.WriteLine("Background work completed.");

         }).Finally(() => Console.WriteLine("Main thread completed."));
            Console.WriteLine("\r\n\t In Main Thread...\r\n");
            o.Wait();   // Wait for completion of background operation.

        }   
    }
}

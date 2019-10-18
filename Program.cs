using System.Threading;
using System.Collections.ObjectModel;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Reactive
{
    class Program
    {
        static void Main(string[] args)
        {
            StartBackgroundWork();
            System.Console.ReadLine();
        }

        public static async Task StartBackgroundWork()
        {

            #region Introduction

            //Console.WriteLine("Shows use of Start to start on a background thread:");
            //var o = Observable.Start(() =>
            //{
            //    //This starts on a background thread.
            //    Console.WriteLine("From background thread. Does not block main thread.");
            //    Console.WriteLine("Calculating...");
            //    Thread.Sleep(3000);
            //    Console.WriteLine("Background work completed.");

            //}).Finally(() => Console.WriteLine("Main thread completed."));
            //Console.WriteLine("\r\n\t In Main Thread...\r\n");
            //o.Wait();   // Wait for completion of background operation.

            #endregion

           var data= await LongRunningOperationAsync("");
           Console.WriteLine(data);
        }

        public static int DoLongRunningTask(string param)
        {
            Thread.Sleep(3000);
            return 1;
        }

        public static IObservable<int> LongRunningOperationAsync(string param)
        {
            return Observable.Create<int>(o =>
                    Observable.ToAsync<string, int>(DoLongRunningTask)(param).Subscribe(o)
                );
        }

    }
}


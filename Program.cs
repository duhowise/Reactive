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
            //StartBackgroundWork();
            //var data = await LongRunningOperationAsync("");
            ParallelExecutionTest();
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
        public static async void ParallelExecutionTest()
        {
            var o = Observable.CombineLatest(
                Observable.Start(() => { Console.WriteLine("Executing 1st on Thread: {0}", Thread.CurrentThread.ManagedThreadId); return "Result A"; }),
                Observable.Start(() => { Console.WriteLine("Executing 2nd on Thread: {0}", Thread.CurrentThread.ManagedThreadId); return "Result B"; }),
                Observable.Start(() => { Console.WriteLine("Executing 3rd on Thread: {0}", Thread.CurrentThread.ManagedThreadId); return "Result C"; })
            ).Finally(() => Console.WriteLine("Done!"));

            foreach (string r in await o.FirstAsync())
                Console.WriteLine(r);
        }
    }
}


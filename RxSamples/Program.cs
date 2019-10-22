using System;
using System.Reactive.Subjects;

namespace RxSamples
{

    class Program
    {
        //public Program()
        //{
        //    var market = new Subject<float>();
        //    market.Subscribe(
        //        f=> Console.WriteLine($"price is {f}"),
        //        ()=>Console.WriteLine("sequence is complete"));
        //    market.OnNext(1.23f);
        //    market.OnCompleted();
        //}
        static void Main(string[] args)
        {
            var market=new Subject<float>();
            var marketConsumer=new Subject<float>();
            market.Subscribe(marketConsumer);
            marketConsumer.Inspect("market consumer");
            market.OnNext(1,2,3,4,5);
            market.OnCompleted();
            
        }

       
    }
}

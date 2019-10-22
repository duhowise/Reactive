using System;
using System.Reactive.Subjects;

namespace Reactive.RxSamples
{

    class Program
    {
        public Program()
        {
            var market = new Subject<float>();
            market.Subscribe(
                f=> Console.WriteLine($"price is {f}"),
                ()=>Console.WriteLine("sequence is complete"));
            market.OnNext(1.23f);
            market.OnCompleted();
        }
        static void Main(string[] args)
        {
            new Program();
        }

       
    }
}

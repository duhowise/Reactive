using System;
using System.Reactive;

namespace RxSamples
{
    public static class ExtensionMethods
    {
        public static IDisposable Inspect<T>(this IObservable<T> self, string name)
        {
           return self.Subscribe(
                x => Console.WriteLine(""),
                ex=> Console.WriteLine($"{name} ha generated an exception {ex.Message}"),
                ()=> Console.WriteLine($"{name} has completed"));
           
        }

        public static IObserver<T> OnNext<T>(this IObserver<T> self, params T[] args)
        {
            foreach (var arg in args)
           
                self.OnNext(arg);
            return self;
            
        }

    }
}
using TKActorGlobalSum.Interfaces;
using Microsoft.ServiceFabric.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKActorAdd.Interfaces;
using System.Threading;
using TKActorSub.Interfaces;

namespace TK_ServiceFabricCalculatorV2.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread.Sleep(15000);
            var proxy = ActorProxy.Create<ITKActorGlobalSum>(ActorId.NewId(), "fabric:/TK_ServiceFabricCalculatorV2");

            ActorId idgs = proxy.GetActorId();
            proxy.IncrementAdd().Wait();

            Console.WriteLine($"{idgs}: {proxy.GetCountAdd().Result}");

            var proxy1 = ActorProxy.Create<ITKActorAdd>(ActorId.NewId(), "fabric:/TK_ServiceFabricCalculatorV2");
            var result1 = proxy1.DoWorkAsync().Result;
            Console.WriteLine(result1);

            var proxy2 = ActorProxy.Create<ITKActorSub>(ActorId.NewId(), "fabric:/TK_ServiceFabricCalculatorV2");
            var result2 = proxy2.Sub(idgs,5, 2).Result;

            var proxy3 = ActorProxy.Create<ITKActorAdd>(ActorId.NewId(), "fabric:/TK_ServiceFabricCalculatorV2");
            var result3 = proxy3.Add3(idgs, 5, 2, 1).Result;


            Console.WriteLine($"{idgs}: Add: {proxy.GetCountAdd().Result}");
            Console.WriteLine($"{idgs}: Sub: {proxy.GetCountSub().Result}");

            Console.WriteLine("END");
            Console.ReadLine();
            //Task.Run(async () =>
            //{
            //    try
            //    {
            //        var proxy = ActorProxy.Create<ITKActorGlobalSum>(ActorId.NewId(), "fabric:/TK_ServiceFabricCalculatorV2");

            //        int count = 10;
            //        Console.WriteLine("Setting Count to in Actor {0}: {1}", proxy.GetActorId(), count);
            //        proxy.SetCountAsync(count).Wait();

            //        Console.WriteLine("Count from Actor {0}: {1}", proxy.GetActorId(), proxy.GetCountAsync().Result);

            //        var proxy1 = ActorProxy.Create<ITKActorAdd>(ActorId.NewId(), "fabric:/TK_ServiceFabricCalculatorV2");
            //        var result1 = await proxy1.DoWorkAsync();
            //        Console.WriteLine(result1);
            //        Console.WriteLine("END");
            //        Console.ReadLine();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }
            //});


        }
    }
}

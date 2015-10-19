using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TK_OrleansDemoController
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(10000);
            GrainClient.Initialize("ClientConfiguration.xml");
            var friend = GrainClient.GrainFactory.GetGrain<TKOrleansInterfaces.IMyGrain1>(0);
            Console.WriteLine("\n\n{0}\n\n", friend.SayHello().Result);

            //Test with more complicated grains
            var e0 = GrainClient.GrainFactory.GetGrain<TKOrleansInterfaces.IEmployee>(Guid.NewGuid());
            var e1 = GrainClient.GrainFactory.GetGrain<TKOrleansInterfaces.IEmployee>(Guid.NewGuid());
            var e2 = GrainClient.GrainFactory.GetGrain<TKOrleansInterfaces.IEmployee>(Guid.NewGuid());
            var e3 = GrainClient.GrainFactory.GetGrain<TKOrleansInterfaces.IEmployee>(Guid.NewGuid());
            var e4 = GrainClient.GrainFactory.GetGrain<TKOrleansInterfaces.IEmployee>(Guid.NewGuid());

            var m0 = GrainClient.GrainFactory.GetGrain<TKOrleansInterfaces.IManager>(Guid.NewGuid());
            var m1 = GrainClient.GrainFactory.GetGrain<TKOrleansInterfaces.IManager>(Guid.NewGuid());
            var m0e = m0.AsEmployee().Result;
            var m1e = m1.AsEmployee().Result;

            m0e.Promote(10);
            m1e.Promote(11);

            m0.AddDirectReport(e0).Wait();
            m0.AddDirectReport(e1).Wait();
            m0.AddDirectReport(e2).Wait();

            m1.AddDirectReport(m0e).Wait();
            m1.AddDirectReport(e3).Wait();

            var m0et = m0e.GetLevel();
            m0et.Wait();

            Console.WriteLine("m0e (10) =  " + m0et.Result);

            m1.Order("DO1 (m1)").Wait();
            m0.Order("DO2 (m0)").Wait();

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TKActorSub.Interfaces;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;
using TKActorGlobalSum.Interfaces;

namespace TKActorSub
{
    public class TKActorSub : Actor, ITKActorSub
    {
        public async Task<string> DoWorkAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "Doing Work");

            return await Task.FromResult("Work result");
        }

        public async Task<int> Sub(ActorId idgs, int a, int b)
        {
            ActorEventSource.Current.ActorMessage(this, $"Sub {a} - {b}");
            var proxy = ActorProxy.Create<ITKActorGlobalSum>(idgs, "fabric:/TK_ServiceFabricCalculatorV2");
            await proxy.IncrementSub();
            return a - b;
        }
    }
}

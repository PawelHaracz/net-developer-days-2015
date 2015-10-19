using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TKActorAdd.Interfaces;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;
using TKActorGlobalSum.Interfaces;

namespace TKActorAdd
{
    public class TKActorAdd : Actor, ITKActorAdd
    {
        public override Task OnActivateAsync()
        {
            ActorEventSource.Current.ActorMessage(this, $"OnActivateAsync - {this.Id}");
            return base.OnActivateAsync();
        }
        public async Task<int> Add(ActorId idgs, int a, int b)
        {
            ActorEventSource.Current.ActorMessage(this, $"Sub {a} - {b}");
            var proxy = ActorProxy.Create<ITKActorGlobalSum>(idgs, "fabric:/TK_ServiceFabricCalculatorV2");
            await proxy.IncrementAdd();
            return a - b;
        }

        public async Task<int> Add3(ActorId idgs, int a, int b, int c)
        {
            ActorEventSource.Current.ActorMessage(this, $"Add {a} + {b} + {c}");
            var proxy = ActorProxy.Create<ITKActorAdd>(ActorId.NewId(), "fabric:/TK_ServiceFabricCalculatorV2");
            var r1 = await proxy.Add(idgs, a,b);
            proxy = ActorProxy.Create<ITKActorAdd>(ActorId.NewId(), "fabric:/TK_ServiceFabricCalculatorV2"); // New entity
            var r2 = await proxy.Add(idgs, r1, c);
            return r2;
        }

        public async Task<string> DoWorkAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "Doing Work");

            return await Task.FromResult("Work result");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TKActorGlobalSum.Interfaces;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;

namespace TKActorGlobalSum
{
    public class TKActorGlobalSum : Actor<TKActorGlobalSumState>, ITKActorGlobalSum
    {
        public override Task OnActivateAsync()
        {
            if (this.State == null)
            {
                this.State = new TKActorGlobalSumState() { CountAdd = 0, CountSub = 0 };
            }

            ActorEventSource.Current.ActorMessage(this, "State initialized to {0}", this.State);
            return Task.FromResult(true);
        }

        public Task<int> GetCountSub()
        {
            ActorEventSource.Current.ActorMessage(this, $"GetCountSub: {State.CountAdd}");
            return Task.FromResult(this.State.CountSub);
        }

        public Task<int> GetCountAdd()
        {
            ActorEventSource.Current.ActorMessage(this, $"GetCountAdd: {State.CountAdd}");
            return Task.FromResult(this.State.CountAdd);
        }

        public Task IncrementAdd()
        {
            ActorEventSource.Current.ActorMessage(this, $"IncrementAdd");
            this.State.CountAdd++;
            return Task.FromResult(true);
        }

        public Task IncrementSub()
        {
            ActorEventSource.Current.ActorMessage(this, $"IncrementSub");
            this.State.CountSub++;
            return Task.FromResult(true);
        }
    }
}

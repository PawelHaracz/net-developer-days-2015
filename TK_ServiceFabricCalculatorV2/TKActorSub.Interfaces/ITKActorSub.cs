using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace TKActorSub.Interfaces
{
    public interface ITKActorSub : IActor
    {
        Task<string> DoWorkAsync();
        Task<int> Sub(ActorId idgs, int a, int b);
    }
}

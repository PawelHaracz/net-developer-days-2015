using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace TKActorGlobalSum.Interfaces
{
    public interface ITKActorGlobalSum : IActor
    {
        Task<int> GetCountAdd();
        Task IncrementAdd();
        Task<int> GetCountSub();
        Task IncrementSub();
    }
}

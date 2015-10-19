using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace TKActorAdd.Interfaces
{
    public interface ITKActorAdd : IActor
    {
        Task<string> DoWorkAsync();
        Task<int> Add(ActorId idgs, int a, int b);
        Task<int> Add3(ActorId idgs, int a, int b, int c);
    }
}

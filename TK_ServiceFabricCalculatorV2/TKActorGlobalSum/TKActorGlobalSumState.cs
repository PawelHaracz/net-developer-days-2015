using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using TKActorGlobalSum.Interfaces;
using Microsoft.ServiceFabric;
using Microsoft.ServiceFabric.Actors;

namespace TKActorGlobalSum
{
    [DataContract]
    public class TKActorGlobalSumState
    {
        [DataMember]
        public int CountAdd;
        [DataMember]
        public int CountSub;

        public override string ToString()
        {
            return $"TKActorGlobalSumState: {CountAdd}, {CountSub}";
        }
    }
}
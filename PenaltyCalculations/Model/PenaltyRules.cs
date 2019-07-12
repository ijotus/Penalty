using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations.Model
{
    [DataContract]
    [KnownType(typeof(PenaltyData))]
    public class PenaltyRules : IPenaltyRules
    {
        [field: DataMember(Name = "Rules")]
        public IPenaltyData[] Data { get; }

        public PenaltyRules(IPenaltyData[] data)
        {
            Data = data;
        }

    }
}

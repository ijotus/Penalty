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

        [field: DataMember(Name = "PaymentPeriod")]
        public int PaymentPeriod { get; }

        public PenaltyRules(IPenaltyData[] data,int paymentPeriod)
        {
            Data = data;
            PaymentPeriod = paymentPeriod;
        }

    }
}

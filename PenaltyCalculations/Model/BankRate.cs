using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations.Model
{
    [DataContract]
    [KnownType(typeof(DateAndValue))]
    public class BankRate : IBankRate
    {
        [field: DataMember(Name= "Rate")]
        public IDateAndValue[] Rate { get; }


        public BankRate(IDateAndValue[] rate)
        {
            Rate = rate;
        }
    }
}

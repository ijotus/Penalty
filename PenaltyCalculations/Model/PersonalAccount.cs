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
    public class PersonalAccount : IPersonalAccount
    {
        [field: DataMember(Name= "Accrual")]
        public IDateAndValue[] Accrual { get; }

        [field: DataMember(Name = "Payments")]
        public IDateAndValue[] Payments { get; }

        public PersonalAccount(IDateAndValue[] accrual, IDateAndValue[] payments)
        {
            Accrual = accrual;
            Payments = payments;
        }
    }
}

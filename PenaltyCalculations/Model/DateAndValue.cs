using System;
using System.Runtime.Serialization;

namespace PenaltyCalculations.Model
{
    [DataContract]
    [KnownType(typeof(IDateAndValue))]
    public class DateAndValue : IDateAndValue
    {
        [field: DataMember(Name = "Date")]
        public DateTime Date { get; }

        [field: DataMember(Name= "Value")]
        public Decimal Value { get; }

        public DateAndValue(DateTime date, Decimal value)
        {
            Date = date;
            Value = value;
        }
    }
}
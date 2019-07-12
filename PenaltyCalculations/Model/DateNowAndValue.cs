using System;
using System.Runtime.Serialization;

namespace PenaltyCalculations.Model
{
    public class DateNowAndValue : IDateAndValue
    {
        public DateTime Date =>DateTime.Now;

        public Decimal Value { get; }

        public DateNowAndValue(Decimal value)
        {
            Value = value;
        }
    }
}
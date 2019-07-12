using System;

namespace PenaltyCalculations.Model
{
    public interface IDateAndValue 
    {
        DateTime Date { get; }
        Decimal Value { get; }
    }
}
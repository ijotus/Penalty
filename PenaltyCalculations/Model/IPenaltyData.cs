using System;

namespace PenaltyCalculations
{
    public interface IPenaltyData
    {
        int PeriodFrom { get; }
        Decimal Coefficient { get; }
        string CoefficientView { get; }
    }
}
using System;

namespace PenaltyCalculations.Model.Reports
{
    public interface IReportPenalty : IReport
    {
        Decimal Debt { get; }
        Decimal Penalty { get; }
        decimal Days { get; }
        DateTime DateFrom { get; }
        DateTime DateTo { get; }
        Decimal Rate { get; }
        Decimal Coefficient { get; }
    }
}

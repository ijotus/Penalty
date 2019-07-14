using System;

namespace PenaltyCalculations.Model.Reports
{
    public interface IReportDebtPayment : IReport
    {
        Decimal DebtPayment { get; }

        DateTime DateFrom { get; }
    }
}

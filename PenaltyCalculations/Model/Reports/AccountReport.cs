using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenaltyCalculations;

namespace PenaltyCalculations
{
    public class AccountReport : IAccountReport
    {
        public IReportPenalty ReportPenalty { get; }
        public IReportDebtPayment ReportDebtPayment { get; }

        public AccountReport(IReportPenalty reportPenalty, IReportDebtPayment reportDebtPayment)
        {
            ReportPenalty = reportPenalty;
            ReportDebtPayment = reportDebtPayment;
        }

        void IAccountReport.DebugView()
        {
            ReportPenalty?.DebugView();
            ReportDebtPayment?.DebugView();
        }
    }
}

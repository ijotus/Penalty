using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PenaltyCalculations
{
    interface IAccountReport
    {
        IReportPenalty ReportPenalty { get; }
        IReportDebtPayment ReportDebtPayment { get; }
        void DebugView();
    }
}

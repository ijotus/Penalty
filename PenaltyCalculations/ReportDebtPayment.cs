using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations
{
    class ReportDebtPayment : IReportDebtPayment
    {
        public decimal DebtPayment { get; }
        public DateTime DateFrom { get; }

        public ReportDebtPayment(decimal debtPayment,DateTime dateFrom)
        {
            DebtPayment = debtPayment;
            DateFrom = dateFrom;
        }

        public void DebugView()
        {
           
        }
    }
}

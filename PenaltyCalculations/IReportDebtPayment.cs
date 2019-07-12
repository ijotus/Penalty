using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations
{
    public interface IReportDebtPayment
    {
        Decimal DebtPayment { get; }
     
        DateTime DateFrom { get; }
        
        void DebugView();
    }
}

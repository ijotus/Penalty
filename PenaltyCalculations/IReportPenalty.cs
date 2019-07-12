using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations
{
    public interface IReportPenalty
    {
        Decimal Debt { get; }
        Decimal Penalty { get; }
        decimal Days { get; }
        DateTime DateFrom { get; }
        DateTime DateTo { get; }
        Decimal Rate { get; }
        Decimal Coefficient { get; }
        void DebugView();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations
{
    class ReportPenalty : IReportPenalty
    {
        public decimal Debt { get; }
        public decimal Penalty { get; }
        public decimal Days { get; }
        public DateTime DateFrom { get; }
        public DateTime DateTo { get; }
        public decimal Rate { get; }
        public decimal Coefficient { get; }

        public ReportPenalty(decimal debt,decimal penalty, DateTime dateFrom, DateTime dateTo,decimal rate, decimal coefficient,decimal days)
        {
            Debt = debt;
            Penalty = penalty;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Rate = rate;
            Coefficient = coefficient;
            Days = days;
        }

        public void DebugView()
        {
            Console.WriteLine($"debt {Debt} from {DateFrom:dd-MM-yyyy} to {DateTo:dd-MM-yyyy} days {Days} rate {Rate} coeff {Coefficient} = penalty {Penalty}");
        }
    }
}

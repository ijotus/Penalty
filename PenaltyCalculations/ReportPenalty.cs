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
        public string CoefficientView { get; }

        public ReportPenalty(decimal debt,decimal penalty, DateTime dateFrom, DateTime dateTo,decimal rate, decimal coefficient,decimal days,string coefficientView)
        {
            Debt = debt;
            Penalty = penalty;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Rate = rate;
            Coefficient = coefficient;
            Days = days;
            CoefficientView = coefficientView;
        }

        public void DebugView()
        {
            Console.WriteLine($"задолженность: {Debt} с: {DateFrom:dd-MM-yyyy} по: {DateTo:dd-MM-yyyy} кол-во дней: {Days} ставка: {Rate} доля ставки: {CoefficientView} пени: {Math.Round(Penalty,2)}");
        }
    }
}

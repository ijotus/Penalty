using System;

namespace PenaltyCalculations.Model.Reports
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{-DebtPayment} {DateFrom:dd-MM-yyyy} Погашение части долга");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

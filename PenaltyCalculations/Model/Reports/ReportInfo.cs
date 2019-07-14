using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations.Model.Reports
{
    public class ReportInfo : IReport
    {
        private DateTime _dateFrom;
        private DateTime _dateTo;
        private int _countDays;
        private decimal _balance;

        public ReportInfo(DateTime dateFrom, DateTime dateTo, int countDays, decimal balance)
        {
            _dateFrom = dateFrom;
            _dateTo = dateTo;
            _countDays = countDays;
            _balance = balance;
        }

        public void DebugView()
        {
            Console.WriteLine($"дата: c {_dateFrom:dd-MM-yyyy} по {_dateTo:dd-MM-yyyy} кол-во дней :{_countDays}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"на счету абонента: {_balance}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

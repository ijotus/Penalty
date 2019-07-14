using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations.Model
{
    public  class PaymentPeriodCalculationRule : IPaymentPeriodCalculationRule
    {
        private readonly int _days;
        public PaymentPeriodCalculationRule(int days)
        {
            _days = days;
        }
        public DateTime CalculatePeriod(DateTime date)
        {
            var begin = new DateTime(date.Year,date.Month, _days + 1, 0,0,0).AddMonths(1);
            return begin;
        }
    }
}

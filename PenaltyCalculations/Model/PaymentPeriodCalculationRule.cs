using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations.Model
{
    public  class PaymentPeriodCalculationRule : IPaymentPeriodCalculationRule
    {
        //TODO по 10 включительно нужно оплатить
        //TODO вынести в db
        private const int Days = 11;
        public DateTime CalculatePeriod(DateTime date)
        {
            var begin = new DateTime(date.Year,date.Month, Days, 0,0,0).AddMonths(1);
            return begin;
        }
    }
}

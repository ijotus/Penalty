using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenaltyCalculations.Model;
using PenaltyCalculations.Model.Reports;

namespace PenaltyCalculations
{
    class PenaltyCalculations : IPenaltyCalculations
    {
        private readonly IAccountProvider _accountProvider;
        private readonly IBankRateProvider _bankRateProvider;
        private readonly IPenaltyRulesProvider _penaltyRulesProvider;
        private decimal _balance;

        public PenaltyCalculations
        (
            IAccountProvider      accountProvider,
            IBankRateProvider     bankRateProvider,
            IPenaltyRulesProvider penaltyRulesProvider
        )
        {
            _accountProvider      = accountProvider;
            _bankRateProvider     = bankRateProvider;
            _penaltyRulesProvider = penaltyRulesProvider;
        }

        public IReport[] Calculate(DateTime date)
        {
            _balance = 0;
            var period = new PaymentPeriodCalculationRule(_penaltyRulesProvider.PenaltyRules.PaymentPeriod);
            var reports = new List<IReport>();

            var allPayments = _accountProvider.AccountData.Payments.ToList().ToDictionary(elt => elt.Date, elt => elt);

            foreach (var accrual in _accountProvider.AccountData.Accrual)
            {
                var dateFromTotal = period.CalculatePeriod(accrual.Date);
                var dateFromTemp = dateFromTotal;
                var daysCountTotal = (int) (date - dateFromTotal).TotalDays;
                reports.Add(new ReportInfo(dateFromTotal, date, daysCountTotal, _balance));

                var penaltyDatas = _penaltyRulesProvider.PenaltyRules.Data
                    .Where(rule => daysCountTotal > rule.PeriodFrom).ToArray();


                var accrualValue = accrual.Value;
                for (int i = 0; i < penaltyDatas.Length; ++i)
                {
                    var bankRate = _bankRateProvider.BankRate.Rate.LastOrDefault(elt => elt.Date <= dateFromTotal)
                                       ?.Value ?? 100;

                    var penaltyData = penaltyDatas[i];
                    var dateTo = DateTime.Now;
                    int daysCountPeriod = daysCountTotal;
                    if (i + 1 < penaltyDatas.Length)
                    {
                        daysCountTotal -= penaltyDatas[i + 1].PeriodFrom;
                        daysCountPeriod = penaltyDatas[i + 1].PeriodFrom;
                        dateTo = dateFromTemp + new TimeSpan(daysCountPeriod - 1, 0, 0, 0);
                    }
                    else
                    {
                        daysCountPeriod = daysCountTotal;
                    }

                    daysCountPeriod = Math.Max(0, daysCountPeriod);
                    if (daysCountPeriod == 0)
                        continue;

                    var expr = allPayments.Where(elt =>
                            elt.Value.Date >= dateFromTemp && elt.Value.Date <= dateTo && elt.Value.Value > 0)
                        .Select(elt => elt.Value);

                    var payments = new Queue<IDateAndValue>(expr);


                    if (payments.Count > 0)
                    {

                        while (payments.Count > 0)
                        {
                            var payment = payments.Dequeue();

                            daysCountPeriod = (int) (payment.Date - dateFromTemp).TotalDays + 1;
                            dateTo = payment.Date;
                            //
                            if (accrualValue <= 0)
                                break;

                            var penalty1 = CalculatePenalty(accrualValue, daysCountPeriod, penaltyData, bankRate);
                            var report2 = new ReportPenalty(accrualValue, penalty1, dateFromTemp, dateTo, bankRate,
                                penaltyData.Coefficient, daysCountPeriod, penaltyData.CoefficientView);
                          
                            reports.Add(report2);
                     

                            allPayments.Remove(payment.Date);
                            accrualValue = accrualValue - payment.Value - _balance;
                            var report1 = new ReportDebtPayment(payment.Value, payment.Date);
                           
                            reports.Add(report1);
                            //
                            dateFromTemp = dateTo + new TimeSpan(1, 0, 0, 0);



                            if (accrualValue <= 0)
                            {
                                //переплата либо оплачен
                                _balance = -accrualValue;
                                break;
                            }
                        }

                    }

                    if (accrualValue > 0)
                    {
                        var penalty = CalculatePenalty(accrualValue, daysCountPeriod, penaltyData, bankRate);
                        var report = new ReportPenalty(accrualValue, penalty, dateFromTemp, dateTo, bankRate,
                            penaltyData.Coefficient, daysCountPeriod, penaltyData.CoefficientView);
                      
                        reports.Add(report);
                    }

                    dateFromTemp = dateTo + new TimeSpan(1, 0, 0, 0);

                }
            }

            return reports.ToArray();
        }


        //public IAccountReport[] CalculateBackup(DateTime date)
        //{
        //    var period = new PaymentPeriodCalculationRule();
        //    var reports = new List<IAccountReport>();

        //    Decimal overPayment = 0;

        //    foreach (var accrual in _accountProvider.AccountData.Accrual)
        //    {
        //        var from = period.CalculatePeriod(accrual.Date);
        //        var fromTemp = from;
        //        var daysCountTotal = (int)(date - from).TotalDays;
        //        Console.WriteLine($"дата: {from:dd-MM-yyyy}  кол-во дней :{daysCountTotal}");
        //        var penaltyDatas = _penaltyRulesProvider.PenaltyRules.Data.Where(rule => daysCountTotal > rule.PeriodFrom).ToArray();
        //        for (int i = 0; i < penaltyDatas.Length; ++i)
        //        {
        //            //var bankRate = _bankRateProvider.BankRate.Rate.First(elt => elt.Date <= DateTime.Now).Value;
        //            var bankRate = _bankRateProvider.BankRate.Rate.LastOrDefault(elt => elt.Date <= from)?.Value ?? 100;
        //            var penaltyData = penaltyDatas[i];
        //            var dateTo = DateTime.Now;
        //            int daysCountPeriod = daysCountTotal;
        //            if (i + 1 < penaltyDatas.Length)
        //            {
        //                daysCountTotal -= penaltyDatas[i + 1].PeriodFrom;
        //                daysCountPeriod = penaltyDatas[i+1].PeriodFrom;
        //                dateTo = fromTemp + new TimeSpan(daysCountPeriod,0,0,0);
        //            }
        //            else
        //            {
        //                daysCountPeriod = daysCountTotal;
        //            }

        //            daysCountPeriod = Math.Max(0, daysCountPeriod);
        //            if(daysCountPeriod == 0)
        //                continue;

        //            var payments = _accountProvider.AccountData.Payments.Where(elt => elt.Date >= fromTemp && elt.Date <= dateTo && elt.Value > 0).ToArray();

        //            var penalty = CalculatePenalty(accrual.Value, daysCountPeriod, penaltyData, bankRate);
        //            var report = new ReportPenalty(accrual.Value,penalty, fromTemp, dateTo, bankRate, penaltyData.Coefficient,daysCountPeriod, penaltyData.CoefficientView);

        //            report.DebugView();

        //            reports.Add( new AccountReport(report, null));
        //            fromTemp = dateTo + new TimeSpan(1, 0, 0, 0);
        //        }

        //        Console.WriteLine(string.Empty);
        //    }
        //    return reports.ToArray();
        //}

        private decimal CalculatePenalty(decimal accrual, int daysCountPeriod, IPenaltyData penaltyData, decimal bankRate)
        {
            return accrual * daysCountPeriod * penaltyData.Coefficient * bankRate / 100; ;
        }
    }
}

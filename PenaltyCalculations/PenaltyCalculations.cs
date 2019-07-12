﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenaltyCalculations.Model;

namespace PenaltyCalculations
{
    class PenaltyCalculations : IPenaltyCalculations
    {
        private readonly IAccountProvider _accountProvider;
        private readonly IBankRateProvider _bankRateProvider;
        private readonly IPenaltyRulesProvider _penaltyRulesProvider;

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

        public IAccountReport[] Calculate(DateTime date)
        {
            var period = new PaymentPeriodCalculationRule();
            var reports = new List<IAccountReport>();
            
            foreach (var accrual in _accountProvider.Account.Accrual)
            {
                var from = period.CalculatePeriod(accrual.Date);
                var fromTemp = from;
                var daysCount = (int)(date - from).TotalDays;
                Console.WriteLine($"дата: {from:dd-MM-yyyy}  кол-во дней :{daysCount}");
                var penaltyDatas = _penaltyRulesProvider.PenaltyRules.Data.Where(rule => daysCount > rule.PeriodFrom).ToArray();
                for (int i = 0; i < penaltyDatas.Length; ++i)
                {
                    //var bankRate = _bankRateProvider.BankRate.Rate.First(elt => elt.Date <= DateTime.Now).Value;
                    var bankRate = _bankRateProvider.BankRate.Rate.LastOrDefault(elt => elt.Date <= from)?.Value ?? 100;
                    var penaltyData = penaltyDatas[i];
                    var dateTo = DateTime.Now;
                    int dc = daysCount;
                    if (i + 1 < penaltyDatas.Length)
                    {
                        daysCount -= penaltyDatas[i + 1].PeriodFrom;
                        dc = penaltyDatas[i+1].PeriodFrom;
                        dateTo = fromTemp + new TimeSpan(dc,0,0,0);
                    }
                    else
                    {
                        dc = daysCount;
                    }

                    dc = Math.Max(0, dc);
                    if(dc == 0)
                        continue;

                    var payments = _accountProvider.Account.Payments.Where(elt => elt.Date >= fromTemp && elt.Date <= dateTo).ToArray();

                    var penalty = accrual.Value * dc * penaltyData.Coefficient * bankRate / 100;
                    var report = new ReportPenalty(accrual.Value,penalty, fromTemp, dateTo, bankRate, penaltyData.Coefficient,dc, penaltyData.CoefficientView);
                    report.DebugView();

                    reports.Add( new AccountReport(report, null));
                    fromTemp = dateTo + new TimeSpan(1, 0, 0, 0);
                }

                Console.WriteLine(string.Empty);
            }
            return reports.ToArray();
        }
    }
}

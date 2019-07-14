using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations.Model
{
    public interface IPenaltyRules
    {
        int PaymentPeriod { get; }
        IPenaltyData[] Data { get; }
    }
}

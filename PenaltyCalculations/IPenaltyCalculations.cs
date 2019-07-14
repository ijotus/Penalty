using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenaltyCalculations.Model.Reports;

namespace PenaltyCalculations
{
    interface IPenaltyCalculations
    {
        IReport[] Calculate(DateTime date);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations
{
    interface IPenaltyCalculations
    {
        IAccountReport[] Calculate(DateTime date);
    }
}

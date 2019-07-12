﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations.Model
{
    public interface IPersonalAccount
    {
        IDateAndValue[] Accrual { get; }
        IDateAndValue[] Payments { get; }
    }
}

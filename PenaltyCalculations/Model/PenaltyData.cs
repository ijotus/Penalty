using System;
using System.Runtime.Serialization;

namespace PenaltyCalculations.Model
{
    [DataContract]
    public class PenaltyData : IPenaltyData
    {
        [field: DataMember(Name = "PeriodFrom")]
        public int PeriodFrom { get; }

        [field: DataMember(Name = "Coefficient")]
        public Decimal Coefficient { get; }

        [field: DataMember(Name = "CoefficientView")]
        public string CoefficientView { get; }

        public PenaltyData(int periodFrom, Decimal coefficient,string coefficientView)
        {
            PeriodFrom  = periodFrom;
            Coefficient = coefficient;
            CoefficientView = coefficientView;
        }
    }
}
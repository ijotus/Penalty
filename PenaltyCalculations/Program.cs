using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculations
{
    class Program
    {
        static void Main(string[] args)
        {
            var providers = new DataProvider();
            providers.InitializeCase0();
            var res = new PenaltyCalculations(providers, providers, providers);
            res.Calculate(DateTime.Now);
        }
    }
}

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
            providers.InitializeCase1();
            var res = new PenaltyCalculations(providers, providers, providers);

            Console.WriteLine("==================================================================================");
            Console.WriteLine("==================================== ЗАДАЧА 1 ====================================");
            Console.WriteLine("==================================================================================");
            var reports = res.Calculate(DateTime.Now);
            reports.ToList().ForEach(elt => elt.DebugView());

            providers.InitializeCase2();
            Console.WriteLine(string.Empty);
            Console.WriteLine("==================================================================================");
            Console.WriteLine("==================================== ЗАДАЧА 2 ====================================");
            Console.WriteLine("==================================================================================");
            reports = res.Calculate(DateTime.Now);
            reports.ToList().ForEach(elt => elt.DebugView());

            providers.InitializeCase3();
            Console.WriteLine(string.Empty);
            Console.WriteLine("==================================================================================");
            Console.WriteLine("===================================== ЗАДАЧА 3 ===================================");
            Console.WriteLine("==================================================================================");
            reports = res.Calculate(DateTime.Now);
            reports.ToList().ForEach(elt => elt.DebugView());
        }
    }
}

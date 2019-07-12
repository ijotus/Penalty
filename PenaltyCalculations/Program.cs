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
            Console.WriteLine("==================================== ЗАДАЧА 1 ====================================");
            res.Calculate(DateTime.Now);

            providers.InitializeCase1();
            Console.WriteLine("==================================== ЗАДАЧА 2 ====================================");
            res.Calculate(DateTime.Now);

            providers.InitializeCase2();
            Console.WriteLine("===================================== ЗАДАЧА 3 ===================================");
            res.Calculate(DateTime.Now);
        }
    }
}

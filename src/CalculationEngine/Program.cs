using System;

namespace CalculationEngine
{
    /// <summary>
    /// Entry point to running calculation.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World Calculation Engine!");
            Console.WriteLine("-------------------------------");
            double initialInvst = 10000;
            double discountRate = .1;
            double yearlycashIn = 3000;
            double noofYears = 5;
            ///Initailizing NPVCalculation class with the parameters of Initail investment, discountrate, yearly cash flow, number of years
            ///then the Execute method is called and result is found in Result property of the class.
            ICalcuation calcuationNPV = new NPVCalculation(initialInvst, discountRate,yearlycashIn, noofYears);
            bool executed=calcuationNPV.Execute();
            Console.WriteLine(String.Format("With Initial Investment {0} and Discount Rate {1} and cashInFlow {2} , noof years{3} : NPV={4}", initialInvst, discountRate,yearlycashIn, noofYears, calcuationNPV.Result));
            Console.ReadLine();
        }
    }
}

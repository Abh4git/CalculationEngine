using System;
using Calculations.Core.Interfaces;
using Calculations.Core.Enums;
using Calculations.Core.Entities;
using CalculationEngine;
using System.Collections.Generic;

namespace CalculationEngineConsole
{
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
            FinancialReturnInputs finROIInputs = new FinancialReturnInputs();
            finROIInputs.IsCashinFlowFixed = true;
            finROIInputs.DiscountRate = discountRate;
            finROIInputs.InitialInvestment = initialInvst;
            finROIInputs.NumberofYears = noofYears;
            finROIInputs.FixedCashinFlow = yearlycashIn;
            ///Initailizing NPVCalculation class with the parameters of Initail investment, discountrate, yearly cash flow, number of years
            ///then the Execute method is called and result is found in Result property of the class.
            ICalcuation calcuationNPV = CalculationFactory.Instance().GetCalculation(CalculationTypeEnum.NPV,finROIInputs);
            bool executed = calcuationNPV.Execute();
            Console.WriteLine(String.Format("With Initial Investment {0} and Discount Rate {1} and cashInFlow {2} , noof years{3} : NPV={4}", initialInvst, discountRate, yearlycashIn, noofYears, calcuationNPV.Result));

            initialInvst = 200000;
            discountRate = .04;

            List<double> yearlyCashFlows = new List<double>();
            yearlyCashFlows.Add(50000);
            yearlyCashFlows.Add(50000);
            yearlyCashFlows.Add(50000);
            yearlyCashFlows.Add(50000);
            yearlyCashFlows.Add(50000);

            yearlyCashFlows.Add(45000);
            yearlyCashFlows.Add(45000);
            yearlyCashFlows.Add(45000);
            yearlyCashFlows.Add(45000);
            yearlyCashFlows.Add(45000);


            finROIInputs.IsCashinFlowFixed = false;
            finROIInputs.DiscountRate = discountRate;
            finROIInputs.InitialInvestment = initialInvst;
            finROIInputs.CashInFlows = yearlyCashFlows;
          ;

            ///Initailizing NPVCalculation class with the parameters of Initail investment, discountrate, yearly cash flow, number of years
            ///then the Execute method is called and result is found in Result property of the class.
            ICalcuation calcuationNPV2 = CalculationFactory.Instance().GetCalculation(CalculationTypeEnum.NPV,finROIInputs);
            bool executed2 = calcuationNPV2.Execute();
            Console.WriteLine(String.Format("With Initial Investment {0} and Discount Rate {1} and cashInFlow {2} , noof years{3} : IRR={4}", initialInvst, discountRate, yearlycashIn, noofYears, calcuationNPV2.Result));

            finROIInputs.IsCashinFlowFixed = true;
            finROIInputs.DiscountRate = discountRate;
            finROIInputs.InitialInvestment = initialInvst;
            finROIInputs.NumberofYears = noofYears;
            finROIInputs.FixedCashinFlow = yearlycashIn;
            finROIInputs.MaxDiscountRate = .9;
            ICalcuation calculationIRR = CalculationFactory.Instance().GetCalculation(CalculationTypeEnum.IRR,finROIInputs);
            bool executedIRR = calculationIRR.Execute();
            Console.WriteLine(String.Format("With Initial Investment {0} and Discount Rate {1} and cashInFlow {2} , noof years{3} : IRR={4}", initialInvst, discountRate, yearlycashIn, noofYears, calculationIRR.Result));

            Console.ReadLine();
        }
    }
}
